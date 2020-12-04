using SecureLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecureLogic.HelperModels
{
    class WordInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<KomlectViewModel> Komlects { get; set; }
    }
}
