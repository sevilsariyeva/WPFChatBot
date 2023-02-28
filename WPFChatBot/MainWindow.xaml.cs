using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
using WpfAnimatedGif;
using AIMLbot;

namespace WPFChatBot
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

            ListBox listBox = new ListBox();
            ServerUC server = new ServerUC();
            TextBox textBox=new TextBox();
            Button sendBtn = new Button();
            UserUC user = new UserUC();
        private void startBtn_Click(object sender, RoutedEventArgs e)
        {
            robot.Visibility = Visibility.Visible;
            mainGrid.Children.Clear();
            mainGrid.Background = new SolidColorBrush(Colors.Black);
            myGrid.Visibility = Visibility.Visible;
            myListBox.Background=new SolidColorBrush(Color.FromRgb(3, 82, 121));
            myListBox.Visibility=Visibility.Visible;
            
            user.HorizontalAlignment = HorizontalAlignment.Right;
            myListBox.Width = 600;
            myListBox.Height = 300;
            myListBox.Margin = new Thickness(0, 30, 0, 100);
            textBox.AcceptsReturn = true;
            textBox.Background=new SolidColorBrush(Color.FromRgb(59, 141, 162)); 
            textBox.Width = 600;
            textBox.Height = 50;
            textBox.TabIndex = 0;
            textBox.FontSize = 24;
            textBox.Margin = new Thickness(0, 350, 0, 0);
            sendBtn.Height = 30;
            sendBtn.Width = 40;
            sendBtn.Background = new SolidColorBrush(Colors.Green);
            sendBtn.Content = "SEND";
            sendBtn.Margin = new Thickness(520, 350, 0, 0);
            sendBtn.Click += SendBtn_Click;
            mainGrid.Children.Add(textBox);
            mainGrid.Children.Add(sendBtn);
            myListBox.HorizontalContentAlignment = HorizontalAlignment.Center;
        }

        private void SendBtn_Click(object sender, RoutedEventArgs e)
        {
            user.userTxtBlock.Text = textBox.Text;
            textBox.Text = String.Empty;
            Bot bot = new Bot();
            bot.loadSettings();
            bot.loadAIMLFromFiles();
            bot.isAcceptingUserInput = false;
            User myUser = new User("1", bot);
            bot.isAcceptingUserInput = true;
            Request r = new Request(user.userTxtBlock.Text, myUser, bot);
            Result result = bot.Chat(r);
            server.serverTxtBlock.Text = result.Output;
            var heightuser = user.userTxtBlock.Height;
            var heightserver = server.serverTxtBlock.Height;
            user.userTxtBlock.Height += 5;
            server.serverTxtBlock.Height += 5;
            var newheightforserver= user.Margin.Top + heightuser + 5;
            var newheightforuser= server.Margin.Top + heightserver + 5;
            server.HorizontalAlignment = HorizontalAlignment.Left;
            server.Margin = new Thickness(0, 0, 300,0);
            user.Margin = new Thickness(300, 0, 0, 0);
            if (myListBox.Items.Count != 2)
            {
                myListBox.Items.Add(user);
                myListBox.Items.Add(server);
            }
            else
            {
                myListBox.Items.Clear();
                myListBox.Items.Add(user);
                myListBox.Items.Add(server);
            }
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SendBtn_Click(sender, e);
            }
        }
    }
}
