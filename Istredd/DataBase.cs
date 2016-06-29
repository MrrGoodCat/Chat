using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Istredd
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
            Answers.Add("Good morning", "Hi!");
            Answers.Add("Good morning!", "Hi!");
            Answers.Add("GM", "Hi!");
            Answers.Add("Hello", "Good morning!");
            Answers.Add("How's life?", "Thanks, I'm well! How about you?");
        }
    }
}
