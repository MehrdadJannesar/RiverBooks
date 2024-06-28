using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Result;
using FastEndpoints;
using MediatR;
using RiverBooks.Users.UseCasses.User;

namespace RiverBooks.Users.UserEndpoints;
internal class AddAddres:Endpoint<AddAddressRequest>
{
  private readonly IMediator _mediator;

  public AddAddres(IMediator mediator)
  {
    _mediator = mediator;
  }
  public override void Configure()
  {
    Post("/users/addresses");
    Claims("EmailAddress");
  }
  public override async Task HandleAsync(AddAddressRequest req, CancellationToken ct)
  {
    var emailAddress = User.FindFirstValue("EmailAddress");

    var command = new AddAddressToUserCommand(emailAddress!, 
      req.Street1,
      req.Street2,
      req.City,
      req.State,
      req.PostalCode,
      req.Country);

    var result = await _mediator.Send(command);

    if (result.Status == ResultStatus.Unauthorized)
    {
      await SendUnauthorizedAsync();
    }
    else
    {
      await SendOkAsync();
    }
  }
}
