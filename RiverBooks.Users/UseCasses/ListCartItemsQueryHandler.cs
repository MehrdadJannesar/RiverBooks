﻿using Ardalis.Result;
using MediatR;
using RiverBooks.Users.CartEndpoints;
using RiverBooks.Users.Data;

namespace RiverBooks.Users.UseCasses;

internal class ListCartItemsQueryHandler : IRequestHandler<ListCartItemsQuery,
  Result<List<CartItemDto>>>
{
  private readonly IApplicationUserRepoisory _userRepository;

  public ListCartItemsQueryHandler(IApplicationUserRepoisory userRepository)
  {
    _userRepository = userRepository;
  }

  public async Task<Result<List<CartItemDto>>> Handle(ListCartItemsQuery request, CancellationToken cancellationToken)
  {
    var user = await _userRepository.GetUserWithCartByEmailAsync(request.EmailAddress);

    if (user is null)
    {
      return Result.Unauthorized();
    }

    return user.CartItems
      .Select(item => new CartItemDto(item.Id, item.BookId,
      item.Description, item.Quantity, item.Price))
      .ToList();
  }
}
