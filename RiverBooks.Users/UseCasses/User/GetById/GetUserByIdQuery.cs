using Ardalis.Result;
using MediatR;

namespace RiverBooks.Users.UseCasses.User.GetById;
internal record GetUserByIdQuery(Guid UserId) : IRequest<Result<UserDTO>>;
