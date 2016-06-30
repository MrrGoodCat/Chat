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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BotSDK;
using System.Threading;

namespace Chat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Model model;
        User user;
        public MainWindow()
        {
            model = new Model();
            user = new User();            
            InitializeComponent();
            Title = "Smart chat. User: " + user.Name;
            ListOfParticipants_ListBox.ItemsSource = model.Participants;
        }

        private void SendMessage_Button_Click(object sender, RoutedEventArgs e)
        {
            ChatSpace_ListBox.Items.Add(user.Name + ": " + TypeMessage_TextBox.Text);
            ChatSpace_ListBox.Items.Add(model.GetAnswer(TypeMessage_TextBox.Text));
            TypeMessage_TextBox.Text = null;
        }

        private void TypeMessage_TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SendMessage_Button_Click(sender, e);
            }
        }
    }
}
