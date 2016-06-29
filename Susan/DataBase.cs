using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Susan
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
            Answers.Add("Hi", "Hello");
            Answers.Add("Bye", "Good bye, nice to meet you!");
            Answers.Add("How are you?", "Thanks, I'm well, and you?");
        }
    }
}
