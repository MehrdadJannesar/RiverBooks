namespace RiverBooks.Users;

public interface IApplicationUserRepoisory
{
  Task<ApplicationUser> GetUserWithCartByEmailAsync(string email);
  Task SaveChangesAsync();
}
