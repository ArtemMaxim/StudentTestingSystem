using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTestingSystem.Models
{
    public class Role
    {
        public Role() 
        {
            //this.User = new HashSet<User>();
        }
        public int IdRole { get; set; }
        public string RoleName { get; set; }

    }
}
