using System;
using System.Globalization;
using System.Windows.Data;

namespace BikeShop.Maths
{
    //바인딩 하기위한 인터페이스
    public class TwiceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return int.Parse(value.ToString())*2;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
