﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Models
{
    internal class Supplier
    {
        [Key]
        public int SupplierId { get; set; }
        public string Name { get; set; }
        public string ContactInformation { get; set; }
        public Inventory Inventory { get; set; }

        [ForeignKey("Inventory")]
        public int? InventoryId { get; set; }
        public override string ToString()
        {
            return $"Inventory Id: {InventoryId}\n" +
                $"Supplier Id: {SupplierId}\n" +
                $"Name: {Name}\n" +
                $"Contact Info: {ContactInformation}\n";
        }
    }
}
