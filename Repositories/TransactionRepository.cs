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
    internal class TransactionRepository
    {
        private readonly InventoryContext _inventoryContext;
        public TransactionRepository(InventoryContext inventoryContext)
        {
            _inventoryContext = inventoryContext;
        }
        public void Add(int id, int quantity, int inventoryId)
        {
            var product = GetProductById(id, inventoryId);
            product.Quantity += quantity;
            var transaction = new Transaction
            {
                ProductId = id,
                Type = "Add Stock",
                Quantity = quantity,
                Date = DateOnly.FromDateTime(DateTime.Now),
                InventoryId = inventoryId
            };
            _inventoryContext.Transactions.Add(transaction);
            _inventoryContext.SaveChanges();
        }
        public void Remove(int id, int quantity, int inventoryId)
        {
            var product = GetProductById(id, inventoryId);
            product.Quantity -= quantity;
            var transaction = new Transaction
            {
                ProductId = id,
                Type = "Remove Stock",
                Quantity = quantity,
                Date = DateOnly.FromDateTime(DateTime.Now),
                InventoryId = inventoryId
            };
            _inventoryContext.Transactions.Add(transaction);
            _inventoryContext.SaveChanges();
        }
        public List<Transaction> ViewHistory(int id, int inventoryId)
        {
            var product = _inventoryContext.Products.Find(id);
            if (product == null)
            {
                throw new ProductDoesNotExistException("Product doesn't exist!!\n" +
                    "............................................................................................");
            }
            var transactions = _inventoryContext.Transactions.Where(t => t.ProductId == id && t.InventoryId == inventoryId).OrderBy(t => t.Date).ToList();
            if (transactions.Count == 0)
            {
                throw new NoTransactionFoundException("No transactions found!!\n" +
                    "............................................................................................");
            }
            return transactions;
        }
        /*public List<Transaction> GetAll()
        {            
            return _inventoryContext.Transactions.OrderBy(t => t.Date).ToList();
        }*/
        public Product GetProductById(int id, int inventoryId)
        {
            return _inventoryContext.Products.Where(x=>x.ProductId==id && x.InventoryId == inventoryId).FirstOrDefault();
        }
        public bool CheckInventoryIdExists(int id)
        {
            var checkInventory = _inventoryContext.Inventories.Where(x => x.InventoryId == id).FirstOrDefault();
            return checkInventory == null;
        }
        //transaction repo ka kaam he kya?
    }
}
