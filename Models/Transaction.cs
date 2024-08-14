using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Models
{
    internal class Transaction
    {
        [Key]
        public int TransactionId { get; set; }
        public Product Product { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }
        public DateOnly Date { get; set; }
        public Inventory Inventory { get; set; }

        [ForeignKey("Inventory")]
        public int? InventoryId { get; set; }
        public override string ToString()
        {
            return $"Inventory Id: {InventoryId}\n" +
                $"Transaction Id: {TransactionId}\n" +
                $"Product Id: {ProductId}\n" +
                $"Transaction Type: {Type}\n" +
                $"Quantity: {Quantity}\n" +
                $"Date: {Date}\n";
        }
    }
}
