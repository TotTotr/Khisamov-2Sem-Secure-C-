using System;
using System.Collections.Generic;
using System.Text;

namespace SecuretListImplement.Models
{
    /// <summary>
    /// Изделие, изготавливаемое в магазине
    /// </summary>
    public class Komlect
    {
        public int Id { get; set; }
        public string KomlectName { get; set; }
        public decimal Price { get; set; }
    }

}
