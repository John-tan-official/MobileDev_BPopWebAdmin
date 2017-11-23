using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BPopWebAdmin.Models
{
    public class Questions
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string ChoiceA { get; set; }
        public string ChoiceB { get; set; }
        public string ChoiceC { get; set; }
        public string ChoiceD { get; set; }
        public string Answer { get; set; }
    }
}