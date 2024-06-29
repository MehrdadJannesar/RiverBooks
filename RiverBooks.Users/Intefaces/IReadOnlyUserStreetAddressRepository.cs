using RiverBooks.Users.Domain;

namespace RiverBooks.Users.Intefaces;

public interface IReadOnlyUserStreetAddressRepository
{
  Task<UserStreetAddress?> GetById(Guid userStreetAddressId);
}
