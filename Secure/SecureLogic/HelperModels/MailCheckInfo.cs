using SecureLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecureLogic.HelperModels
{
    public class MailCheckInfo
    {
        public string PopHost { get; set; }
        public int PopPort { get; set; }
        public IMessageInfoLogic Logic { get; set; }
    }

}