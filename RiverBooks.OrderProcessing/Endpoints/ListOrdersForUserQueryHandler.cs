using Ardalis.Result;
using MediatR;
using RiverBooks.OrderProcessing.Interfaces;

namespace RiverBooks.OrderProcessing.Endpoints;

internal class ListOrdersForUserQueryHandler :
  IRequestHandler<ListOrdersForUserQuery, Result<List<OrderSummary>>>
{
  private readonly IOrderRepoisory _orderRepoisory;

  public ListOrdersForUserQueryHandler(IOrderRepoisory orderRepoisory)
  {
    _orderRepoisory = orderRepoisory;
  }

  public async Task<Result<List<OrderSummary>>> Handle(ListOrdersForUserQuery request, CancellationToken cancellationToken)
  {
    var orders = await _orderRepoisory.ListAsync();

    var summaries = orders.Select(o => new OrderSummary
    {
      DateCreated = o.DateCreated,
      OrderId = o.Id,
      UserId = o.UserId,
      Total = o.OrderItems.Sum(oi=>oi.UnitPrice)
    }).ToList();

    return summaries;
  }
}
