using MediatR;

namespace RiverBooks.Users;

public class MediatRDomainEventDispatcher : IDomainEventDispatcher
{
  private readonly IMediator _mediator;

  public MediatRDomainEventDispatcher(IMediator mediator)
  {
    _mediator = mediator;
  }
  public async Task DispatchAndClearEvents(IEnumerable<IHaveDomainEvents> entitiesWithEvents)
  {
    foreach (var entity in entitiesWithEvents)
    {
      var events = entity.DomainEvents.ToArray();
      entity.ClearDomainEvent();
      foreach (var domainEvnet in events)
      {
        await _mediator.Publish(domainEvnet).ConfigureAwait(false);
      }
    }
  }
}
