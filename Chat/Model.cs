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
        public List<Type> Bots;

        public Model()
        {
            Participants = new List<string>();
            Bots = new List<Type>();
            GetAllDllsInFolder();
        }

        Type GetBotType(string pathToDll)
        {
            Type type = null;
            asm = Assembly.LoadFrom(pathToDll);
            foreach (Type t in asm.GetTypes())
            {
                if (!t.IsInterface && typeof(IBot).IsAssignableFrom(t))
                {
                    type = t;
                }
            }
            return type;
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

        string GetBotName(Type botType)
        {
            string botName = null;
            object obj = Activator.CreateInstance(botType);
            foreach (PropertyInfo property in botType.GetProperties())
            {
                if (property.Name.Equals("Name"))
                {
                    botName = property.GetValue(obj).ToString();
                }
            }
            return botName;
        }

        public void GetAllBots()
        {
            foreach (var bot in Bots)
            {
                Participants.Add(GetBotName(bot));
            }
        }

        public string GetAnswer(string quastion)
        {
            string answer = null;
            foreach (var bot in Bots)
            {
                object obj;
                obj = Activator.CreateInstance(bot);
                foreach (MethodInfo method in bot.GetMethods())
                {
                    if (method.Name.Equals("Answer"))
                    {
                        string tempResponse = method.Invoke(obj, new object[] { quastion }).ToString();
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
                }
            }
            return answer;
        }
    }
}
