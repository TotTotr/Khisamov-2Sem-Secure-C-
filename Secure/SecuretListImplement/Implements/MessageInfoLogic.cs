using SecureLogic.BindingModels;
using SecureLogic.Interfaces;
using SecureLogic.ViewModels;
using SecuretListImplement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecuretListImplement.Implements
{
    public class MessageInfoLogic : IMessageInfoLogic
    {
        private readonly DataListSingleton source;

        public MessageInfoLogic()
        {
            source = DataListSingleton.GetInstance();
        }

        public void Create(MessageInfoBindingModel model)
        {
            MessageInfo tempMessageInfo = new MessageInfo { Id = "" };

            foreach (var messageInfo in source.MessageInfoes)
            {
                if (model.MessageId == messageInfo.Id)
                {
                    throw new Exception("Уже есть письмо с таким идентификатором");
                }
            }

            source.MessageInfoes.Add(CreateModel(model, tempMessageInfo));
        }

        public List<MessageInfoViewModel> Read(MessageInfoBindingModel model)
        {
            List<MessageInfoViewModel> result = new List<MessageInfoViewModel>();

            foreach (var messageInfo in source.MessageInfoes)
            {
                if (model != null)
                {
                    if (model.ClientId.HasValue && messageInfo.ClientId == model.ClientId)
                    {
                        result.Add(CreateViewModel(messageInfo));
                    }

                    continue;
                }

                result.Add(CreateViewModel(messageInfo));
            }

            return result;
        }

        private MessageInfo CreateModel(MessageInfoBindingModel model, MessageInfo MessageInfo)
        {
            int? clientId = null;

            foreach (var client in source.Clients)
            {
                if (client.Email == model.FromMailAddress)
                {
                    clientId = model.ClientId;
                    break;
                }
            }

            MessageInfo.Id = model.MessageId;
            MessageInfo.ClientId = clientId;
            MessageInfo.SenderName = model.FromMailAddress;
            MessageInfo.DateDelivery = model.DateDelivery;
            MessageInfo.Subject = model.Subject;
            MessageInfo.Body = model.Body;

            return MessageInfo;
        }

        private MessageInfoViewModel CreateViewModel(MessageInfo MessageInfo)
        {
            return new MessageInfoViewModel
            {
                MessageId = MessageInfo.Id,
                SenderName = MessageInfo.SenderName,
                DateDelivery = MessageInfo.DateDelivery,
                Subject = MessageInfo.Subject,
                Body = MessageInfo.Body
            };
        }
    }
}