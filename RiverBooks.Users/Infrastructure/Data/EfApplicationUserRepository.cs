using Microsoft.EntityFrameworkCore;
using RiverBooks.Users.Intefaces;

namespace RiverBooks.Users.Infrastructure.Data;

internal class EfApplicationUserRepository : IApplicationUserRepository
{
  private readonly UsersDbContext _dbcontext;

  public EfApplicationUserRepository(UsersDbContext dbcontext)
  {
    _dbcontext = dbcontext;
  }

  public Task<ApplicationUser> GetUserByIdAsync(Guid userId)
  {
    return _dbcontext.ApplicationUsers
      .SingleAsync(user => user.Id == userId.ToString());
  }

  public Task<ApplicationUser> GetUserWithAddressesByEmailAsync(string email)
  {
    return _dbcontext.ApplicationUsers.Include(user => user.Addresses)
      .SingleAsync(user => user.Email == email);
  }

  public Task<ApplicationUser> GetUserWithCartByEmailAsync(string email)
  {
    return _dbcontext.ApplicationUsers.Include(user => user.CartItems)
      .SingleAsync(user => user.Email == email);
  }

  public Task SaveChangesAsync()
  {
    return _dbcontext.SaveChangesAsync();
  }
}
