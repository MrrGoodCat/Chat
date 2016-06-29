using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stark
{
    class DataBase
    {
        public Dictionary<string, string> Answers;
        public DataBase()
        {
            Answers = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);
            fillDictionary();
        }

        void fillDictionary()
        {
            Answers.Add("Hi, All", "Hi!");
            Answers.Add("Good evening", "Hello!");
            Answers.Add("How do you do?", "Thanks, I'm well, and you?");
        }
    }
}
