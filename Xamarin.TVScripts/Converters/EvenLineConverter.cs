using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;
using Xamarin.TVScripts.Models;

namespace Xamarin.TVScripts.Converters
{
    public class EvenLineConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Quote quote)
                return quote.Character.Trim().Length > 1
                    && quote.QuoteNumber % 2 == 0;

            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
