﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SecureShopFileImplement.Models
{
    /// <summary>
    /// Изделие, изготавливаемое в магазине
    /// </summary>
    public class Komlect
    {
        public int Id { get; set; }
        public string KomlectName { get; set; }
        public int Price { get; set; }
    }

}
