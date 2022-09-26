using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanpooshStore.Domain.Entities.Commons;
using TanpooshStore.Domain.Entities.Users;

namespace TanpooshStore.Domain.Entities.Carts
{
    public class CartEntity: BaseEntity
    {
        public int? UserId { get; set; } //fk
        public Guid BrowserId { get; set; }
        public bool Finished { get; set; }
        public DateTime FinishedTime { get; set; }

        [ForeignKey("UserId")]
        public virtual UserEntity User { get; set; }
        /// <summary>
        /// collections
        /// </summary>
        public ICollection<CartItemEntity> CartItem { get; set; }
    }
}
