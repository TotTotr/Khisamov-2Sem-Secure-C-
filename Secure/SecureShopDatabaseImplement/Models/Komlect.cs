using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecureShopDatabaseImplement.Models
{
    /// <summary>
    /// Изделие, изготавливаемое в магазине
    /// </summary>
    public class Komlect
    {
        public int Id { get; set; }
        [Required]
        public string KomlectName { get; set; }
        [Required]
        public decimal Price { get; set; }

        public virtual List<Order> Orders { get; set; }
        public virtual List<KomlectComponent> KomlectComponents { get; set; }
    }

}
