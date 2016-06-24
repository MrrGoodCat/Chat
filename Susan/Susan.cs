using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BotSDK;

namespace Susan
{
    public class Susan : IBot
    {
        string name = "Susan";

        public string Name
        {
            get
            {
                return name;
            }
        }

        Dictionary<string, string> Answers = new Dictionary<string, string>();

        void fillDictionary()
        {
            Answers.Add("Hi", "Hello");
            Answers.Add("Hello", "Hello");
            Answers.Add("How are you?", "Thanks, I'm well, and you?");
        }
        public string Answer(string Message)
        {
            string answer = "Hello";
            return answer;
        }
    }
}
