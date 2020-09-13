using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SecureLogic.ViewModels
{
    /// Изделие, изготавливаемое в магазине   
    public class KomlectViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название изделия")]
        public string KomlectName { get; set; }
        [DisplayName("Цена")]
        public decimal Price { get; set; }
        public Dictionary<int, (string, int)> KomlectComponents { get; set; }
    }
}
