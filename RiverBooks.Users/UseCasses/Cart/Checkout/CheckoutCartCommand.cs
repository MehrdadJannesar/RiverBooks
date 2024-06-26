using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Result;
using MediatR;

namespace RiverBooks.Users.UseCasses.Cart.Checkout;
internal record CheckoutCartCommand(string EmailAddress,
                                  Guid shippingAddressId,
                                  Guid billingAddressId) : IRequest<Result<Guid>>;

