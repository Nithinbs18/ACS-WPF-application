﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace kitchenAndReadyOrders
{
    public class StatusChangeConvertor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int what = (int)value;
            if (what == 0)
            {
                return "Waiting" ;
            }
            else if (what == 1)
            {
                return "In Progress";
            }
            else if (what == 2)
            {
                return "Ready";
            }
            else 
            {
                return "Delivered";
            }

        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return true;
        }
    }
}
