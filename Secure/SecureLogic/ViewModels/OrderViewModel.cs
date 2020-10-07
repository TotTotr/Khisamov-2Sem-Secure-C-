using SecureLogic.Attributes;
using SecureLogic.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace SecureLogic.ViewModels
{
    /// Заказ 
    public class OrderViewModel : BaseViewModel
    {
        [DataMember]
        public int ClientId { get; set; }
        [DataMember]
        public int KomlectId { get; set; }

        [DataMember]
        public int? ImplementerId { get; set; }
        [DataMember]
        [Column(title: "Исполнитель", width: 100)]
        public string ImplementerFIO { get; set; }

        [DataMember]
        [Column(title: "Клиент", width: 150)]
        public string ClientFIO { get; set; }

        [DataMember]
        [Column(title: "Изделие", width: 100)]
        public string KomlectName { get; set; }

        [DataMember]
        [Column(title: "Количество", width: 100)]
        public int Count { get; set; }

        [DataMember]
        [Column(title: "Сумма", width: 50)]
        public int Sum { get; set; }

        [DataMember]
        [Column(title: "Статус", width: 100)]
        public OrderStatus Status { get; set; }

        [DataMember]

        [Column(title: "Дата создания", width: 100)]
        [DisplayName("Дата создания")] public DateTime DateCreate { get; set; }

        [DataMember]
        [Column(title: "Дата выполнения", width: 100)]
        [DisplayName("Дата выполнения")] public DateTime? DateImplement { get; set; }
        public override List<string> Properties() => new List<string>
        {
            "Id",
            "ClientFIO",
            "KomlectName",
            "ImplementerFIO",
            "Count",
            "Sum",
            "Status",
            "DateCreate",
            "DateImplement"
        };
    }
}
