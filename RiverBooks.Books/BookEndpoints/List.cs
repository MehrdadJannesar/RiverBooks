using FastEndpoints;
namespace RiverBooks.Books.BookEndpoints;


internal class List(IBookService bookService)
    : EndpointWithoutRequest<ListBooksResponse>
{
  // REPR (Request-Endpoint-Response) ==> Fast API
  private readonly IBookService _bookService = bookService;

  public override async Task HandleAsync(CancellationToken ct = default)
  {
    var books = await _bookService.ListBooksAsync();
    await SendAsync(new ListBooksResponse()
    {
      Books = books
    });
  }

  public override void Configure()
  {
    Get("/books");
    AllowAnonymous();
  }


}

