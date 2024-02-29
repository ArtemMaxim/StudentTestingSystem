using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTestingSystem.Models
{
    public class Answer
    {
        [Key]
        public int IdAnswer { get; set; }
        public int QuestionID {  get; set; }
        public string Text {  get; set; }
        public bool IsTrue {  get; set; }
        public Question Question { get; set; }
        
    }
}
