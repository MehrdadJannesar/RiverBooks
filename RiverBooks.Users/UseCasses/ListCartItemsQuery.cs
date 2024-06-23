using Ardalis.Result;
using MediatR;
using RiverBooks.Users.CartEndpoints;

namespace RiverBooks.Users.UseCasses;

public record ListCartItemsQuery(string EmailAddress) :
  IRequest<Result<List<CartItemDto>>>;
