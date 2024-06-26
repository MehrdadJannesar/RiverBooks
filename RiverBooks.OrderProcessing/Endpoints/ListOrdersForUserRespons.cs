namespace RiverBooks.OrderProcessing.Endpoints;

public class ListOrdersForUserRespons
{
  public List<OrderSummary> Orders { get; set; } = new();
}
