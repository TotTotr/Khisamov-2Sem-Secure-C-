
using SecureLogic.Enums;
using SecureShopFileImplement.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace SecureShopFileImplement
    {
        public class FileDataListSingleton
        {
            private static FileDataListSingleton instance;
            private readonly string ComponentFileName = "Component.xml";
            private readonly string OrderFileName = "Order.xml";
            private readonly string KomlectFileName = "Komlect.xml";
            private readonly string ClientFileName = "Client.xml";
            private readonly string ImplementerFileName = "Implementer.xml";
            private readonly string KomlectComponentFileName = "KomlectComponent.xml";
            public List<Component> Components { get; set; }
            public List<Order> Orders { get; set; }
            public List<Komlect> Komlects { get; set; }
            public List<KomlectComponent> KomlectComponents { get; set; }
            public List<Client> Clients { get; set; }
            public List<Implementer> Implementers { get; set; }
        private FileDataListSingleton()
            {
                Components = LoadComponents();
                Orders = LoadOrders();
                Komlects = LoadKomlects();
                KomlectComponents = LoadKomlectComponents();
                Clients = LoadClients();
                Implementers = LoadImplementers();
        }
            public static FileDataListSingleton GetInstance()
            {
                if (instance == null)
                {
                    instance = new FileDataListSingleton();
                }
                return instance;
            }
            ~FileDataListSingleton()
            {
                SaveComponents();
                SaveOrders();
                SaveKomlects();
                SaveKomlectComponents();
            }
            private List<Component> LoadComponents()
            {
                var list = new List<Component>();
                if (File.Exists(ComponentFileName))
                {
                    XDocument xDocument = XDocument.Load(ComponentFileName);
                    var xElements = xDocument.Root.Elements("Component").ToList();
                    foreach (var elem in xElements)
                    {
                        list.Add(new Component
                        {
                            Id = Convert.ToInt32(elem.Attribute("Id").Value),
                            ComponentName = elem.Element("ComponentName").Value
                        });
                    }
                }
                return list;
            }
            private List<Order> LoadOrders()
            {
                var list = new List<Order>();
                if (File.Exists(OrderFileName))
                {
                    XDocument xDocument = XDocument.Load(OrderFileName);
                    var xElements = xDocument.Root.Elements("Order").ToList();
                    foreach (var elem in xElements)
                    {
                        list.Add(new Order
                        {
                            Id = Convert.ToInt32(elem.Attribute("Id").Value),
                            ClientId = Convert.ToInt32(elem.Element("ClientId").Value),
                            KomlectId = Convert.ToInt32(elem.Element("KomlectId").Value),
                            ImplementerId = string.IsNullOrEmpty(elem.Element("ImplementerId").Value) ? (int?)null : Convert.ToInt32(elem.Element("ImplementerId").Value),
                            Count = Convert.ToInt32(elem.Element("Count").Value),
                            Sum = Convert.ToInt32(elem.Element("Sum").Value),
                            Status = (OrderStatus)Enum.Parse(typeof(OrderStatus),
                       elem.Element("Status").Value),
                            DateCreate =
                       Convert.ToDateTime(elem.Element("DateCreate").Value),
                            DateImplement =
                       string.IsNullOrEmpty(elem.Element("DateImplement").Value) ? (DateTime?)null :
                       Convert.ToDateTime(elem.Element("DateImplement").Value),
                        });
                    }
                }
                return list;
            }
            private List<Komlect> LoadKomlects()
            {
                var list = new List<Komlect>();
                if (File.Exists(KomlectFileName))
                {
                    XDocument xDocument = XDocument.Load(KomlectFileName);
                    var xElements = xDocument.Root.Elements("Komlect").ToList();
                    foreach (var elem in xElements)
                    {
                        list.Add(new Komlect
                        {
                            Id = Convert.ToInt32(elem.Attribute("Id").Value),
                            KomlectName = elem.Element("KomlectName").Value,
                            Price = Convert.ToInt32(elem.Element("Price").Value)
                        });
                    }
                }
                return list;
            }
            private List<KomlectComponent> LoadKomlectComponents()
            {
                var list = new List<KomlectComponent>();
                if (File.Exists(KomlectComponentFileName))
                {
                    XDocument xDocument = XDocument.Load(KomlectComponentFileName);
                    var xElements = xDocument.Root.Elements("KomlectComponent").ToList();
                    foreach (var elem in xElements)
                    {
                        list.Add(new KomlectComponent
                        {
                            Id = Convert.ToInt32(elem.Attribute("Id").Value),
                            KomlectId = Convert.ToInt32(elem.Element("KomlectId").Value),
                            ComponentId = Convert.ToInt32(elem.Element("ComponentId").Value),
                            Count = Convert.ToInt32(elem.Element("Count").Value)
                        });
                    }
                }
                return list;
            }
        private List<Client> LoadClients()
        {
            var list = new List<Client>();
            if (File.Exists(ClientFileName))
            {
                XDocument xDocument = XDocument.Load(ClientFileName);
                var xElements = xDocument.Root.Elements("Client").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Client
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        ClientFIO = elem.Element("ClientFIO").Value,
                        Email = elem.Element("Email").Value,
                        Password = elem.Element("Password").Value
                    });
                }
            }
            return list;
        }
        private List<Implementer> LoadImplementers()
        {
            var list = new List<Implementer>();

            if (File.Exists(ImplementerFileName))
            {
                XDocument xDocument = XDocument.Load(ImplementerFileName);
                var xElements = xDocument.Root.Elements("Implementer").ToList();

                foreach (var elem in xElements)
                {
                    list.Add(new Implementer
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        ImplementerFIO = elem.Element("ImplementerFIO").Value,
                        WorkingTime = Convert.ToInt32(elem.Element("WorkingTime").Value),
                        PauseTime = Convert.ToInt32(elem.Element("PauseTime").Value)
                    });
                }
            }

            return list;
        }
        private void SaveComponents()
            {
                if (Components != null)
                {
                    var xElement = new XElement("Components");
                    foreach (var component in Components)
                    {
                        xElement.Add(new XElement("Component",
                        new XAttribute("Id", component.Id),
                        new XElement("ComponentName", component.ComponentName)));
                    }
                    XDocument xDocument = new XDocument(xElement);
                    xDocument.Save(ComponentFileName);
                }
            }
            private void SaveOrders()
            {
                if (Orders != null)
                {
                    var xElement = new XElement("Orders");
                    foreach (var order in Orders)
                    {
                        xElement.Add(new XElement("Order",
                        new XAttribute("Id", order.Id),
                        new XElement("ClientId", order.ClientId),
                        new XElement("KomlectId", order.KomlectId),
                        new XElement("ImplementerId", order.ImplementerId),
                        new XElement("Count", order.Count),
                        new XElement("Sum", order.Sum),
                        new XElement("Status", order.Status),
                        new XElement("DateCreate", order.DateCreate),
                        new XElement("DateImplement", order.DateImplement)));
                    }
                    XDocument xDocument = new XDocument(xElement);
                    xDocument.Save(OrderFileName);
                }
            }
            private void SaveKomlects()
            {
                if (Komlects != null)
                {
                    var xElement = new XElement("Komlects");
                    foreach (var Komlect in Komlects)
                    {
                        xElement.Add(new XElement("Komlect",
                        new XAttribute("Id", Komlect.Id),
                        new XElement("KomlectName", Komlect.KomlectName),
                        new XElement("Price", Komlect.Price)));
                    }
                    XDocument xDocument = new XDocument(xElement);
                    xDocument.Save(KomlectFileName);
                }
            }
            private void SaveKomlectComponents()
            {
                if (KomlectComponents != null)
                {
                    var xElement = new XElement("KomlectComponents");
                    foreach (var KomlectComponent in KomlectComponents)
                    {
                        xElement.Add(new XElement("KomlectComponent",
                        new XAttribute("Id", KomlectComponent.Id),
                        new XElement("KomlectId", KomlectComponent.KomlectId),
                        new XElement("ComponentId", KomlectComponent.ComponentId),
                        new XElement("Count", KomlectComponent.Count)));
                    }
                    XDocument xDocument = new XDocument(xElement);
                    xDocument.Save(KomlectComponentFileName);
                }
            }
        private void SaveClients()
        {
            if (Clients != null)
            {
                var xElement = new XElement("Clients");
                foreach (var client in Clients)
                {
                    xElement.Add(new XElement("Client",
                    new XAttribute("Id", client.Id),
                    new XElement("ClientFIO", client.ClientFIO),
                    new XElement("Email", client.Email),
                    new XElement("Password", client.Password)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(ClientFileName);
            }
        }
        private void SaveImplementers()
        {
            if (Implementers != null)
            {
                var xElement = new XElement("Implementers");

                foreach (var implementer in Implementers)
                {
                    xElement.Add(new XElement("Implementer",
                    new XAttribute("Id", implementer.Id),
                    new XElement("ImplementerFIO", implementer.ImplementerFIO),
                    new XElement("WorkingTime", implementer.WorkingTime),
                    new XElement("PauseTime", implementer.PauseTime)));
                }

                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(ImplementerFileName);
            }
        }
    }
}