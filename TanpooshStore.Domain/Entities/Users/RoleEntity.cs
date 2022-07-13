using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanpooshStore.Domain.Entities.Commons;

namespace TanpooshStore.Domain.Entities.Users
{
    public class RoleEntity: BaseEntity
    {
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
        /// <summary>
        /// /////////////////////////////////
        /// </summary>
        public ICollection<UserInRoleEntity> UserInRole { get; set; }
    }
}
