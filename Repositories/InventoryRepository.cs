using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagementSystem.Data;
using InventoryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Repositories
{
    internal class InventoryRepository
    {
        private readonly InventoryContext _inventoryContext;
        public InventoryRepository(InventoryContext inventoryContext)
        {
            _inventoryContext = inventoryContext;
        }

        public List<Inventory> GetAll()
        {
            return _inventoryContext.Inventories
                .Include(inventory=> inventory.Products)
                .Include(inventory => inventory.Suppliers)
                .Include(inventory => inventory.Transactions)
                .ToList();
        }
    }
}
