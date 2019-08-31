using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace LocalNetworkHardwareManagement.Core.Helpers
{
    public static class DateConvertor
    {
        public static string ToShamsi(this DateTime value)
        {
            PersianCalendar pc=new PersianCalendar();
            return pc.GetYear(value) + "/" + pc.GetMonth(value).ToString("00") + "/" +
                   pc.GetDayOfMonth(value).ToString("00");
        }

        public static string ToShamsi(this DateTime? value)
        {
            if (value.HasValue)
            {
                return value.Value.ToShamsi();
            }

            return "Error: Null Value";
        }

        public static DateTime ConvertShamsiToDate(this string value)
        {
            string[] dates = value.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

            return new DateTime(int.Parse(dates[0]),
                int.Parse(dates[1]),
                int.Parse(dates[2]),
                new PersianCalendar()
            );
        }
    }
}
