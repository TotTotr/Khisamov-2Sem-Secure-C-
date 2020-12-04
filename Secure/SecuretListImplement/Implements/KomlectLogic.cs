using SecureLogic.BindingModels;
using SecureLogic.Interfaces;
using SecureLogic.ViewModels;
using SecuretListImplement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecuretListImplement.Implements
{
    public class KomlectLogic : IKomlectLogic
    {
        private readonly DataListSingleton source;

        public KomlectLogic()
        {
            source = DataListSingleton.GetInstance();
        }
        public void CreateOrUpdate(KomlectConcreteBindingModel model)
        {
            Komlect tempKomlect = model.Id.HasValue ? null : new Komlect { Id = 1 };
            foreach (var Komlect in source.Komlects)
            {
                if (Komlect.KomlectName == model.KomlectName && Komlect.Id != model.Id)
                {
                    throw new Exception("Уже есть изделие с таким названием");
                }
                if (!model.Id.HasValue && Komlect.Id >= tempKomlect.Id)
                {
                    tempKomlect.Id = Komlect.Id + 1;
                }
                else if (model.Id.HasValue && Komlect.Id == model.Id)
                {
                    tempKomlect = Komlect;
                }
            }
            if (model.Id.HasValue)
            {
                if (tempKomlect == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, tempKomlect);
            }
            else
            {
                source.Komlects.Add(CreateModel(model, tempKomlect));
            }
        }
        public void Delete(KomlectConcreteBindingModel model)
        {
            // удаляем записи по компонентам при удалении изделия
            for (int i = 0; i < source.KomlectComponents.Count; ++i)
            {
                if (source.KomlectComponents[i].KomlectId == model.Id)
                {
                    source.KomlectComponents.RemoveAt(i--);
                }
            }
            for (int i = 0; i < source.Komlects.Count; ++i)
            {
                if (source.Komlects[i].Id == model.Id)
                {
                    source.Komlects.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
        private Komlect CreateModel(KomlectConcreteBindingModel model, Komlect Komlect)
        {
            Komlect.KomlectName = model.KomlectName;
            Komlect.Price = model.Price;
            //обновляем существуюущие компоненты и ищем максимальный идентификатор
            int maxPCId = 0;
            for (int i = 0; i < source.KomlectComponents.Count; ++i)
            {
                if (source.KomlectComponents[i].Id > maxPCId)
                {
                    maxPCId = source.KomlectComponents[i].Id;
                }
                if (source.KomlectComponents[i].KomlectId == Komlect.Id)
                {
                    // если в модели пришла запись компонента с таким id
                    if
                    (model.KomlectComponents.ContainsKey(source.KomlectComponents[i].ComponentId))
                    {
                        // обновляем количество
                        source.KomlectComponents[i].Count =
                        model.KomlectComponents[source.KomlectComponents[i].ComponentId].Item2;
                        // из модели убираем эту запись, чтобы остались только не
                        //    просмотренные

                        model.KomlectComponents.Remove(source.KomlectComponents[i].ComponentId);
                    }
                    else
                    {
                        source.KomlectComponents.RemoveAt(i--);
                    }
                }
            }
            // новые записи
            foreach (var pc in model.KomlectComponents)
            {
                source.KomlectComponents.Add(new KomlectComponent
                {
                    Id = ++maxPCId,
                    KomlectId = Komlect.Id,
                    ComponentId = pc.Key,
                    Count = pc.Value.Item2
                });
            }
            return Komlect;
        }
        public List<KomlectViewModel> Read(KomlectConcreteBindingModel model)
        {
            List<KomlectViewModel> result = new List<KomlectViewModel>();
            foreach (var component in source.Komlects)
            {
                if (model != null)
                {
                    if (component.Id == model.Id)
                    {
                        result.Add(CreateViewModel(component));
                        break;
                    }
                    continue;
                }
                result.Add(CreateViewModel(component));
            }
            return result;
        }
        private KomlectViewModel CreateViewModel(Komlect Komlect)
        {
            // требуется дополнительно получить список компонентов для изделия с
            //  названиями и их количество
            Dictionary<int, (string, int)> KomlectComponents = new Dictionary<int,
    (string, int)>();
            foreach (var pc in source.KomlectComponents)
            {
                if (pc.KomlectId == Komlect.Id)
                {
                    string componentName = string.Empty;
                    foreach (var component in source.Components)
                    {
                        if (pc.ComponentId == component.Id)
                        {
                            componentName = component.ComponentName;
                            break;
                        }
                    }
                    KomlectComponents.Add(pc.ComponentId, (componentName, pc.Count));
                }
            }
            return new KomlectViewModel
            {
                Id = Komlect.Id,
                KomlectName = Komlect.KomlectName,
                Price = Komlect.Price,
                KomlectComponents = KomlectComponents
            };
        }
    }
}
