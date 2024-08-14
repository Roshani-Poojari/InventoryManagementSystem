using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Models
{
    internal class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public List<Transaction> Transactions { get; set; }
        public Inventory Inventory { get; set; }

        [ForeignKey("Inventory")]
        public int? InventoryId { get; set; }

        public override string ToString()
        {
            return $"Inventory Id: {InventoryId}\n" +
                $"Product Id: {ProductId}\n" +
                $"Name: {ProductName}\n" +
                $"Description: {Description}\n" +
                $"Quantity: {Quantity}\n" +
                $"Price: {Price}\n";
        }
    }
}
