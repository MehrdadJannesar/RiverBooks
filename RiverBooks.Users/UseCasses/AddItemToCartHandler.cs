using Ardalis.Result;
using MediatR;

namespace RiverBooks.Users.UseCasses;

public class AddItemToCartHandler : IRequestHandler<AddItemToCartCommand, Result>
{
  private readonly IApplicationUserRepoisory _userRepoisory;

  public AddItemToCartHandler(IApplicationUserRepoisory userRepoisory)
  {
    _userRepoisory = userRepoisory;
  }

  public async Task<Result> Handle(AddItemToCartCommand request, CancellationToken cancellationToken)
  {
    var user = await _userRepoisory.GetUserWithCartByEmailAsync(request.EmailAddress);
    if (user == null)
    {
      return Result.Unauthorized();
    }
    
    var newCartItem = new CartItem(request.BookId,
      "decription",
      request.Quantity,
      1.00m);

    user.AddItemToCart(newCartItem);

    await _userRepoisory.SaveChangesAsync();

    return Result.Success();
  }
}
