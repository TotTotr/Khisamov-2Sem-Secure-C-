using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;


namespace SecureLogic.BindingModels
{
    [DataContract]
    public class CreateOrderBindingModel
    {
        [DataMember]
        public int KomlectId { get; set; }
        [DataMember]
        public int Count { get; set; }
        [DataMember]
        public int ClientId { get; set; }
        [DataMember]
        public int Sum { get; set; }
    }
}
