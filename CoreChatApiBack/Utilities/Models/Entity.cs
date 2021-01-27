using CoreChatApiBack.Utilities.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreChatApiBack.Utilities.Models
{
    [IgnoreEntity]
    public abstract class Entity<T> : BaseEntity,IEntity<T>
    {
        public virtual T Id { get ; set ; }
    }
}
