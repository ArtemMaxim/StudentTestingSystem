using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTestingSystem.Models
{
    class Question
    {
        public int IdQuestion { get; set; }
        public int TestId {  get; set; }
        public string QuestionText { get; set; }
        public string TypeId { get; set; }
        public Type Type { get; set; }
    }
}
