using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    internal class ProductMenu
    {
        private static readonly ProductRepository _productRepository = new ProductRepository(new InventoryContext());
        public static void DisplayProductMenu()
        {
            Console.WriteLine("                           WELCOME TO INVENTORY MANAGEMENT SYSTEM                           \n");
            while (true)
            {
                try
                {
                    Console.WriteLine("............................................................................................");
                    Console.WriteLine("                                     PRODUCT MANAGEMENT                                     ");
                    Console.WriteLine("............................................................................................");
                    Console.WriteLine("1. Add Product\n" +
                        "2. Update Product\n" +
                        "3. Delete Product\n" +
                        "4. View A Product\n" +
                        "5. View All Products\n" +
                        "6. Go Back To Main Menu\n\n" +
                        "Enter your choice: ");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("............................................................................................");
                    DoProductTask(choice);
                }
                catch (Exception e) { Console.WriteLine(e.Message); }
            }
        }
        static void DoProductTask(int choice)
        {
            switch (choice)
            {
                case 1:
                    AddProduct();
                    break;
                case 2:
                    UpdateProduct();
                    break;
                case 3:
                    DeleteProduct();
                    break;
                case 4:
                    ViewProduct();
                    break;
                case 5:
                    ViewAllProducts();
                    break;
                case 6:
                    MainMenu.DisplayMainMenu();
                    break;
                default:
                    Console.WriteLine("Please enter valid input!!\n" +
                        "............................................................................................");
                    break;
            }
        }
        static void AddProduct()
        {
            int inventoryId = TakeInventoryId();
            Console.WriteLine("Enter Product Name: ");
            string productName = Console.ReadLine();
            if (_productRepository.CheckProductNameExistsInInventory(productName, inventoryId) != null)
            {
                throw new ProductNameAlreadyExistsException("Product with the given name already exists in the Inventory!!\n" +
                "............................................................................................");
            }
            Console.WriteLine("Enter Product Description: ");
            string productDescription = Console.ReadLine();
            Console.WriteLine("Enter Product Quantity: ");
            int productQuantity = Convert.ToInt32(Console.ReadLine());
            if (productQuantity < 1)
            {
                throw new ProductQuantityCannotBeLessThanOneException("Product Quantity entered should be greater than 1 !!\n" +
                   "............................................................................................");
            }
            Console.WriteLine("Enter Product Price: ");
            double productPrice = Convert.ToDouble(Console.ReadLine());
            if (productPrice < 1)
            {
                throw new ProductPriceCannotBeLessThanOneException("Product Price entered should be greater than 1 !!\n" +
                   "............................................................................................");
            }
            _productRepository.Add(new Product() { ProductName = productName, Description = productDescription, Quantity = productQuantity, Price = productPrice, InventoryId = inventoryId });
            Console.WriteLine("New Product Added Successfully..\n" +
                "............................................................................................");


        }

        static void UpdateProduct()
        {
            int inventoryId = TakeInventoryId();
            Console.WriteLine("Enter the Current Product Name: ");
            string currentName = Console.ReadLine();
            var existingProduct = _productRepository.CheckProductNameExistsInInventory(currentName, inventoryId);
            if (existingProduct == null)
            {
                throw new ProductDoesNotExistException("Product with given Current Name doesn't exist in the Inventory!!\n" +
                    "............................................................................................");
            }
            Console.WriteLine("Enter the New Product Name: ");
            string newName = Console.ReadLine();
            if (_productRepository.CheckProductNameExistsInInventory(newName, inventoryId) != null)
            {
                throw new ProductNameAlreadyExistsException("Product with the given New Name already exists in the Inventory!!\n" +
                "............................................................................................");
            }
            Console.WriteLine("Enter the New Product Description: ");
            string newDescription = Console.ReadLine();
            Console.WriteLine("Enter the New Product Price: ");
            int newPrice = Convert.ToInt32(Console.ReadLine());
            if (newPrice < 1)
            {
                throw new ProductPriceCannotBeLessThanOneException("Product Price entered should be greater than 1 !!\n" +
                   "............................................................................................");
            }
            existingProduct.ProductName = newName;
            existingProduct.Description = newDescription;
            existingProduct.Price = newPrice;
            _productRepository.Update(existingProduct);
            Console.WriteLine("Product Name Updated Successfully..\n" +
                "............................................................................................");
        }
        static void DeleteProduct()
        {
            int inventoryId = TakeInventoryId();
            Console.WriteLine("Enter Product Name: ");
            string productName = Console.ReadLine();
            var existingProduct = _productRepository.CheckProductNameExistsInInventory(productName, inventoryId);
            if (existingProduct == null)
            {
                throw new ProductDoesNotExistException("Product with given Name doesn't exist in the Inventory!!\n" +
                    "............................................................................................");
            }
            _productRepository.Delete(existingProduct);
            Console.WriteLine("Product Deleted Successfully..\n" +
                "............................................................................................");
        }
        static void ViewProduct()
        {
            int inventoryId = TakeInventoryId();
            Console.WriteLine("Enter Product Name: \n");
            string productName = Console.ReadLine();
            var existingProduct = _productRepository.CheckProductNameExistsInInventory(productName, inventoryId);
            if (existingProduct == null)
            {
                throw new ProductDoesNotExistException("Product with given Name doesn't exist in the Inventory!!\n" +
                    "............................................................................................");
            }
            Console.WriteLine(existingProduct);
            Console.WriteLine("............................................................................................");

        }
        static void ViewAllProducts()
        {
            int inventoryId = TakeInventoryId();
            var products = _productRepository.GetAll(inventoryId);
            if (products.Count == 0)
            {
                throw new ProductDoesNotExistException("No products found in the Inventory!!\n" +
                    "............................................................................................");
            }
            Console.WriteLine("                                         Products List                                         \n" +
                "............................................................................................");
            products.ForEach(product => Console.WriteLine(product));
            Console.WriteLine("............................................................................................");

        }
        static int TakeInventoryId()
        {
            Console.WriteLine("Enter Inventory Id: ");
            int inventoryId = Convert.ToInt32(Console.ReadLine());
            if (_productRepository.CheckInventoryIdExists(inventoryId))
            {
                throw new InventoryDoesNotExistsException("Inventory with given Id doesn't exist!!\n" +
                "............................................................................................");
            }
            return inventoryId;
        }
    }
}
