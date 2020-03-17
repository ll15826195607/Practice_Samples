using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace MenuDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window,INotifyPropertyChanged
    {
        public ObservableCollection<Function> FileMms { get; private set; }
        public ObservableCollection<Function> EditMms { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
            this.FileMms = new ObservableCollection<Function>();
            this.DataContext = this;
            this.EditMms = new ObservableCollection<Function>();
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.FileMms.Add(new Function() { Name = "警卫任务" });
            this.FileMms.Add(new Function() { Name = "网络状态" });
            this.EditMms.Add(new Function() { Name = "附属设备" });
            this.EditMms.Add(new Function() { Name = "基础控制" });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(String property)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        private void MenuItem_MouseLeave(object sender, MouseEventArgs e)
        {
            var mi = sender as MenuItem;
            if (mi != null)
            {
                mi.IsSubmenuOpen = false;
            }
        }

        private void MenuItem_MouseEnter(object sender, MouseEventArgs e)
        {
            var mi = sender as MenuItem;
            if (mi != null)
            {
                mi.IsSubmenuOpen = true;
            }
        }
    }
}
