using System;
using SecureLogic.BindingModels;
using SecureLogic.ViewModels;
using System.Collections.Generic;
using System.Text;

namespace SecureLogic.Interfaces
{
    public interface IOrderLogic
    {
        List<OrderViewModel> Read(OrderBindingModel model);
        void CreateOrUpdate(OrderBindingModel model);
        void Delete(OrderBindingModel model);
    }
}
