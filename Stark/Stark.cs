using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BotSDK;

namespace Stark
{
    public class Stark : IBot
    {
        string name = "Stark";

        public string Name
        {
            get
            {
                return name;
            }
        }

        Dictionary<string, string> Answers;

        public Stark()
        {
            Answers = new Dictionary<string, string>();
            fillDictionary();
        }

         

        void fillDictionary()
        {
            Answers.Add("Hi", "Alloha, Stark");
            Answers.Add("Hello", "Good morning!, Stark");
            Answers.Add("How are you?", "Thanks, I'm well, and you?, Stark");
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
