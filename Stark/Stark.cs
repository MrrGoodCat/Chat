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

        public string Answer(string Message)
        {
            string answer = "Hello";
            return answer;
        }
    }
}
