using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using InventoryManagementSystem.Data;
using InventoryManagementSystem.Exceptions;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.Repositories;

namespace InventoryManagementSystem.Controllers
{
    internal class ReportMenu
    {
        private static readonly InventoryRepository _inventoryRepository = new InventoryRepository(new InventoryContext());

        public static void DisplayGeneratedReport()
        {
            Console.WriteLine("                                     INVENTORY LIST\n" +
                             "............................................................................................\n");
            var inventories = _inventoryRepository.GetAll();
            if (inventories.Count == 0)
            {
                Console.WriteLine("No Inventories Found\n");
            }
            else
            {
                inventories.ForEach(inventory =>
                {
                    Console.WriteLine(inventory);
                    Console.WriteLine("                                    List of Products\n" +
                                  "............................................................................................");
                    var products = inventory.Products;
                    if (products.Count == 0)
                    {
                        Console.WriteLine("No Products Found\n");
                    }
                    else
                    {
                        products.ForEach(product => Console.WriteLine(product));
                    }
                    Console.WriteLine("............................................................................................\n" +
                              "                                    List of Suppliers\n" +
                              "............................................................................................");
                    var suppliers = inventory.Suppliers;
                    if (suppliers.Count == 0)
                    {
                        Console.WriteLine("No Suppliers Found\n");
                    }
                    else
                    {
                        suppliers.ForEach(supplier => Console.WriteLine(supplier));
                    }
                    Console.WriteLine("............................................................................................\n" +
                              "                                   List of Transactions\n" +
                              "............................................................................................");
                    var transactions = inventory.Transactions;
                    if (transactions.Count == 0)
                    {
                        Console.WriteLine("No Transactions Found\n");
                    }
                    else
                    {
                        transactions.ForEach(transaction => Console.WriteLine(transaction));
                    }
                    Console.WriteLine("............................................................................................\n");

                }
                );
            }
            MainMenu.DisplayMainMenu();           
        }
    }
}
