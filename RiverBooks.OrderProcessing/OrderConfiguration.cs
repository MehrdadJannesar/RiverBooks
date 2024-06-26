using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace RiverBooks.OrderProcessing;
public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
  void IEntityTypeConfiguration<Order>.Configure(EntityTypeBuilder<Order> builder)
  {
    builder
      .Property(x => x.Id)
      .ValueGeneratedNever();
    builder.ComplexProperty(o => o.ShippingAddress, address =>
    {
      address.Property(a => a.Street1)
        .HasMaxLength(Constants.STREET_MAXLENGTH);
      address.Property(a => a.Street2)
        .HasMaxLength(Constants.STREET_MAXLENGTH);
      address.Property(a => a.City)
        .HasMaxLength(Constants.CITY_MAXLENGTH);
      address.Property(a => a.State)
        .HasMaxLength(Constants.STATE_MAXLENGTH);
      address.Property(a => a.PostalCode)
        .HasMaxLength(Constants.POSTALCODE_MAXLENGTH);
      address.Property(a => a.Country)
        .HasMaxLength(Constants.COUNTRY_MAXLENGTH);
    });

    builder.ComplexProperty(o => o.BillingAddress, address =>
    {
      address.Property(a => a.Street1)
        .HasMaxLength(Constants.STREET_MAXLENGTH);
      address.Property(a => a.Street2)
        .HasMaxLength(Constants.STREET_MAXLENGTH);
      address.Property(a => a.City)
        .HasMaxLength(Constants.CITY_MAXLENGTH);
      address.Property(a => a.State)
        .HasMaxLength(Constants.STATE_MAXLENGTH);
      address.Property(a => a.PostalCode)
        .HasMaxLength(Constants.POSTALCODE_MAXLENGTH);
      address.Property(a => a.Country)
        .HasMaxLength(Constants.COUNTRY_MAXLENGTH);
    });
  }
}
