using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTestingSystem.Models
{
    class Work
    {
        public int IdWork { get; set; }
        public int TestId { get; set; }
        public int UserId { get; set; }
        public int WorkResult { get; set; }
        public DateTime WorkDate {  get; set; }
        public Test Test { get; set; }
        public User User { get; set; } 
    }
}
