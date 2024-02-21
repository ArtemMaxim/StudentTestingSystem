using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTestingSystem.Models
{
    public class Question
    {
        public Question()
        {
            this.Answer = new HashSet<Answer>();
        }
        public virtual ICollection<Answer> Answer { get; set; }
        [Key]
        public int IdQuestion { get; set; }
        public int TestId {  get; set; }
        public string QuestionText { get; set; }
        public string TypeId { get; set; }
        public Type Type { get; set; }

    }
}
