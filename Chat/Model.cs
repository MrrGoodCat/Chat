using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using BotSDK;

namespace Chat
{
    public class Model
    {
        List<string> participants;
        Assembly asm;
        string folgerPath = @"Bots";

        public List<string> Participants
        {
            get
            {
                return participants;
            }

            set
            {
                participants = value;
            }
        }
        public List<IBot> Bots;

        public Model()
        {
            Participants = new List<string>();
            Bots = new List<IBot>();
            GetAllDllsInFolder();
            GetAllBotsNames();
        }

        IBot GetBotType(string pathToDll)
        {
            IBot obj = null;
            asm = Assembly.LoadFrom(pathToDll);
            foreach (Type t in asm.GetTypes())
            {
                if (!t.IsInterface && typeof(IBot).IsAssignableFrom(t))
                {
                    obj = (IBot)Activator.CreateInstance(t);
                }
            }
            return obj;
        }

        void GetAllDllsInFolder()
        {
            string[] dlls = Directory.GetFiles(folgerPath, "*.dll", SearchOption.AllDirectories);
            foreach (string item in dlls)
            {
                if (GetBotType(item) != null)
                {
                    Bots.Add(GetBotType(item));
                }
            }
        }

        string GetBotName(IBot bot)
        {
            return bot.Name;
        }

        void GetAllBotsNames()
        {
            foreach (IBot bot in Bots)
            {
                Participants.Add(GetBotName(bot));
            }
        }
        /// <summary>
        /// Get answer from some bot
        /// </summary>
        /// <param name="question">String message that written by user</param>
        /// <returns>Returns string response from bot that has answer for question</returns>
        public string GetAnswer(string question)
        {
            string answer = null;
            foreach (IBot bot in Bots)
            {  
                string tempResponse = bot.Answer(question);
                if (tempResponse == "Item wasn't found!")
                {
                    if (bot == Bots.Last())
                    {
                        return null;
                    }
                    continue;
                }
                answer = GetBotName(bot) + ": " + tempResponse;
                return answer;
            }
            return answer;
        }
    }
}
