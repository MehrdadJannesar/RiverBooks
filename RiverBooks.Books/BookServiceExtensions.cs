using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RiverBooks.Books.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiverBooks.Books;

public static class BookServiceExtensions
{
    public static IServiceCollection AddBookServices(this IServiceCollection services,
        ConfigurationManager config)
    {
        string? connectionString = config.GetConnectionString("BooksConnectionString");
        services.AddDbContext<BookDbContext>(options =>
            options.UseSqlServer(connectionString));
        services.AddScoped<IBookService, BookService>();
        services.AddScoped<IBookRepository, EfBookRepository>();
        return services;
    }
}
