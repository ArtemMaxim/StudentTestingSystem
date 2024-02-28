using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTestingSystem.Models
{
    public class Role
    {
        [Key]
        public int IdRole { get; set; }
        public string RoleName { get; set; }
        public Role()
        {
            this.User = new HashSet<User>();
        }
        public virtual ICollection<User> User { get; set; }
    }
}
