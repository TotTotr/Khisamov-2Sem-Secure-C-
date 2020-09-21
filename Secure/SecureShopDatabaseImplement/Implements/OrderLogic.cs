using SecureLogic.BindingModels;
using SecureLogic.Interfaces;
using SecureLogic.ViewModels;
using SecureShopDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SecureLogic.Enums;

namespace SecureShopDatabaseImplement.Implements
{
    public class OrderLogic : IOrderLogic
    {

        public void CreateOrUpdate(OrderBindingModel model)
        {
            using (var context = new SecureShopDatabase())
            {
                Order element;
                if (model.Id.HasValue)
                {
                    element = context.Orders.FirstOrDefault(rec => rec.Id ==
                   model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                }
                else
                {
                    element = new Order();
                    context.Orders.Add(element);
                }
                element.KomlectId = model.KomlectId == 0 ? element.KomlectId : model.KomlectId;
                element.ClientId = model.ClientId == null ? element.ClientId : (int)model.ClientId;
                element.ImplementerId = model.ImplementerId;
                element.Count = model.Count;
                element.Sum = model.Sum;
                element.Status = model.Status;
                element.DateCreate = model.DateCreate;
                element.DateImplement = model.DateImplement;
                context.SaveChanges();
            }
        }

        public void Delete(OrderBindingModel model)
        {
            using (var context = new SecureShopDatabase())
            {
                Order element = context.Orders.FirstOrDefault(rec => rec.Id ==
model.Id);
                if (element != null)
                {
                    context.Orders.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }


        public List<OrderViewModel> Read(OrderBindingModel model)
        {
            using (var source = new SecureShopDatabase())
            {
                return source.Orders.Where(
               rec => model == null
               || rec.Id == model.Id && model.Id.HasValue
                   || model.DateFrom.HasValue && model.DateTo.HasValue && rec.DateCreate >= model.DateFrom && rec.DateCreate <= model.DateTo
                   || model.ClientId.HasValue && rec.ClientId == model.ClientId
                   || model.FreeOrders.HasValue && model.FreeOrders.Value && !rec.ImplementerId.HasValue
                   || model.ImplementerId.HasValue && rec.ImplementerId == model.ImplementerId && rec.Status == OrderStatus.Выполняется)
                .Include(rec => rec.Komlect)
                .Include(rec => rec.Client)
                .Include(rec => rec.Implementer)
                 .Select(rec => new OrderViewModel
                 {
                     Id = rec.Id,
                     KomlectId = rec.KomlectId,
                     ImplementerId = rec.ImplementerId,
                     ClientId = rec.ClientId,
                     DateCreate = rec.DateCreate,
                     DateImplement = rec.DateImplement,
                     Status = rec.Status,
                     Count = rec.Count,
                     Sum = rec.Sum,
                     ClientFIO = rec.Client.ClientFIO,
                     KomlectName = rec.Komlect.KomlectName,
                     ImplementerFIO = rec.ImplementerId.HasValue ? rec.Implementer.ImplementerFIO : string.Empty,
                 })
                .ToList();
            }
        }
    }
}