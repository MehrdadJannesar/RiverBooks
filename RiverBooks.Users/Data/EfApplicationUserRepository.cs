using Microsoft.EntityFrameworkCore;

namespace RiverBooks.Users.Data;

internal class EfApplicationUserRepository : IApplicationUserRepository
{
  private readonly UsersDbContext _dbcontext;

  public EfApplicationUserRepository(UsersDbContext dbcontext)
  {
    _dbcontext = dbcontext;
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
