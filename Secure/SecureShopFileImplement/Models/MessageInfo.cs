using System;
using System.Collections.Generic;
using System.Text;

namespace SecureShopFileImplement.Models
{
    public class MessageInfo
    {
        public string Id { get; set; }

        public int? ClientId { get; set; }

        public string SenderName { get; set; }

        public DateTime DateDelivery { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }
    }
}