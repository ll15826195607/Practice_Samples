using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MultiRadioButtonBinding
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private ViewModel vm = new ViewModel();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = vm;
        }
    }

    [ValueConversion(typeof(bool), typeof(Enum))]
    public class EnumToBoolExtension : MarkupExtension, IValueConverter
    {
        #region IValueConverter

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return parameter.Equals(value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((bool)value) == true ? parameter : DependencyProperty.UnsetValue;
        }

        #endregion

        #region MarkupExtension

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }

        #endregion
    }

    public enum Direction
    {
        North,
        Easth,
        West,
        South
    }

    public class ViewModel : INotifyPropertyChanged
    {
        public Direction direction;

        public Direction Direction
        {
            get
            {
                return this.direction;
            }

            set
            {
                this.direction = value;
                this.RaisePropertyChanged("Direction");
            }
        }

        #region NotifyPropertyChanged Methods

        public void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}
