using MediatR;

namespace RiverBook.Users.Contracts;

public abstract record IntegrationEventBase : INotification
{
  public DateTime DateOccurred { get; protected set; } = DateTime.UtcNow;
}
