using System.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace RiverBooks.EmailSending;
public static class EmailSendingModuleServicesExtensions
{
  public static IServiceCollection AddEmailSendingModuleServices(
      this IServiceCollection services,
      ConfigurationManager config,
      ILogger logger,
      List<System.Reflection.Assembly> mediatRAssemblies)
  {
    // Add module services
    services.AddTransient<ISendEmail, MimeKitEmailSender>();

    // if using MediatR in this module, add any assemblies that contain handlers to the list
    mediatRAssemblies.Add(typeof(EmailSendingModuleServicesExtensions).Assembly);
    logger.Information("{Module} module services registered", "Email Sending");
    return services;
  }
}
