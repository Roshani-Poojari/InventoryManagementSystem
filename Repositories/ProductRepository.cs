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
    internal class ProductRepository
    {

        private readonly InventoryContext _inventoryContext;
        public ProductRepository(InventoryContext inventoryContext)
        {
            _inventoryContext = inventoryContext;
        }
        public void Add(Product product)
        {
            _inventoryContext.Products.Add(product);
            _inventoryContext.SaveChanges();
        }
        public void Update(Product product)
        {
            _inventoryContext.Products.Update(product);
            _inventoryContext.SaveChanges();
        }


        public void Delete(Product product)
        {
            _inventoryContext.Products.Remove(product);
            _inventoryContext.SaveChanges();
        }
        public List<Product> GetAll(int id)
        {
            return _inventoryContext.Products.Where(x => x.InventoryId == id).ToList();
        }
        public Product CheckProductNameExistsInInventory(string productName, int inventoryId)
        {
            var checkProduct = _inventoryContext.Products.Where(x => x.ProductName == productName && x.InventoryId == inventoryId).FirstOrDefault();
            return checkProduct;
        }
        public bool CheckInventoryIdExists(int id)
        {
            var checkInventory = _inventoryContext.Inventories.Where(x => x.InventoryId == id ).FirstOrDefault();
            return checkInventory == null;
        }
        //product repo ka kaam he kya?
    }
}
