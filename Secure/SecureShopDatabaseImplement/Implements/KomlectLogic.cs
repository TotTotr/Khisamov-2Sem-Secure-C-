using SecureLogic.BindingModels;
using SecureLogic.Interfaces;
using SecureLogic.ViewModels;
using SecureShopDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
namespace SecureShopDatabaseImplement.Implements
{
    public class KomlectLogic : IKomlectLogic
    {
        public void CreateOrUpdate(KomlectConcreteBindingModel model)
        {
            using (var context = new SecureShopDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Komlect element = context.Komlects.FirstOrDefault(rec =>
                       rec.KomlectName == model.KomlectName && rec.Id != model.Id);
                        if (element != null)
                        {
                            throw new Exception("Уже есть изделие с таким названием");
                        }
                        if (model.Id.HasValue)
                        {
                            element = context.Komlects.FirstOrDefault(rec => rec.Id ==
                           model.Id);
                            if (element == null)
                            {
                                throw new Exception("Элемент не найден");
                            }
                        }
                        else
                        {
                            element = new Komlect();
                            context.Komlects.Add(element);
                        }
                        element.KomlectName = model.KomlectName;
                        element.Price = model.Price;
                        context.SaveChanges();
                        if (model.Id.HasValue)
                        {
                            var KomlectComponents = context.KomlectComponents.Where(rec
                           => rec.KomlectId == model.Id.Value).ToList();
                            // удалили те, которых нет в модели

                            context.KomlectComponents.RemoveRange(KomlectComponents.Where(rec =>
                            !model.KomlectComponents.ContainsKey(rec.ComponentId)).ToList());
                            context.SaveChanges();
                            // обновили количество у существующих записей
                            foreach (var updateComponent in KomlectComponents)
                            {
                                updateComponent.Count =
                               model.KomlectComponents[updateComponent.ComponentId].Item2;

                                model.KomlectComponents.Remove(updateComponent.ComponentId);
                            }
                            context.SaveChanges();
                        }
                        // добавили новые
                        foreach (var pc in model.KomlectComponents)
                        {
                            context.KomlectComponents.Add(new KomlectComponent
                            {
                                KomlectId = element.Id,
                                ComponentId = pc.Key,
                                Count = pc.Value.Item2
                            });
                            context.SaveChanges();
                        }
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        public void Delete(KomlectConcreteBindingModel model)
        {
            using (var context = new SecureShopDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        // удаяем записи по компонентам при удалении изделия
                        context.KomlectComponents.RemoveRange(context.KomlectComponents.Where(rec =>
                        rec.KomlectId == model.Id));
                        Komlect element = context.Komlects.FirstOrDefault(rec => rec.Id == model.Id);
                        if (element != null)
                        {
                            context.Komlects.Remove(element);
                            context.SaveChanges();
                        }
                        else
                        {
                            throw new Exception("Элемент не найден");
                        }
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        public List<KomlectViewModel> Read(KomlectConcreteBindingModel model)
        {
            using (var context = new SecureShopDatabase())
            {
                return context.Komlects
                .Where(rec => model == null || rec.Id == model.Id)
                .ToList()
               .Select(rec => new KomlectViewModel
               {
                   Id = rec.Id,
                   KomlectName = rec.KomlectName,
                   Price = rec.Price,
                   KomlectComponents = context.KomlectComponents
                .Include(recPC => recPC.Component)
               .Where(recPC => recPC.KomlectId == rec.Id)
               .ToDictionary(recPC => recPC.ComponentId, recPC =>
                (recPC.Component?.ComponentName, recPC.Count))
               })
               .ToList();
            }
        }
    }
}
