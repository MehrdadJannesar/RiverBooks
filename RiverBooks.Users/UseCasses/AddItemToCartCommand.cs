using System.Net.NetworkInformation;
using Ardalis.Result;
using MediatR;

namespace RiverBooks.Users.UseCasses;
public record AddItemToCartCommand(Guid BookId, int Quantity, string EmailAddress)
  : IRequest<Result>;
