using Ardalis.Result;
using MediatR;

namespace RiverBook.Books.Contracts;

public record BookDetailsQuery(Guid BookId):IRequest<Result<BookDetailsResponse>>;

