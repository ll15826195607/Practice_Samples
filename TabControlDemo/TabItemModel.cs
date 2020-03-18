using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace TabControlDemo
{
    public class TabItemModel
    {
        public TabItemModel()
        {
            this.IsVisibility = Visibility.Visible;
        }
        public String Header { get; set; }
        public Visibility IsVisibility { get; set; }
        public ContentControl Content { get; set; }
    }
}
