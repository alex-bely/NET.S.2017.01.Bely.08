using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    /// <summary>
    /// Provides additional format for Customer objects
    /// </summary>
    public class CustomerFormatter : IFormatProvider, ICustomFormatter
    {
        /// <summary>
        /// Returns an object that provides formatting services for the Customer type
        /// </summary>
        /// <param name="formatType">An object that specifies the type of format object to return.</param>
        /// <returns>Object that provides formatting services for the Customer type</returns>
        public object GetFormat(Type formatType)
        {
            return formatType == typeof(ICustomFormatter) ? this : null;
        }

        /// <summary>
        /// Converts customer object to an equivalent string representation using specified format and specific formatting information.
        /// </summary>
        /// <param name="format">A format string containing formatting specifications.</param>
        /// <param name="arg">Instance of the Customer</param>
        /// <param name="formatProvider">An object that supplies format information about the current instance.</param>
        /// <returns>The string representation of Customer object, formatted as specified by format and formatProvider</returns>
        /// <exception cref="ArgumentNullException">Instance of the Customer is null referenced</exception>
        /// <exception cref="ArgumentException">Object reference doesn't refer to Customer instance</exception>
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (ReferenceEquals(arg, null)) throw new ArgumentNullException(nameof(arg));
            if (!(arg is Customer)) throw new ArgumentException(nameof(arg));

            format = format.Trim().ToUpperInvariant();
            Customer customer = (Customer)arg;

            switch (format)
            {
                case "GC":  return $"Customer record: {customer.Name}, {customer.Revenue.ToString("C", CultureInfo.GetCultureInfo("en-US"))}, {customer.ContactPhone}";
                case "NRC": return $"Customer record: {customer.Name}, {customer.Revenue.ToString("C", CultureInfo.GetCultureInfo("en-US"))}";
                case "NUP": return $"Customer record: {customer.Name.ToUpper()}";
                case "RC":  return $"Customer record: {customer.Revenue.ToString("C", CultureInfo.GetCultureInfo("en-US"))}";
                default:
                            throw new FormatException($"The {format} format specifier is not supported.");
            }
        }

    }

}

