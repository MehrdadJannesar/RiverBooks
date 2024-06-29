using Ardalis.Result;

namespace RiverBooks.EmailSending;
internal partial class EmailSendingBackgroundService
{
  internal interface ISendEmailsFromOutboxService
  {
    Task CheckForAndSendEmails();
  }
}
