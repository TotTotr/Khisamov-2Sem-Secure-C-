using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace SecureLogic.ViewModels
{
    /// Изделие, изготавливаемое в магазине   
    [DataContract]
    public class KomlectViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DisplayName("Название изделия")]
        [DataMember]
        public string KomlectName { get; set; }
        [DisplayName("Цена")]
        [DataMember]
        public int Price { get; set; }
        [DataMember]
        public Dictionary<int, (string, int)> KomlectComponents { get; set; }
    }
}
