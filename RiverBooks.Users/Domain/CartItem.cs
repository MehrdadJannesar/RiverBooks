﻿using Ardalis.GuardClauses;

namespace RiverBooks.Users.Domain;

public class CartItem
{
  public CartItem(Guid bookId, string description, int quantity, decimal price)
  {
    BookId = Guard.Against.Default(bookId);
    Description = Guard.Against.NullOrEmpty(description);
    Quantity = Guard.Against.Negative(quantity);
    Price = Guard.Against.Negative(price);
  }

  public CartItem()
  {
    // EF
  }

  public Guid Id { get; private set; } = Guid.NewGuid();
  public Guid BookId { get; private set; }
  public string Description { get; private set; } = string.Empty;
  public int Quantity { get; private set; }
  public decimal Price { get; private set; }
  internal void UpdateQuantity(int quantity)
  {
    Quantity = Guard.Against.Negative(quantity);
  }

  internal void UpdateDescription(string description)
  {
    Description = Guard.Against.NullOrEmpty(description);
  }

  internal void UpdateUnitPrice(decimal unitPrice)
  {
    Price = Guard.Against.Negative(unitPrice);
  }
}

