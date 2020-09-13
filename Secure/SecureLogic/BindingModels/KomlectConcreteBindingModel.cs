using System;
using System.Collections.Generic;
using System.Text;

namespace SecureLogic.BindingModels
{
    /// Изделие, изготавливаемое в магазине 
    public class KomlectConcreteBindingModel
    {
        public int? Id { get; set; }

        public string KomlectName { get; set; }

        public decimal Price { get; set; }

        public Dictionary<int, (string, int)> KomlectComponents { get; set; }
    }
}
