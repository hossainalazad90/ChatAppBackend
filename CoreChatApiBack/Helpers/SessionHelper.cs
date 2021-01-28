using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreChatApiBack.Helpers
{
    public static class SessionHelper
    {
        private const string userId = "UserId";
        private const string fullName = "FullName";
        private const string email = "Email";
        private const string loginTime = "LoginTime";

        public static string UserId
        {
            get
            {
                return (string)HttpContext.Current.Session[userId];
            }
            set
            {
                HttpContext.Current.Session[userId] = value;
            }
        }

        public static void Clear()
        {
            
        }





    }
}
