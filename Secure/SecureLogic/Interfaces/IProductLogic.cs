using SecureLogic.BindingModels;
using SecureLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecureLogic.Interfaces
{
    public interface IProductLogic
    {
        List<ProductViewModel> Read(ProductConcreteBindingModel model);
        void CreateOrUpdate(ProductConcreteBindingModel model);
        void Delete(ProductConcreteBindingModel model);
    }
}