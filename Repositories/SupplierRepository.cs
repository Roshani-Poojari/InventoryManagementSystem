using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagementSystem.Data;
using InventoryManagementSystem.Exceptions;
using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Repositories
{
    internal class SupplierRepository
    {
        private readonly InventoryContext _inventoryContext;
        public SupplierRepository(InventoryContext inventoryContext)
        {
            _inventoryContext = inventoryContext;
        }
        public void Add(Supplier supplier)
        {
            _inventoryContext.Suppliers.Add(supplier);
            _inventoryContext.SaveChanges();
        }

        public void Update(Supplier supplier)
        {
            _inventoryContext.Suppliers.Update(supplier);
            _inventoryContext.SaveChanges();
        }
        public void Delete(Supplier supplier)
        {
            _inventoryContext.Suppliers.Remove(supplier);
            _inventoryContext.SaveChanges();
        }
        public List<Supplier> GetAll(int id)
        {           
            return _inventoryContext.Suppliers.Where(x => x.InventoryId == id).ToList();
        }
        public Supplier CheckSupplierNameExistsInInventory(string supplierName, int inventoryId)
        {
            var checkSupplier = _inventoryContext.Suppliers.Where(x => x.Name == supplierName && x.InventoryId == inventoryId).FirstOrDefault();
            return checkSupplier;
        }
        public bool CheckInventoryIdExists(int id)
        {
            var checkInventory = _inventoryContext.Inventories.Where(x => x.InventoryId == id).FirstOrDefault();
            return checkInventory == null;
        }
        //supplier repo ka kaam he kya?
    }
}
