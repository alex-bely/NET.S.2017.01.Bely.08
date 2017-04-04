using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    /// <summary>
    /// Contains the information about customer.
    /// </summary>
    public class Customer : IFormattable
    {
        #region Properties
        public string Name { get; set; }
        public string ContactPhone { get; set; }
        public decimal Revenue { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor
        /// </summary>
        public Customer()
        {
            Name = String.Empty;
            ContactPhone = String.Empty;
            Revenue = 0;

        }

        /// <summary>
        /// Constructor with parameters of class Customer
        /// </summary>
        /// <param name="name">Customer's name</param>
        /// <param name="contactPhone">Customer's contact phone</param>
        /// <param name="revenue">Customer's  revenue</param>
        public Customer(string name, string contactPhone, decimal revenue)
        {
            Name = name;
            ContactPhone = contactPhone;
            Revenue = revenue;
        }
        #endregion


        #region ToString-methods
        /// <summary>
        /// Returns string representation of Customer
        /// </summary>
        /// <returns>String representation of Customer</returns>
        public override string ToString()
        {
            return this.ToString(null, null);
        }

        /// <summary>
        /// Returns string representation of Customer
        /// </summary>
        /// <param name="format">A format string for Customer object</param>
        /// <returns>String representation of Customer</returns>
        /// <exception cref="FormatException">The format string is invalid</exception>
        public string ToString(string format)
        {
            return this.ToString(format, null);
        }

        /// <summary>
        /// Returns string representation of Customer
        /// </summary>
        /// <param name="format">A format string for Customer object</param>
        /// <param name="formatProvider">An object that supplies specific formatting information</param>
        /// <returns>String representation of Customer</returns>
        /// <exception cref="FormatException">The format string is invalid</exception>
        public string ToString(string format, IFormatProvider formatProvider)
        {   
            if (String.IsNullOrEmpty(format)) format = "G";
            format = format.Trim().ToUpperInvariant();

            if (formatProvider == null)
                formatProvider = NumberFormatInfo.InvariantInfo;

            switch (format)
            {
                case "G":
                case "NRP": return $"Customer record: {Name}, {Revenue.ToString("0,0.00", formatProvider)}, {ContactPhone}";
                case "P":   return $"Customer record: {ContactPhone}";
                case "NR":  return $"Customer record: {Name}, {Revenue.ToString("0,0.00", formatProvider)}";
                case "N":   return $"Customer record: {Name}";
                case "R":   return $"Customer record: {Revenue}";
                default:
                            throw new FormatException($"The {format} format specifier is not supported.");
            }
        }
        #endregion
    }
}
