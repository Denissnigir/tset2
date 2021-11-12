using Microsoft.Win32;
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
    /// Interaction logic for downloadInFolder.xaml
    /// </summary>
    public partial class downloadInFolder : Page
    {
        public downloadInFolder()
        {
            InitializeComponent();
            files.ItemsSource = Directory.GetFiles($"{MainWindow.path}\\files");
        }

        private void files_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (files.SelectedIndex != -1)
            {
                var current_file = files.SelectedItem as string;

                SaveFileDialog savef = new SaveFileDialog();
                savef.FileName = current_file.Split('\\').LastOrDefault();

                if((bool)savef.ShowDialog())
                {
                    File.Copy(current_file, savef.FileName);
                }
            }
        }
    }
}
