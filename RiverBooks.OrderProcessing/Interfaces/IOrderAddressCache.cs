using Ardalis.Result;
using RiverBooks.OrderProcessing.Infrastructure.Redis;

namespace RiverBooks.OrderProcessing.Interfaces;

public interface IOrderAddressCache
{
  Task<Result<OrderAddress>> GetByIdAsync(Guid addressId);
  Task<Result> StoreAsync(OrderAddress orderAddress);
}
