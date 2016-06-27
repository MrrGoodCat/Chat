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

namespace Chat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Model model;
        public MainWindow()
        {
            model = new Model();
            model.GetAllBots();
            InitializeComponent();
            ListOfParticipants_ListBox.ItemsSource = model.Participants;
        }

        private void SendMessage_Button_Click(object sender, RoutedEventArgs e)
        {
            ChatSpace_ListBox.Items.Add(TypeMessage_TextBox.Text);
            
            ChatSpace_ListBox.Items.Add(model.GetAnswer(TypeMessage_TextBox.Text));
            TypeMessage_TextBox.Text = null;
        }

    }
}
