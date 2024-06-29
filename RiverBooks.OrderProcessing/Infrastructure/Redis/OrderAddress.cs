using RiverBooks.OrderProcessing.Domain;

namespace RiverBooks.OrderProcessing.Infrastructure.Redis;
public record OrderAddress(Guid Id, Address Address);
