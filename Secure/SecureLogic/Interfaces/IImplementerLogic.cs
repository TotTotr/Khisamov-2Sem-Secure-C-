using SecureLogic.BindingModels;
using SecureLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecureLogic.Interfaces
{
    public interface IImplementerLogic
    {
        List<ImplementerViewModel> Read(ImplementerBindingModel model);
        void CreateOrUpdate(ImplementerBindingModel model);
        void Delete(ImplementerBindingModel model);
    }
}