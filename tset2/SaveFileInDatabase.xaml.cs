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
    /// Interaction logic for SaveFileInDatabase.xaml
    /// </summary>
    /// 






    // (?=.*[a-z])(?=.*[A-Z])(?=.*[!#]).*




    public partial class SaveFileInDatabase : Page
    {
        public SaveFileInDatabase()
        {
            InitializeComponent();
            loadFiles();
        }

        private void loadFiles()
        {
            files.ItemsSource = MainWindow.context.user.Find(MainWindow.user.id).files.ToList();
        }


        private void files_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (files.SelectedIndex != -1)
            {
                var current_file = files.SelectedItem as files;

                SaveFileDialog savef = new SaveFileDialog();
                savef.FileName = current_file.name;

                if (savef.ShowDialog().Value)
                {
                    File.WriteAllBytes(savef.FileName, current_file.file);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog savef = new OpenFileDialog();
            if (savef.ShowDialog().Value)
            {
                MainWindow.context.files.Add(new tset2.files
                {
                    file = File.ReadAllBytes(savef.FileName),
                    user_id = MainWindow.user.id,
                    name = savef.FileName.Split('\\').LastOrDefault()
                });

                MainWindow.context.SaveChanges();
                loadFiles();
            }
        }
    }
}
