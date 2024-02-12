using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTestingSystem.Models
{
    public class Test
    { 
        public int IdTest { get; set; }
        public int ThemeID { get; set; }
        public TimeOnly TestTime {  get; set; }
        public Theme Theme { get; set; }
    }
}
