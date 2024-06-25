using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiverBook.Books.Contracts;
public record BookDetailsResponse(Guid Id,string Title, string Author,decimal Price);
