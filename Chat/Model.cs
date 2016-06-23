using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Chat
{
    public class Model
    {
        public List<string> Participants = new List<string>();

        Assembly asm;

        public void GetParticipantName()
        {
            asm = Assembly.LoadFrom("Istredd.dll");
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
    }
}
