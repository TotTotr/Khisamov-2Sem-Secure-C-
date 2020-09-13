using SecureLogic.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace SecureShopDatabaseImplement.Models
{
    /// Заказ
    /// </summary>
    public class Order
    {
        public int Id { get; set; }
        public int KomlectId { get; set; }
        public int ClientId { get; set; }
        [Required]
        public int Count { get; set; }
        [Required]
        public int Sum { get; set; }
        [Required]
        public OrderStatus Status { get; set; }
        [Required]
        public DateTime DateCreate { get; set; }
        public DateTime? DateImplement { get; set; }
        public virtual Komlect Komlect { get; set; }
        public virtual Client Client { get; set; }
    }
}
