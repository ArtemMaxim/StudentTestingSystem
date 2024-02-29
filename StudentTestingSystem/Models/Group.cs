using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTestingSystem.Models
{
    public class Group
    {
        [Key]
        public int IdGroup { get; set; }
        public string GroupName { get; set; }
        public Group()
        {
            this.User = new HashSet<User>();
        }
        public virtual ICollection<User> User { get; set; }
    }
}
