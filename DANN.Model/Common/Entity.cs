using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DANN.Model
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
    public abstract class BaseEntity
    {
        public virtual int Id { get; set; }
        public virtual int? ParentId { get; set; }
        public virtual int? CodeKindId { get; set; }
    }

    public abstract class Entity<T> : BaseEntity, IEntity<T>
    {
        public virtual T Id { get; set; }
    }


}
