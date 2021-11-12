using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
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
    /// Interaction logic for kanban.xaml
    /// </summary>
    public partial class kanban : Page
    {
        ObservableCollection<todo> todos1 = new ObservableCollection<todo>() { new todo() { name = "name" }, new todo() { name = "name1" }, new todo() { name = "nam2" } };
        ObservableCollection<todo> todos2 = new ObservableCollection<todo>();

        public kanban()
        {
            InitializeComponent();
            list1.ItemsSource = todos1;
            list2.ItemsSource = todos2;
        }

        private void list1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox list = (ListBox)sender;
            DragDrop.DoDragDrop(list, list.SelectedItem, DragDropEffects.Move);
        }

        private void list1_Drop(object sender, DragEventArgs e)
        {
            var coll = (((ListBox)sender).ItemsSource as ObservableCollection<todo>);
            var data = e.Data.GetData(typeof(todo));
            coll.Add(data as todo);
            // на этом этапе надо обе таблицы снова из бд подгрузить
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock list = (TextBlock)sender;
            //DragDrop.DoDragDrop(list, list.Text, DragDropEffects.Move);
        }

        private void TextBox_Drop(object sender, DragEventArgs e)
        {
            ((TextBox)sender).Text = e.Data.GetData(DataFormats.Text) as string;

        }
    }


    class todo
    {
        public string name { get; set; }
    }
}
