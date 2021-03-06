﻿using SecureLogic.BindingModels;
using SecureLogic.Interfaces;
using SecureLogic.ViewModels;
using SecuretListImplement.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SecuretListImplement.Implements
{
    class ClientLogic : IClientLogic
    {
        private readonly DataListSingleton source;
        public ClientLogic()
        {
            source = DataListSingleton.GetInstance();
        }

        public void CreateOrUpdate(ClientBindingModel model)
        {
            Client tempClient = model.Id.HasValue ? null : new Client
            {
                Id = 1
            };
            foreach (var Client in source.Clients)
            {
                if (Client.Email == model.Email && Client.Id != model.Id)
                {
                    throw new Exception("Уже есть клиент с таким логином");
                }
                if (!model.Id.HasValue && Client.Id >= tempClient.Id)
                {
                    tempClient.Id = Client.Id + 1;
                }
                else if (model.Id.HasValue && Client.Id == model.Id)
                {
                    tempClient = Client;
                }
            }
            if (model.Id.HasValue)
            {
                if (tempClient == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, tempClient);
            }
            else
            {
                source.Clients.Add(CreateModel(model, tempClient));
            }

        }

        public void Delete(ClientBindingModel model)
        {
            for (int i = 0; i < source.Clients.Count; ++i)
            {
                if (source.Clients[i].Id == model.Id)
                {
                    source.Clients.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }

        public List<ClientViewModel> Read(ClientBindingModel model)
        {
            List<ClientViewModel> result = new List<ClientViewModel>();
            foreach (var client in source.Clients)
            {
                if (model != null)
                {
                    if (model.Id.HasValue)
                    {
                        if (client.Id == model.Id)
                        {
                            result.Add(CreateViewModel(client));
                            break;
                        }
                    }
                    else if (client.Email == model.Email && client.Password == model.Password)
                    {
                        result.Add(CreateViewModel(client));
                        break;
                    }
                    continue;
                }
                result.Add(CreateViewModel(client));
            }
            return result;
        }


        private Client CreateModel(ClientBindingModel model, Client client)
        {
            client.ClientFIO = model.ClientFIO;
            client.Email = model.Email;
            client.Password = model.Password;
            return client;
        }
        private ClientViewModel CreateViewModel(Client client)
        {
            return new ClientViewModel
            {
                Id = client.Id,
                ClientFIO = client.ClientFIO,
                Email = client.Email,
                Password = client.Password
            };
        }
    }
}
