using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BotSDK;

namespace Istredd
{
    public class Istredd : IBot
    {
        string name = "Istredd";

        public string Name
        {
            get
            {
                return name;
            }
        }

        DataBase db;

        public Istredd()
        {
            db = new DataBase();
        }

        public string Answer(string Message)
        {
            string answer = null;
            if (db.Answers.TryGetValue(Message, out answer))
            {
                answer = db.Answers[Message];
            }
            else
            {
                answer = "Item wasn't found!";
            }
            return answer;
        }


    }
}
