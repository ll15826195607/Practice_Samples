using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace TextBlockStyleWithToolTip.Converter
{
    public class ToolTipVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return Visibility.Collapsed;
            }
            else
            {
                FrameworkElement textBlock = (FrameworkElement)value;
                textBlock.Measure(new Size(Double.PositiveInfinity, Double.PositiveInfinity));
                var width = textBlock.DesiredSize.Width;
                if (((FrameworkElement)value).ActualWidth < width)
                {
                    return Visibility.Visible;
                }
                else
                {
                    return Visibility.Collapsed;
                }
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
