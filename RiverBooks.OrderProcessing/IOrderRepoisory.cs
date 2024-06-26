using RiverBooks.OrderProcessing;

namespace RiverBooks.Users;

internal interface IOrderRepoisory
{
  Task<List<Order>> ListAsync();
  Task AddAsync(Order order);
  Task SaveChangesAsync();
}
