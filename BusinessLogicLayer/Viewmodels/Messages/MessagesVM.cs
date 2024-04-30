using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Viewmodels.Messages
{
    public class MessagesVM
    {
        public Guid ID { get; set; }
        public string IDSender { get; set; } = null!;
        public string IDReceiver { get; set; } = null!;
        public string Content { get; set; } = null!;
        public bool IsRead { get; set; }
        public int Status { get; set; }
        public List<string> ImageLink { get; set; }
    }
}
