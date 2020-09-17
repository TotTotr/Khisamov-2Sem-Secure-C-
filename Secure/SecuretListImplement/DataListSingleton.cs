using SecuretListImplement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecuretListImplement
{
    public class DataListSingleton
    {
        private static DataListSingleton instance;
        public List<Component> Components { get; set; }
        public List<Order> Orders { get; set; }
        public List<Komlect> Komlects { get; set; }
        public List<KomlectComponent> KomlectComponents { get; set; }
        public List<Client> Clients { get; set; }
        public List<Implementer> Implementers { get; set; }
        public List<MessageInfo> MessageInfoes { get; set; }
        private DataListSingleton()
        {
            Components = new List<Component>();
            Orders = new List<Order>();
            Komlects = new List<Komlect>();
            KomlectComponents = new List<KomlectComponent>();
            Clients = new List<Client>();
            Implementers = new List<Implementer>();
            MessageInfoes = new List<MessageInfo>();
        }
        public static DataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new DataListSingleton();
            }
            return instance;
        }
    }
}
