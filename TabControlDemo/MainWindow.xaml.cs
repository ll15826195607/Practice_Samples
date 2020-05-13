using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using ExtensionMethods;

namespace TabControlDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window,INotifyPropertyChanged
    {
        public ObservableCollection<TabItemModel> UserControls { get; set; }
        private TabItemModel selectedTabModel;
        private object WindowExtensionMethod;

        public TabItemModel SelectedTabModel
        {
            get
            {
                return selectedTabModel;
            }
            set
            {
                if (selectedTabModel != value)
                {
                    selectedTabModel = value;
                    this.RaisePropertyChanged("SelectedTabModel");
                }
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            this.UserControls = new ObservableCollection<TabItemModel>();
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var tb = new TabItemModel() { Header = "    主页    ", IsVisibility = Visibility.Collapsed, Content = new Index() };
            this.UserControls.Add(tb);
            this.SelectedTabModel = tb;
            
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(String property)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(this.IsModal());
            TabItemModel tabModel;
            if (this.UserControls.Count % 2 == 1)
            {
                tabModel = new TabItemModel() { Header = "用户控件1", Content = new UserControl1() };

            }
            else
            {
                tabModel = new TabItemModel() { Header = "用户控件2", Content = new UserControl2() };

            }
            this.UserControls.Add(tabModel);
            this.SelectedTabModel = tabModel;
        }

        private void RemoveTabItem_Click(object sender, RoutedEventArgs e)
        {
            this.UserControls.Remove(this.SelectedTabModel);
        }
    }
}
