using Ardalis.Result;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using RiverBooks.OrderProcessing.Contracts;
using RiverBooks.OrderProcessing.Domain;
using RiverBooks.OrderProcessing.Interfaces;
using Serilog;

namespace RiverBooks.OrderProcessing.Integrations;
internal class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand
  , Result<OrderDetailsResponse>>
{
  private readonly IOrderRepoisory _orderRepoisory;
  private readonly ILogger<CreateOrderCommandHandler> _logger;
  private readonly IOrderAddressCache _addressCache;

  public CreateOrderCommandHandler(IOrderRepoisory orderRepoisory,
    ILogger<CreateOrderCommandHandler> logger, IOrderAddressCache addressCache)
  {
    _orderRepoisory = orderRepoisory;
    _logger = logger;
    _addressCache = addressCache;
  }

  public async Task<Result<OrderDetailsResponse>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
  {
    var items = request.OrderItmes.Select(oi => new OrderItem(
      oi.BookId, oi.Quantity, oi.UnitPrice, oi.Description));

    //var shippingAddress = new Address("123", "", "Saadat", "TH", "4", "IRAN");
    //var billingAddress = shippingAddress;
    var shippingAddress = await _addressCache.GetByIdAsync(request.ShippingAddressId);
    var billingAddress = await _addressCache.GetByIdAsync(request.BillingAddressId);

    var newOrder = Order.Factory.Create(request.UserId,
      shippingAddress.Value.Address,
      billingAddress.Value.Address,
      items);

    await _orderRepoisory.AddAsync(newOrder);

    await _orderRepoisory.SaveChangesAsync();

    _logger.LogInformation("New Order Created! {orderId}", newOrder.Id);

    return new OrderDetailsResponse(newOrder.Id);
  }
}
