using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagementSystem.Data;
using InventoryManagementSystem.Exceptions;
using InventoryManagementSystem.Repositories;

namespace InventoryManagementSystem.Controllers
{
    internal class TransactionMenu
    {
        private readonly InventoryContext _inventoryContext;
        private static readonly TransactionRepository _transactionRepository = new TransactionRepository(new InventoryContext());

        public static void DisplayTransactionMenu()
        {
            Console.WriteLine("                           WELCOME TO INVENTORY MANAGEMENT SYSTEM                           \n");
            while (true)
            {
                try
                {
                    Console.WriteLine("............................................................................................");
                    Console.WriteLine("                                   TRANSACTION MANAGEMENT                                      ");
                    Console.WriteLine("............................................................................................");
                    Console.WriteLine("1. Add Stock\n" +
                        "2. Remove Stock\n" +
                        "3. View Transaction History Of A Product\n" +
                        "4. Go Back To Main Menu\n\n" +
                        "Enter your choice: ");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("............................................................................................");
                    DoTransactionTask(choice);
                }
                catch (Exception e) { Console.WriteLine(e.Message); }
            }
        }
        static void DoTransactionTask(int choice)
        {
            switch (choice)
            {
                case 1:
                    AddStock();
                    break;
                case 2:
                    RemoveStock();
                    break;
                case 3:
                    ViewTransactionHistory();
                    break;
                case 4:
                    MainMenu.DisplayMainMenu();
                    break;
                default:
                    Console.WriteLine("Please enter valid input!!\n" +
                        "............................................................................................");
                    break;
            }
        }
        static void AddStock()
        {
            int inventoryId = TakeInventoryId();
            Console.WriteLine("Enter Product Id: ");
            int productId = Convert.ToInt32(Console.ReadLine());
            var product = _transactionRepository.GetProductById(productId, inventoryId);
            if (product == null)
            {
                throw new ProductDoesNotExistException("Product doesn't exist!!\n" +
                    "............................................................................................");
            }
            Console.WriteLine("Enter Quantity to be Added: ");
            int productQuantity = Convert.ToInt32(Console.ReadLine());
            if (productQuantity < 1)
            {
                throw new ProductQuantityCannotBeLessThanOneException("Product Quantity entered should be greater than 1 !!\n" +
                    "............................................................................................");
            }
            _transactionRepository.Add(productId, productQuantity, inventoryId);
            Console.WriteLine("Stock Added Successfully..\n" +
                "............................................................................................");
        }
        static void RemoveStock()
        {
            int inventoryId = TakeInventoryId();

            Console.WriteLine("Enter Product Id: ");
            int productId = Convert.ToInt32(Console.ReadLine());
            var product = _transactionRepository.GetProductById(productId,inventoryId);
            if (product == null)
            {
                throw new ProductDoesNotExistException("Product doesn't exist!!\n" +
                    "............................................................................................");
            }
            Console.WriteLine("Enter Quantity to be Removed: ");
            int productQuantity = Convert.ToInt32(Console.ReadLine());
            if (productQuantity < 1)
            {
                throw new ProductQuantityCannotBeLessThanOneException("Product Quantity entered should be greater than 1 !!\n" +
                    "............................................................................................");
            }
            if (product.Quantity < productQuantity)
            {
                throw new InsufficientProductStockException("Insufficient Product Stock!!\n" +
                    "............................................................................................");
            }
            _transactionRepository.Remove(productId, productQuantity, inventoryId);
            Console.WriteLine("Stock Removed Successfully..\n" +
                "............................................................................................");
        }
        static void ViewTransactionHistory()
        {
            int inventoryId = TakeInventoryId();
            Console.WriteLine("Enter Product Id: ");
            int productId = Convert.ToInt32(Console.ReadLine());
            var transactions = _transactionRepository.ViewHistory(productId,inventoryId);
            Console.WriteLine("............................................................................................\n" +
                "                                    Transaction History                                    \n" +
                "............................................................................................");
            transactions.ForEach(transaction => Console.WriteLine(transaction));
        }
        static int TakeInventoryId()
        {
            Console.WriteLine("Enter Inventory Id: ");
            int inventoryId = Convert.ToInt32(Console.ReadLine());
            if (_transactionRepository.CheckInventoryIdExists(inventoryId))
            {
                throw new InventoryDoesNotExistsException("Inventory with given Id doesn't exist!!\n" +
                "............................................................................................");
            }
            return inventoryId;
        }
    }
}
