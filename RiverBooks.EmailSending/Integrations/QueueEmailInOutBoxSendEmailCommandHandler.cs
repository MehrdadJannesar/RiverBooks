using Ardalis.Result;
using MediatR;
using RiverBooks.EmailSending.Contracts;

namespace RiverBooks.EmailSending.Integrations;

internal class QueueEmailInOutBoxSendEmailCommandHandler : IRequestHandler<SendEmailCommand, Result<Guid>>
{
  private readonly IOutboxService _outboxService;

  public QueueEmailInOutBoxSendEmailCommandHandler(IOutboxService outboxService)
  {
    _outboxService = outboxService;
  }

  public async Task<Result<Guid>> Handle(SendEmailCommand request, CancellationToken cancellationToken)
  {
    var newEntity = new EmailOutboxEntity
    {
      Body = request.Body,
      Subject = request.Subject,
      To = request.To,
      From = request.From
    };

    await _outboxService.QueueEmailForSending(newEntity);

    return newEntity.Id;

  }
}
