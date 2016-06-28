using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat
{
    class User
    {
        string name;
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public User()
        {
            DialogWindow dw = new DialogWindow();
            dw.ShowDialog();
            Name = dw.Text;
        }
    }
}
