using System;
using System.Collections.Generic;
using System.IO;
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

namespace tset2
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var user = MainWindow.context.user.Where(i => i.login == l.Text && i.passwrod == p.Text);
            if(user.Any())
            {
                var u = user.FirstOrDefault();
                if(save.IsChecked.Value)
                {
                    string[] log = new string[2];
                    log[0] = u.login;
                    log[1] = u.passwrod;
                    File.WriteAllLines($"{MainWindow.path}\\l.txt", log);
                }

                MainWindow.user = user.FirstOrDefault();
                NavigationService.Navigate(new Page2());
            }
            else
            {
                MessageBox.Show("Пользователь не найден");
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (File.Exists($@"{MainWindow.path}\l.txt"))
            {
                var file = File.ReadAllLines($"{MainWindow.path}\\l.txt");

                var user = MainWindow.context.user.ToList().Where(i => i.login == file[0] && i.passwrod == file[1]);
                if (user.Any())
                {
                    MainWindow.user = user.FirstOrDefault();
                    
                    NavigationService.Navigate(new Page2());
                }
                else
                {
                    MessageBox.Show("Пользователь не найден");
                }
            }
        }
    }
}
