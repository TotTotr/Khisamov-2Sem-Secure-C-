﻿using SecureLogic.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace SecureLogic.ViewModels
{
    /// Заказ 
    public class OrderViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int ClientId { get; set; }
        [DataMember]
        public int KomlectId { get; set; }

        [DataMember]
        [DisplayName("Клиент")]
        public string ClientFIO { get; set; }

        [DataMember]
        [DisplayName("Изделие")] public string KomlectName { get; set; }

        [DataMember]
        [DisplayName("Количество")] public int Count { get; set; }

        [DataMember]
        [DisplayName("Сумма")] public int Sum { get; set; }

        [DataMember]
        [DisplayName("Статус")] public OrderStatus Status { get; set; }

        [DataMember]
        [DisplayName("Дата создания")] public DateTime DateCreate { get; set; }

        [DataMember]
        [DisplayName("Дата выполнения")] public DateTime? DateImplement { get; set; }
    }
}
