using InventoryManagementSystem.Controllers;

namespace InventoryManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //MainMenu.DisplayMainMenu();
            try
            {
                MainMenu.DisplayMainMenu();
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }
    }
}
/*
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
        */