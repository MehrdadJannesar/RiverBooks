using MediatR;

namespace RiverBooks.Users.Contracts;

public abstract record IntegrationEventBase : INotification
{
  public DateTime DateOccurred { get; protected set; } = DateTime.UtcNow;
}
