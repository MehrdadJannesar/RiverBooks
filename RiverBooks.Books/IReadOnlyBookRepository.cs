namespace RiverBooks.Books;

internal interface IReadOnlyBookRepository
{
    Task<Book?> GetByIdAsync(Guid Id);
    Task<List<Book>> ListAsync();
}
