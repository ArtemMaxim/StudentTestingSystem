using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTestingSystem.Models
{
    public class Discipline
    {
        public Discipline()
        {
            this.Theme = new HashSet<Theme>();
        }
        public virtual ICollection<Theme> Theme { get; set; }
        [Key]
        public int IdDiscipline { get; set; }
        public string DisciplineName { get; set; }
    }
}
