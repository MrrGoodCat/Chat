using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Chat
{
    /// <summary>
    /// Interaction logic for DialogWindow.xaml
    /// </summary>
    public partial class DialogWindow : Window
    {
        public DialogWindow()
        {
            InitializeComponent();
        }

        string text = null;

        public string Text
        {
            get
            {
                return text;
            }

            set
            {
                text = value;
            }
        }

        private void Ok_Button_Click(object sender, RoutedEventArgs e)
        {
            Text = UserName_TextBox.Text;
            Close();
        }

        private void UserName_TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Ok_Button_Click(sender, e);
            }
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            Text = "No Name";
            Close();
        }
    }
}
