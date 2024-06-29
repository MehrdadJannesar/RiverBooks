using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastEndpoints;
using MongoDB.Driver;

namespace RiverBooks.EmailSending.ListEmailsEndpoint;
internal class ListEmails : EndpointWithoutRequest<ListEmailsResponse>
{
  private readonly IMongoCollection<EmailOutboxEntity> _emailCollection;

  public ListEmails(IMongoCollection<EmailOutboxEntity> emailCollection)
  {
    _emailCollection = emailCollection;
  }

  public override void Configure()
  {
    Get("/emails");
    AllowAnonymous();
  }

  public override async Task HandleAsync(
   CancellationToken ct = default)
  {
    // TODO: Implement paging
    var filter = Builders<EmailOutboxEntity>.Filter.Empty;
    var emailEntities = await _emailCollection.Find(filter)
      .ToListAsync();

    var response = new ListEmailsResponse()
    {
      Count = emailEntities.Count,
      Emails = emailEntities // TODO: Use a separate DTO
    };

    Response = response;
  }

}
