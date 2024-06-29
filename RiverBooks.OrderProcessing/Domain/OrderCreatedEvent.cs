using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RiverBooks.SharedKernel;

namespace RiverBooks.OrderProcessing.Domain;
internal class OrderCreatedEvent : DomainEventBase
{
  public OrderCreatedEvent(Order order)
  {
    Order = order;
  }
  public Order Order { get; set; }
}
