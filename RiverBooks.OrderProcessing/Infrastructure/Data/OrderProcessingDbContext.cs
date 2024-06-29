using System.Reflection;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RiverBooks.OrderProcessing.Domain;
using RiverBooks.SharedKernel;

namespace RiverBooks.OrderProcessing.Infrastructure.Data;

internal class OrderProcessingDbContext : IdentityDbContext
{
  private readonly IDomainEventDispatcher? _dispatcher;

  public OrderProcessingDbContext(DbContextOptions<OrderProcessingDbContext> options,
    IDomainEventDispatcher? dispatcher)
    : base(options)
  {
    _dispatcher = dispatcher;
  }

  public DbSet<Order> Orders { get; set; }
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.HasDefaultSchema("OrderProcessing");

    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    base.OnModelCreating(modelBuilder);
  }
  protected override void ConfigureConventions(
    ModelConfigurationBuilder configurationBuilder)
  {
    configurationBuilder.Properties<decimal>()
      .HavePrecision(18, 6);
  }

  public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
  {
    var result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

    if (_dispatcher == null) return result;

    var entitiesWithEvents = ChangeTracker.Entries<IHaveDomainEvents>()
      .Select(e => e.Entity)
    .Where(e => e.DomainEvents.Any())
      .ToArray();

    await _dispatcher.DispatchAndClearEvents(entitiesWithEvents);
    return result;
  }
}
