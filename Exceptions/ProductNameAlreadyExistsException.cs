using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Exceptions
{
    internal class ProductNameAlreadyExistsException:Exception
    {
        public ProductNameAlreadyExistsException(string message) : base(message) { }
    }
}
