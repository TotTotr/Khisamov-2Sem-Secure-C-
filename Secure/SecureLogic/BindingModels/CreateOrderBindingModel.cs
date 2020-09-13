using System;
using System.Collections.Generic;
using System.Text;

namespace SecureLogic.BindingModels
{
    public class CreateOrderBindingModel
    {
        public int KomlectId { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
    }
}
