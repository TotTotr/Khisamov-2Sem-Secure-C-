using SecureLogic.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;


namespace SecureLogic.ViewModels
{
    /// Компонент, требуемый для изготовления изделия 
    public class ComponentViewModel : BaseViewModel
    {
        [Column(title: "Название компонента", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string ComponentName { get; set; }
        public override List<string> Properties() => new List<string>
        {
            "Id",
            "ComponentName"
        };
    }
}
