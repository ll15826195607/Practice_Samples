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
        public ObservableCollection<MenuItemViewModel> MenuItems { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            this.MenuItems = new ObservableCollection<MenuItemViewModel>();
            this.Loaded += MainWindow_Loaded;
        }


        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.MenuItems.Add(new MenuItemViewModel { Header = "Alpha",
                MenuItems = new ObservableCollection<MenuItemViewModel>
                        {
                            new MenuItemViewModel { Header = "Alpha1" },
                            new MenuItemViewModel { Header = "Alpha2" },
                            new MenuItemViewModel { Header = "Alpha3" }
                        }
            });
            this.MenuItems.Add(new MenuItemViewModel
            {
                Header = "Beta",
                MenuItems = new ObservableCollection<MenuItemViewModel>
                        {
                            new MenuItemViewModel { Header = "Beta1" },
                            new MenuItemViewModel { Header = "Beta2" },
                            new MenuItemViewModel { Header = "Beta3" }
                        }
            });
            this.MenuItems.Add(new MenuItemViewModel { Header = "Gamma",
                MenuItems = new ObservableCollection<MenuItemViewModel>
                        {
                            new MenuItemViewModel { Header = "Gamma1" },
                            new MenuItemViewModel { Header = "Gamma2" },
                            new MenuItemViewModel { Header = "Gamma3" }
                        }
            });
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
