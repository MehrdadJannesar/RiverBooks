﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RiverBooks.OrderProcessing.Infrastructure.Data;
using RiverBooks.OrderProcessing.Infrastructure.Redis;
using RiverBooks.OrderProcessing.Interfaces;
using Serilog;

namespace RiverBooks.Users;

public static class OrderProcessingModuleServiceExtensions
{
  public static IServiceCollection AddOrderProcessingModuleServices(
    this IServiceCollection services, ConfigurationManager config,
    ILogger logger,
    List<System.Reflection.Assembly> mediatRAssemblies)
  {
    string? connectionString = config.GetConnectionString("OrderProcessingConnectionString");
    services.AddDbContext<OrderProcessingDbContext>(options =>
        options.UseSqlServer(connectionString));

    // Add Services
    services.AddScoped<IOrderRepoisory, EfOrderRepository>();
    // Decorator
    services.AddScoped<RedisOrderAddressCache>();
    services.AddScoped<IOrderAddressCache, ReadThroughOrderAddressCache>();

    // if using MediatR in this module, add any assemblies that contain handlers to the list
    mediatRAssemblies.Add(typeof(OrderProcessingModuleServiceExtensions).Assembly);

    logger.Information("{Module} module services registered", "OrderProcessing");

    return services;
  }
}
