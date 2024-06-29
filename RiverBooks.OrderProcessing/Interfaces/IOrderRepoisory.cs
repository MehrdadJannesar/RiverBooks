using RiverBooks.OrderProcessing.Domain;

namespace RiverBooks.OrderProcessing.Interfaces;

internal interface IOrderRepoisory
{
  Task<List<Order>> ListAsync();
  Task AddAsync(Order order);
  Task SaveChangesAsync();
}
