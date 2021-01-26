using CoreChatApiBack.Utilities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreChatApiBack.Models
{
    public class Chat:AuditableEntity<long>
    {
        public override long Id { get; set; }

        public string Message { get; set; }

        public long UserId { get; set; }
    }
}
