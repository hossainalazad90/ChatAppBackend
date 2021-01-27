using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreChatApiBack.ViewModels
{
    public class SignInViewModel
    {
        [EmailAddress]
        public string Email { get; set; }
    }
}
