﻿
namespace RiverBooks.Users.Intefaces;

public interface IApplicationUserRepository
{
  Task<ApplicationUser> GetUserByIdAsync(Guid userId);
  Task<ApplicationUser> GetUserWithCartByEmailAsync(string email);
  Task<ApplicationUser> GetUserWithAddressesByEmailAsync(string email);
  Task SaveChangesAsync();
}
