using System;
using System.Collections.Generic;
using System.Text;

namespace SecuretListImplement.Models
{
    /// <summary>
    /// Сколько компонентов, требуется при изготовлении изделия
    /// </summary>
    public class KomlectComponent
    {
        public int Id { get; set; }
        public int KomlectId { get; set; }
        public int ComponentId { get; set; }
        public int Count { get; set; }
    }
}
