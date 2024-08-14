using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Exceptions
{
    internal class SupplierDoesNotExistException:Exception
    {
        public SupplierDoesNotExistException(string message):base(message) { }
    }
}
