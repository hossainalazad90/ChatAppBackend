using CoreChatApiBack.Utilities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoreChatApiBack.Models
{
    public class User:BaseEntity
    {
        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        [NotMapped]
        public string FullName => FirstName + " " + LastName;
    }
}
