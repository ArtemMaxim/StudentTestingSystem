using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace StudentTestingSystem.Models
{
    public class Theme
    {
        public Theme()
        {
            this.Test = new HashSet<Test>();
        }
        public virtual ICollection<Test> Test { get; set; }
        [Key]
        public int IdTheme { get; set; }
        public string ThemeName { get; set; }
        public int DisciplineId { get; set; }
        public Discipline Discipline { get; set; }
    }
}
