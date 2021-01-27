using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreChatApiBack.ViewModels
{
    public class SignUpViewModel
    {
        [Display(Name ="First Name")]
        [Required]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]        
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
}
