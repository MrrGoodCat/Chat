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
        public List<string> Participants;
        List<string> ListOfDlls;
        Assembly asm;
        string folgerPath = @"Bots";

        public Model()
        {
            Participants = new List<string>();
            ListOfDlls = new List<string>();
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
                    ListOfDlls.Add(item);
                }
            }

            //ListOfDlls.AddRange(Directory.GetFiles(folgerPath, "*.dll", SearchOption.AllDirectories));
        }
        
        public string GetParticipantName(string pathToDll)
        {
            string participant = null;
            object obj;

                obj = Activator.CreateInstance(GetBotType(pathToDll));
                foreach (PropertyInfo property in GetBotType(pathToDll).GetProperties())
                {
                    if (property.Name.Equals("Name"))
                    {
                        participant = property.GetValue(obj).ToString();
                    }
                }

            return participant;
        }


        public void GetAllBots()
        {
            foreach (var Dll in ListOfDlls)
            {
                Participants.Add(GetParticipantName(Dll));
            }
        }

        public string GetAnswer(string quastion)
        {
            string answer = null;
            foreach (var Dll in ListOfDlls)
            {
                object obj;
                obj = Activator.CreateInstance(GetBotType(Dll));
                foreach (MethodInfo method in GetBotType(Dll).GetMethods())
                {
                    if (method.Name.Equals("Answer"))
                    {
                        string tempResponse = method.Invoke(obj, new object[] { quastion }).ToString();
                        if (tempResponse == "Item wasn't found!")
                        {
                            if (Dll == ListOfDlls.Last())
                            {
                                return null;
                            }
                            continue;
                        }
                        answer = GetParticipantName(Dll) + ": " + tempResponse;
                        return answer;
                    }
                }
            }
            return answer;
        }
    }
}
