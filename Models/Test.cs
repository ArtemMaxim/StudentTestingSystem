using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTestingSystem.Models
{
    public class Test
    {
        public Test()
        {
            this.Work = new HashSet<Work>();
            this.Question = new HashSet<Question>();
        }
        [Key]
        public int IdTest { get; set; }
        public int ThemeID { get; set; }
        public TimeOnly TestTime {  get; set; }
        public Theme Theme { get; set; }
        public virtual ICollection<Work> Work { get; set; }
        public virtual ICollection<Question> Question { get; set; }
    }
}
