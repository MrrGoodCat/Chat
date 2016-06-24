using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace Chat
{
    public class Model
    {
        public List<string> Participants = new List<string>();
        List<string> ListOfDlls = new List<string>();
        
        Assembly asm;

        void GetAllDllsInFolder()
        {
            ListOfDlls.AddRange(Directory.GetFiles(@"Bots\test", "*.dll", SearchOption.AllDirectories));
        }
        
        public void GetParticipantName(string pathToDll)
        {
            asm = Assembly.LoadFrom(pathToDll);
            object obj;

            foreach (Type type in asm.GetTypes())
            {
                obj = Activator.CreateInstance(type);
                foreach (PropertyInfo property in type.GetProperties())
                {
                    if (property.Name.Equals("Name"))
                    {
                        Participants.Add(property.GetValue(obj).ToString());
                    }
                }

            }
        }

        public void GetAllBots()
        {
            GetAllDllsInFolder();

            foreach (var Dll in ListOfDlls)
            {
                GetParticipantName(Dll);
            }
        }
    }
}
