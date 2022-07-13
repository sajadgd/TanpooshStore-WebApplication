using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanpooshStore.Domain.Entities.Commons;

namespace TanpooshStore.Domain.Entities.Users
{
    public class UserInRoleEntity : BaseEntity
    {
        public int UserId { get; set; } //fk

        public int RoleId { get; set; } //fk

        /// <summary>
        /// ////////////////////////
        /// </summary>

        [ForeignKey("UserId")]
        public virtual UserEntity User { get; set; }

        [ForeignKey("RoleId")]
        public virtual RoleEntity Role { get; set; }
    }
}
