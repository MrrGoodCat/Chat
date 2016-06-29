using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ann
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
            Answers.Add("Good afternoon", "Good afternoon!");
            Answers.Add("How are you doing?", "Not too bad, thanks! And yourself?");
            Answers.Add("How are you?", "Thanks, I'm well, and you?");
        }
    }
}
