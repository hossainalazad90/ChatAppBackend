using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreChatApiBack.Helpers
{
    public static class SessionExtensions
    {
        private const string userId = "UserId";
        private const string fullName = "FullName";
        private const string email = "Email";
        private const string loginTime = "LoginTime";

        
        public static T GetComplexData<T>(this ISession session, string key)
        {
            var data = session.GetString(key);
            if (data == null)
            {
                return default(T);
            }
            return JsonConvert.DeserializeObject<T>(data);
        }

        public static void SetComplexData(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        } 


    }
}
