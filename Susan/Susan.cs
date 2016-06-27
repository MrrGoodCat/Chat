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
        string name = "Susanna";

        public string Name
        {
            get
            {
                return name;
            }
        }

        Dictionary<string, string> Answers;

        public Susan()
        {
            Answers = new Dictionary<string, string>();
            fillDictionary();
        }
        
        void fillDictionary()
        {
            Answers.Add("Hi", "Alloha, Susan");
            Answers.Add("Hello", "Good morning!, Susan");
            Answers.Add("How are you?", "Thanks, I'm well, and you?, Susan");
        }
        public string Answer(string Message)
        {
            string answer = null;
            if (Answers.TryGetValue(Message, out answer))
            {
                answer = Answers[Message];
            }
            else
            {
                answer = ")";
            }           
            return answer;
        }
    }
}
