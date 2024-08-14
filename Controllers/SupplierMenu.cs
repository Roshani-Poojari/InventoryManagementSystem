using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagementSystem.Data;
using InventoryManagementSystem.Exceptions;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.Repositories;

namespace InventoryManagementSystem.Controllers
{
    internal class SupplierMenu
    {
        private static readonly SupplierRepository _supplierRepository = new SupplierRepository(new InventoryContext());
        public static void DisplaySupplierMenu()
        {
            Console.WriteLine("                           WELCOME TO INVENTORY MANAGEMENT SYSTEM                           \n");
            while (true)
            {
                try
                {
                    Console.WriteLine("............................................................................................");
                    Console.WriteLine("                                      SUPPLIER MANAGEMENT                                      ");
                    Console.WriteLine("............................................................................................");
                    Console.WriteLine("1. Add Supplier\n" +
                        "2. Update Supplier\n" +
                        "3. Delete Supplier\n" +
                        "4. View A Supplier\n" +
                        "5. View All Suppliers\n" +
                        "6. Go Back To Main Menu\n\n" +
                        "Enter your choice: ");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("............................................................................................");
                    DoSupplierTask(choice);
                }
                catch (Exception e) { Console.WriteLine(e.Message); }
            }
        }
        static void DoSupplierTask(int choice)
        {
            switch (choice)
            {
                case 1:
                    AddSupplier();
                    break;
                case 2:
                    UpdateSupplier();
                    break;
                case 3:
                    DeleteSupplier();
                    break;
                case 4:
                    ViewSupplier();
                    break;
                case 5:
                    ViewAllSuppliers();
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
        static void AddSupplier()
        {
            int inventoryId = TakeInventoryId();
            Console.WriteLine("Enter Supplier's Name: ");
            string supplierName = Console.ReadLine();
            if (_supplierRepository.CheckSupplierNameExistsInInventory(supplierName, inventoryId) != null)
            {
                throw new SupplierNameAlreadyExistsException("Supplier with the given name already exists in the inventory!!\n" +
               "............................................................................................");
            }
            Console.WriteLine("Enter Supplier's Contact Information: ");
            string supplierContactInfo = Console.ReadLine();
            _supplierRepository.Add(new Supplier() { Name = supplierName, ContactInformation = supplierContactInfo, InventoryId = inventoryId });
            Console.WriteLine("New Supplier Added Successfully..\n" +
                "............................................................................................");
        }
        static void UpdateSupplier()
        {
            int inventoryId = TakeInventoryId();
            Console.WriteLine("Enter the Current Supplier's Name: ");
            string currentName = Console.ReadLine();
            var existingSupplier = _supplierRepository.CheckSupplierNameExistsInInventory(currentName, inventoryId);
            if (existingSupplier == null)
            {
                throw new SupplierDoesNotExistException("Supplier with given Current Name doesn't exist in the inventory!!\n" +
                    "............................................................................................");
            }
            Console.WriteLine("Enter the Supplier's New Name: ");
            string newName = Console.ReadLine();
            if (_supplierRepository.CheckSupplierNameExistsInInventory(newName, inventoryId) != null)
            {
                throw new SupplierNameAlreadyExistsException("Supplier with the New Name already exists in the inventory!!\n" +
                    "............................................................................................");
            }
            Console.WriteLine("Enter the Supplier's New Contact Information: ");
            string newContact = Console.ReadLine();
            existingSupplier.Name = newName;
            existingSupplier.ContactInformation = newContact;
            _supplierRepository.Update(existingSupplier);
            Console.WriteLine("Supplier Name Updated Successfully..\n" +
                "............................................................................................");
        }
        static void DeleteSupplier()
        {
            int inventoryId = TakeInventoryId();
            Console.WriteLine("Enter Supplier's Name: ");
            string supplierName = Console.ReadLine();
            var existingSupplier = _supplierRepository.CheckSupplierNameExistsInInventory(supplierName,inventoryId);
            if (existingSupplier == null)
            {
                throw new SupplierDoesNotExistException("Supplier with given Name doesn't exist in the inventory!!\n" +
                    "............................................................................................");
            }
            _supplierRepository.Delete(existingSupplier);
            Console.WriteLine("Supplier Deleted Successfully..\n" +
                "............................................................................................");
        }
        static void ViewSupplier()
        {
            int inventoryId = TakeInventoryId();
            Console.WriteLine("Enter Supplier's Name: \n");
            string supplierName = Console.ReadLine();
            var existingSupplier = _supplierRepository.CheckSupplierNameExistsInInventory(supplierName,inventoryId);
            if (existingSupplier == null)
            {
                throw new SupplierDoesNotExistException("Supplier with given Name doesn't exist in the inventory!!\n" +
                    "............................................................................................");
            }
            Console.WriteLine(existingSupplier);
            Console.WriteLine("............................................................................................");

        }
        static void ViewAllSuppliers()
        {
            int inventoryId = TakeInventoryId();
            var suppliers = _supplierRepository.GetAll(inventoryId);
            if (suppliers.Count == 0)
            {
                throw new SupplierDoesNotExistException("No suppliers found in the inventory!!\n" +
                    "............................................................................................");
            }
            Console.WriteLine("                                         Suppliers List                                         \n" +
                "............................................................................................");
            suppliers.ForEach(supplier => Console.WriteLine(supplier));
            Console.WriteLine("............................................................................................");

        }
        static int TakeInventoryId()
        {
            Console.WriteLine("Enter Inventory Id: ");
            int inventoryId = Convert.ToInt32(Console.ReadLine());
            if (_supplierRepository.CheckInventoryIdExists(inventoryId))
            {
                throw new InventoryDoesNotExistsException("Inventory with given Id doesn't exist!!\n" +
                "............................................................................................");
            }
            return inventoryId;
        }
    }
}
