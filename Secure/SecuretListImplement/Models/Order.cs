using SecureLogic.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecuretListImplement.Models
{
    /// Заказ
    /// </summary>
    public class Order
    {
        public int Id { get; set; }
        public int KomlectId { get; set; }
        public int ClientId { set; get; }
        public int ImplementerId { get; set; }
        public int Count { get; set; }
        public int Sum { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime? DateImplement { get; set; }
    }
}
