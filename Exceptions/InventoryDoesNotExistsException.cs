﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Exceptions
{
    internal class InventoryDoesNotExistsException:Exception
    {
        public InventoryDoesNotExistsException(string message):base(message) { }

    }
}
