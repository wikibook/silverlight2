using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Snippet5_9
{
    public partial class Page : UserControl
    {
        public Page()
        {
            InitializeComponent();
        }
    }

    public class YesNoValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
            object parameter, System.Globalization.CultureInfo culture)
        {
            bool isYes = Boolean.Parse(value.ToString());
            if (isYes == true)
                return "Yes";
            return "No";
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, System.Globalization.CultureInfo culture)
        {
            string boolText = value.ToString().ToLower();
            if (boolText == "yes")
                return true;
            else if (boolText == "no")
                return false;
            else
                throw new InvalidOperationException("Please enter 'yes' or 'no'.");
        }
    }
}
