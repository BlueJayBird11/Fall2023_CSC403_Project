using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGameLibrary
{
    public class Questions
    {
        public int id { get; set; }
        public string[] options { get; set; }
        public string answer { get; set; }
        public Image image { get; set; }

        public bool isCorrect(string response)
        {
            if (response == answer)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
