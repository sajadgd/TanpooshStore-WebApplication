using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanpooshStore.Domain.Entities.Commons
{
    public abstract class BaseEntity<TKey>
    {
        [Key]
        public TKey Id { get; set; }
        public DateTime InsertTime { get; set; } = DateTime.Now;
        public DateTime? UpdateTime { get; set; }
        public bool IsRemoved { get; set; } = false;
        public DateTime? RemoveTime { get; set; }
    }
    public abstract class BaseEntity: BaseEntity<int>
    {

    }
}
