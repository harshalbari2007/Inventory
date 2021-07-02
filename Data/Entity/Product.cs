using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Entity
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [StringLength(256)]
        public string ProductName { get; set; }
        [StringLength(1000)]
        public string ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
