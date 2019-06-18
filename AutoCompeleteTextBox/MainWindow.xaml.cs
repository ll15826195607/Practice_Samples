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

namespace AutoCompeleteTextBox
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly List<String> names = new List<String>();
        public MainWindow()
        {
            InitializeComponent();
            names = new List<string>
            {
                "admin",
                "A0-Word",
                "B0-Word",
                "C0-Word",
                "A1-Word",
                "A111",
                "A11122",
                "B1-Word",
                "C1-Word",
                "AB2-Word",
                "C2-Word",
                "AC3-Word",
                "ll",
                "lll"
            };
            this.acb.ItemsSource = names;
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.acb.Populating += Acb_Populating;
            this.acb.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
        }

        private void Acb_Populating(object sender, PopulatingEventArgs e)
        {
            var source = sender as AutoCompleteBox;
            if (source != null)
            {
                Console.WriteLine(source.SearchText);
                if (String.IsNullOrEmpty(source.SearchText) == true)
                {
                    this.acb.ItemsSource = null;
                }
                else
                {
                    var nls = names.FindAll((item) => { return item.ToUpper().StartsWith(source.SearchText.ToUpper()); });
                    this.acb.ItemsSource = nls;
                    if (nls.Count == 1 && nls.First() == source.SearchText)
                    {
                        this.acb.ItemsSource = null;
                    }
                }
            }
        }
    }
}
