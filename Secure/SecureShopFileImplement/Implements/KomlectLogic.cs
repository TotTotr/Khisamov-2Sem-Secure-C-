using SecureLogic.BindingModels;
using SecureLogic.Interfaces;
using SecureLogic.ViewModels;
using SecureShopFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
namespace SecureShopFileImplement.Implements
{
    public class KomlectLogic : IKomlectLogic
    {
        private readonly FileDataListSingleton source;
        public KomlectLogic()
        {
            source = FileDataListSingleton.GetInstance();
        }
        public void CreateOrUpdate(KomlectConcreteBindingModel model)
        {
            Komlect element = source.Komlects.FirstOrDefault(rec => rec.KomlectName ==
           model.KomlectName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть изделие с таким названием");
            }
            if (model.Id.HasValue)
            {
                element = source.Komlects.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
            }
            else
            {
                int maxId = source.Komlects.Count > 0 ? source.Components.Max(rec =>
               rec.Id) : 0;
                element = new Komlect { Id = maxId + 1 };
                source.Komlects.Add(element);
            }
            element.KomlectName = model.KomlectName;
            element.Price = model.Price;
            // удалили те, которых нет в модели
            source.KomlectComponents.RemoveAll(rec => rec.KomlectId == model.Id &&
           !model.KomlectComponents.ContainsKey(rec.ComponentId));
            // обновили количество у существующих записей
            var updateComponents = source.KomlectComponents.Where(rec => rec.KomlectId ==
           model.Id && model.KomlectComponents.ContainsKey(rec.ComponentId));
            foreach (var updateComponent in updateComponents)
            {
                updateComponent.Count =
               model.KomlectComponents[updateComponent.ComponentId].Item2;
                model.KomlectComponents.Remove(updateComponent.ComponentId);
            }
            // добавили новые
            int maxPCId = source.KomlectComponents.Count > 0 ?
           source.KomlectComponents.Max(rec => rec.Id) : 0;
            foreach (var pc in model.KomlectComponents)
            {
                source.KomlectComponents.Add(new KomlectComponent
                {
                    Id = ++maxPCId,
                    KomlectId = element.Id,
                    ComponentId = pc.Key,
                    Count = pc.Value.Item2
                });
            }
        }
        public void Delete(KomlectConcreteBindingModel model)
        {
            // удаяем записи по компонентам при удалении изделия
            source.KomlectComponents.RemoveAll(rec => rec.KomlectId == model.Id);
            Komlect element = source.Komlects.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                source.Komlects.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        public List<KomlectViewModel> Read(KomlectConcreteBindingModel model)
        {
            return source.Komlects
            .Where(rec => model == null || rec.Id == model.Id)
            .Select(rec => new KomlectViewModel
            {
                Id = rec.Id,
                KomlectName = rec.KomlectName,
                Price = rec.Price,
                KomlectComponents = source.KomlectComponents
            .Where(recPC => recPC.KomlectId == rec.Id)
           .ToDictionary(recPC => recPC.ComponentId, recPC =>
            (source.Components.FirstOrDefault(recC => recC.Id ==
           recPC.ComponentId)?.ComponentName, recPC.Count))
            })
            .ToList();
        }
    }
}
