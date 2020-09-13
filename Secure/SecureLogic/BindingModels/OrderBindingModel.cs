using System;
using SecureLogic.Enums;
using System.Collections.Generic;
using System.Text;


namespace SecureLogic.BindingModels
{
    /// Заказ     
    public class OrderBindingModel
    {
        public int? Id { get; set; }
        public int? ClientId { get; set; }
        public int KomlectId { get; set; }
        public int? ImplementerId { get; set; }
        public int Count { get; set; }
        public int Sum { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime? DateImplement { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public bool? FreeOrders { get; set; }
    }
}
