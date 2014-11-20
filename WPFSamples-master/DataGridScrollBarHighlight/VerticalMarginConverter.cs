using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace WpfApplication2
{
    public class VerticalMarginConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var list = values[0] as List<DataItem>;
            var item = values[1] as DataItem;
            var height = (double)values[2];

            return new Thickness(0, (list.IndexOf(item) * (height / list.Count)),0,0);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}