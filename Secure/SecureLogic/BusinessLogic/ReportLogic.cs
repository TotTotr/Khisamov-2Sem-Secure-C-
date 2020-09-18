
using SecureLogic.BindingModels;
using SecureLogic.HelperModels;
using SecureLogic.Interfaces;
using SecureLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecureLogic.BusinessLogic
{
    public class ReportLogic
    {
        private readonly IComponentLogic componentLogic;
        private readonly IKomlectLogic KomlectLogic;
        private readonly IOrderLogic orderLogic;
        public ReportLogic(IKomlectLogic KomlectLogic, IComponentLogic componentLogic,
       IOrderLogic orderLLogic)
        {
            this.KomlectLogic = KomlectLogic;
            this.componentLogic = componentLogic;
            this.orderLogic = orderLLogic;
        }
        /// <summary>
        /// Получение списка компонент с указанием, в каких изделиях используются
        /// </summary>
        /// <returns></returns>
        public List<ReportKomlectComponentViewModel> GetKomlectComponent()
        {
            var Komlects = KomlectLogic.Read(null);
            var list = new List<ReportKomlectComponentViewModel>();
            foreach (var Komlect in Komlects)
            {
                foreach (var rec in Komlect.KomlectComponents)
                {
                    var record = new ReportKomlectComponentViewModel
                    {
                        KomlectName = Komlect.KomlectName,
                        ComponentName = rec.Value.Item1,
                        TotalCount = rec.Value.Item2
                    };
                    list.Add(record);
                }
            }
            return list;
        }
        /// <summary>
        /// Получение списка заказов за определенный период
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<IGrouping<DateTime, OrderViewModel>> GetOrders(ReportBindingModel model)
        {
            var list = orderLogic
            .Read(new OrderBindingModel
            {
                DateFrom = model.DateFrom,
                DateTo = model.DateTo
            })
            .GroupBy(rec => rec.DateCreate.Date)
            .OrderBy(recG => recG.Key)
            .ToList();

            return list;
        }
        /// <summary>
        /// Сохранение компонент в файл-Word
        /// </summary>
        /// <param name="model"></param>
        public void SaveKomlectsToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список изделий",
                Komlects = KomlectLogic.Read(null)
            });
        }
        /// <summary>
        /// Сохранение компонент с указаеним продуктов в файл-Pdf
        /// </summary>
        /// <param name="model"></param>
        public void SaveKomlectComponentToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список изделий с компонентами",
                KomlectComponents = GetKomlectComponent()
            });
        }
        /// <summary>
        /// Сохранение заказов в файл-Excel
        /// </summary>
        /// <param name="model"></param>
        public void SaveOrdersToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список заказов",
                Orders = GetOrders(model)
            });
        }
    }
}
