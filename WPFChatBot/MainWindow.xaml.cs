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

        private void startBtn_Click(object sender, RoutedEventArgs e)
        {
            mainGrid.Children.Clear();
            mainGrid.Background = new SolidColorBrush(Colors.Black);
            var server = new ServerUC();
            var user = new UserUC();
            server.HorizontalAlignment=HorizontalAlignment.Left;
            server.Margin = new Thickness(0,0,0,330);
            user.HorizontalAlignment = HorizontalAlignment.Right;
            user.Margin = new Thickness(0,0,0,150);
            ListBox listBox = new ListBox();
            listBox.Background=new SolidColorBrush(Colors.MidnightBlue);
            listBox.Width = 600;
            listBox.Height = 300;
            listBox.Margin = new Thickness(0, 0, 0, 100);
            BitmapImage image = new BitmapImage(new Uri("Gifs/robot.png", UriKind.Relative));
            mainGrid.Children.Add(listBox);
            
           // mainGrid.Children.Add(server);
           // mainGrid.Children.Add(user);
        }
    }
}
