using SecureLogic.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecureLogic.ViewModels
{
    public class ReportOrdersViewModel
    {
        public DateTime DateCreate { get; set; }
        public string KomlectName { get; set; }
        public int Count { get; set; }
        public int Sum { get; set; }
        public OrderStatus Status { get; set; }
    }
}
