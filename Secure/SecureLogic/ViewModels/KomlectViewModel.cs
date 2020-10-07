using SecureLogic.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace SecureLogic.ViewModels
{
    /// Изделие, изготавливаемое в магазине   
    [DataContract]
    public class KomlectViewModel : BaseViewModel
    {       
        [Column(title: "Название изделия", gridViewAutoSize: GridViewAutoSize.Fill)]
        [DataMember]
        public string KomlectName { get; set; }
      
        [Column(title: "Цена", width: 50)]
        [DataMember]
        public int Price { get; set; }
        [DataMember]
        public Dictionary<int, (string, int)> KomlectComponents { get; set; }
        public override List<string> Properties() => new List<string>
        {
            "Id",
            "KomlectName",
            "Price"
        };
    }
}
