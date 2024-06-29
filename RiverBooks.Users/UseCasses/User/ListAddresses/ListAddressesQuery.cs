using Ardalis.Result;
using MediatR;
using RiverBooks.Users.UserEndpoints;

namespace RiverBooks.Users.UseCasses.User.ListAddresses;
internal record ListAddressesQuery(string EmailAddress) :
  IRequest<Result<List<UserAddressDto>>>;
