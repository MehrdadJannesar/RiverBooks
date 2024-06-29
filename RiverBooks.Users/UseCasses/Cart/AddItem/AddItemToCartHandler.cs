using Ardalis.Result;
using MediatR;
using RiverBook.Books.Contracts;
using RiverBooks.Users.Intefaces;

namespace RiverBooks.Users.UseCasses.Cart.AddItem;

public class AddItemToCartHandler : IRequestHandler<AddItemToCartCommand, Result>
{
  private readonly IApplicationUserRepository _userRepoisory;
  private readonly IMediator _mediator;

  public AddItemToCartHandler(IApplicationUserRepository userRepoisory,
    IMediator mediator)
  {
    _userRepoisory = userRepoisory;
    _mediator = mediator;
  }

  public async Task<Result> Handle(AddItemToCartCommand request, CancellationToken cancellationToken)
  {
    var user = await _userRepoisory.GetUserWithCartByEmailAsync(request.EmailAddress);
    if (user == null)
    {
      return Result.Unauthorized();
    }
    var query = new BookDetailsQuery(request.BookId);
    var result = await _mediator.Send(query);

    if (result.Status == ResultStatus.NotFound) return Result.NotFound();

    var bookDetails = result.Value;

    var Description = $"{bookDetails.Title} by {bookDetails.Author}";

    var newCartItem = new CartItem(request.BookId,
      Description,
      request.Quantity,
      bookDetails.Price);

    user.AddItemToCart(newCartItem);

    await _userRepoisory.SaveChangesAsync();

    return Result.Success();
  }
}
