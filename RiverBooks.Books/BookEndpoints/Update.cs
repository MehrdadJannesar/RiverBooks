using FastEndpoints;
namespace RiverBooks.Books.BookEndpoints;

internal class Update(IBookService bookService) :
    Endpoint<UpdateBookRequest>
{
  private readonly IBookService _bookService = bookService;

  public override void Configure()
  {
    Post("/books/{Id}/pricehistory");
    AllowAnonymous();
  }

  public override async Task HandleAsync(UpdateBookRequest req, CancellationToken ct)
  {
    await _bookService.UpdateBookPriceAsync(req.Id, req.Price);
    var updatedBook = await _bookService.GetBookByIdAsync(req.Id);
    await SendAsync(updatedBook);
  }
}

