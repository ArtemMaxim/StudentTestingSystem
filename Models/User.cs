using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTestingSystem.Models
{
    public class User
    {
        public User()
        {
            this.Work = new HashSet<Work>();
        }
        public virtual ICollection<Work> Work { get; set; }
        [Key]
        public int IdUser { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public int? GroupId { get; set; }
        
        public int RoleId { get; set; }
        public string UserLogin {  get; set; }
        public string UserPassword { get; set; }
        public Group Group { get; set; }
        public Role Role { get; set; }

    }
}
