using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTestingSystem.Models
{
    class Answer
    {
        public int IdAnswer { get; set; }
        public int QuestionID {  get; set; }
        public string Text {  get; set; }
        public bool IsTrue {  get; set; }
        public Question Question { get; set; }
        
    }
}
