using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Controllers
{
    internal class MainMenu
    {
        public static void DisplayMainMenu()
        {
            Console.WriteLine("                           WELCOME TO INVENTORY MANAGEMENT SYSTEM                           \n");
            while (true)
            {
                try
                {
                    Console.WriteLine("............................................................................................");
                    Console.WriteLine("1. Product Management\n" +
                        "2. Supplier Management\n" +
                        "3. Transaction Management\n" +
                        "4. Generate Report\n" +
                        "5. Exit\n\n" +
                        "Enter your choice: ");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("............................................................................................");

                    ChooseManagement(choice);
                }
                catch (Exception e) { Console.WriteLine(e.Message); }
            }
        }
        static void ChooseManagement(int choice)
        {
            switch (choice)
            {
                case 1:
                    ProductMenu.DisplayProductMenu();
                    break;
                case 2:
                    SupplierMenu.DisplaySupplierMenu();
                    break;
                case 3:
                    TransactionMenu.DisplayTransactionMenu();
                    break;
                case 4:
                    ReportMenu.DisplayGeneratedReport();
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Please enter valid input!!\n" +
                        "............................................................................................");
                    break;
            }
        }
    }
}
/*
 Menu Example ->

Welcome to the Inventory Management System
1. Product Management
2. Supplier Management
3. Transaction Management
4. Generate Report
5. Exit
Enter your choice:1

submenu :1
1 Add Product
  Accept details from user and add
  constraint: check existing productName
2 Update Product
  constraint: check product exists?
      b4 update, check product name is duplicate
    do not update quantity 
3 Delete Product
  constraint: check product exists?
4 View Product's Details
  GetById / GetByName
5 View All Products
  GetAllProducts
6 Go Back Main Menu
Enter your choice:

submenu : 2 (same constraints but with suppliers instead of products)
1 Add Supplier
2 Update Supplier
3 Delete Supplier
4 View Supplier's Details
5 View All Suppliers
6 Go Back Main Menu
Enter your choice:

submenu:3 DONEEEEEEE
1 Add Stock (product table)
  constraint: check product exists
  update quantity (+) of the product-->only quantity will be updated
  add record transaction table
2 Remove Stock
  constraint: check product exists
  update quantity (-) of the product-->only quantity will be updated
  add record transaction table
3 View Transaction History
  GetAllTransactions
4 Go Back Main Menu


Main Menu
4 Generate Report:
  Inventory Details
  List Products
  List Suppliers
  List Transactions
 */