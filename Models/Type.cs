using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTestingSystem.Models
{
    public class Type
    {
        public Type()
        {
            this.Question = new HashSet<Question>();
        }
        public virtual ICollection<Question> Question { get; set; }
        [Key]
        public int IdType { get; set; }
        public string TypeName { get; set; }
    }
}
