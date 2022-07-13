using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TanpooshStore.Domain.Entities.Commons;

namespace TanpooshStore.Domain.Entities.Users
{
    public class UserEntity: BaseEntity
    {
        public string FullName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public bool IsActive { get; set; }
        /// <summary>
        /// ////////////////////////////////////
        /// </summary>
        public ICollection<UserInRoleEntity> UserInRole { get; set; }
    }
}
