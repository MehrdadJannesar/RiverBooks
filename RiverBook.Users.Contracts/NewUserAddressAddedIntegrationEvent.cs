namespace RiverBook.Users.Contracts;


public record NewUserAddressAddedIntegrationEvent(UserAddressDetails Details)
  : IntegrationEventBase;


