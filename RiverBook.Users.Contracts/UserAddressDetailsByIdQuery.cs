using Ardalis.Result;
using MediatR;

namespace RiverBook.Users.Contracts;
public record UserAddressDetailsByIdQuery(Guid AddressId) :
  IRequest<Result<UserAddressDetails>>;

