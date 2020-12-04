using SecureLogic.BindingModels;
using SecureLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecureLogic.Interfaces
{
    public interface IKomlectLogic
    {
        List<KomlectViewModel> Read(KomlectConcreteBindingModel model);
        void CreateOrUpdate(KomlectConcreteBindingModel model);
        void Delete(KomlectConcreteBindingModel model);
    }
}