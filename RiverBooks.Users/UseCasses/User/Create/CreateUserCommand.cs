using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Result;
using MediatR;

namespace RiverBooks.Users.UseCasses.User.Create;
internal record CreateUserCommand(string Email, string Password):IRequest<Result>;
