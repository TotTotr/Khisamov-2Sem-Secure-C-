using SecureLogic.BindingModels;
using SecureLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecureLogic.Interfaces
{
    public interface IKomlectLogic
    {
        List<KomlectViewModel> Read(KomlectKomlectBindingModel model);
        void CreateOrUpdate(KomlectKomlectBindingModel model);
        void Delete(KomlectKomlectBindingModel model);
    }
}