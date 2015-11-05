using System;
using System.Windows.Data;

namespace WpfTabNavigation.Converter
{
    /// <summary>
    /// Value converter to convert a datetime object to the specified string format. 
    ///   If the format is not specified, it will be converted to short date string "12/31/2011"
    /// </summary>
    [ValueConversion(typeof(DateTime), typeof(string))]
    public class CalendarConverter : IValueConverter
    {
        #region IValueConverter Members

        /// <summary>
        /// Implement the ConvertBack method of IValueConverter. Converts DateTime object to specified format
        /// </summary>
        /// <param name="value">The DateTime value we're converting</param>
        /// <param name="targetType">Not used</param>
        /// <param name="parameter">String format to convert to (optional)</param>
        /// <param name="culture">Not used</param>
        /// <returns>Collapsed if value is true, else Visible</returns>
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            DateTime date = (DateTime)value;
            string param = parameter as string;

            return string.IsNullOrEmpty(param) ? date.ToShortDateString() : date.ToString(param);
        }

        /// <summary>
        /// Implement the Convert method of IValueConverter. Converts a string representation of a date to DateTime
        /// </summary>
        /// <param name="value">The visibility value to convert to a boolean.</param>
        /// <param name="targetType">Not used</param>
        /// <param name="parameter">Not used</param>
        /// <param name="culture">Not used</param>
        /// <returns>false if Visible, else true</returns>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string dateString = (string)value;
            DateTime resultDateTime;

            if (DateTime.TryParse(dateString, out resultDateTime))
                return resultDateTime;

            return DateTime.Now;
        }

        #endregion
    }
}
