using CoreChatApiBack.Utilities.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreChatApiBack.Utilities.Models
{
    [IgnoreEntity]
    public abstract  class AuditableEntity<T>: Entity<T>,IAuditableEntity
    {
        protected AuditableEntity()
        {
            CreateBy = 1;
            CreateDate = DateTime.Now;
            UpdateBy = 1;
            UpdateDate = DateTime.Now;
            LoginIP = "";
            IsActive = true;                
            
        }

        [IgnoreUpdate]
        public int CreateBy { get; set; }
        [IgnoreUpdate]
        public DateTime CreateDate { get; set; }

        public int UpdateBy { get; set; }

        public DateTime UpdateDate { get; set; }

        public string LoginIP { get; set; }

        public bool IsActive { get; set; }


    }
}
