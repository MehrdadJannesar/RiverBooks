﻿using Ardalis.Result;
using Ardalis.Result.AspNetCore;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Identity;
using RiverBooks.Users.UseCasses.User.Create;

namespace RiverBooks.Users.UserEndpoints;

internal class Create : Endpoint<CreateUserRequest>
{
  private readonly IMediator _mediator;

  public Create(IMediator mediator)
  {
    _mediator = mediator;
  }

  public override void Configure()
  {
    Post("/users");
    AllowAnonymous();
  }
  public override async Task HandleAsync(CreateUserRequest req, CancellationToken ct)
  {
    var command = new CreateUserCommand(req.Email, req.Password);
    var result = await _mediator.Send(command);

    if (!result.IsSuccess)
    {
      await SendResultAsync(result.ToMinimalApiResult());
      return;
    }

    await SendOkAsync();
  }
}
