using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text;

namespace Paraph_Food.Application.Services.Common.PersianDateTime
{
    public static class JalaliDateTime
    {
        private static CultureInfo _Culture;
        public static CultureInfo GetPersianCulture()
        {
            if (_Culture == null)
            {
                _Culture = new CultureInfo("fa-IR");
                DateTimeFormatInfo formatInfo = _Culture.DateTimeFormat;
                formatInfo.AbbreviatedDayNames = new[] { "ی", "د", "س", "چ", "پ", "ج", "ش" };

                formatInfo.DayNames = new[] { "یکشنبه", "دوشنبه", "سه شنبه", "چهار شنبه", "پنجشنبه", "جمعه", "شنبه" };
                var monthNames = new[]
                {
                    "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن",
                    "اسفند",
                    ""
                };
                formatInfo.AbbreviatedMonthNames =
                    formatInfo.MonthNames =
                    formatInfo.MonthGenitiveNames = formatInfo.AbbreviatedMonthGenitiveNames = monthNames;
                formatInfo.AMDesignator = "ق.ظ";
                formatInfo.PMDesignator = "ب.ظ";
                formatInfo.ShortDatePattern = "yyyy-MM-dd";
                formatInfo.LongDatePattern = "dddd, dd MMMM,yyyy";
                formatInfo.FirstDayOfWeek = DayOfWeek.Saturday;
                System.Globalization.Calendar cal = new PersianCalendar();

                FieldInfo fieldInfo = _Culture.GetType().GetField("calendar", BindingFlags.NonPublic | BindingFlags.Instance);
                if (fieldInfo != null)
                    fieldInfo.SetValue(_Culture, cal);

                FieldInfo info = formatInfo.GetType().GetField("calendar", BindingFlags.NonPublic | BindingFlags.Instance);
                if (info != null)
                    info.SetValue(formatInfo, cal);

                _Culture.NumberFormat.NumberDecimalSeparator = "/";
                _Culture.NumberFormat.DigitSubstitution = DigitShapes.NativeNational;
                _Culture.NumberFormat.NumberNegativePattern = 0;
            }
            return _Culture;
        }


        public static string ToStringJalaliDate(this DateTime date)
        {
            PersianCalendar pc = new PersianCalendar();

            var year = pc.GetYear(date);
            var month = pc.GetMonth(date).ToString();
            var day = pc.GetDayOfMonth(date).ToString();


            return string.Format("{0}-{1}-{2}", year,
                                                (month.Length == 1 ? "0" + month : month),
                                                (day.Length == 1 ? "0" + day : day));

        }

        public static string ToStringJalaliDate(this DateTime? date)
        {
            if (!date.HasValue)
                return null;

            PersianCalendar pc = new PersianCalendar();

            var year = pc.GetYear(date.Value);
            var month = pc.GetMonth(date.Value).ToString();
            var day = pc.GetDayOfMonth(date.Value).ToString();


            return string.Format("{0}-{1}-{2}", year,
                                                (month.Length == 1 ? "0" + month : month),
                                                (day.Length == 1 ? "0" + day : day));

        }

        public static string ToStringJalaliDateTime(this DateTime date)
        {
            PersianCalendar pc = new PersianCalendar();

            var year = pc.GetYear(date);
            var month = pc.GetMonth(date).ToString();
            var day = pc.GetDayOfMonth(date).ToString();

            var hour = pc.GetHour(date).ToString();
            var minute = pc.GetMinute(date).ToString();
            var second = pc.GetSecond(date).ToString();


            return string.Format("{0}-{1}-{2} {3}:{4}:{5}",
                                    year,
                                    (month.Length == 1 ? "0" + month : month),
                                    (day.Length == 1 ? "0" + day : day),
                                    (hour.Length == 1 ? "0" + hour : hour),
                                    (minute.Length == 1 ? "0" + minute : minute),
                                    (second.Length == 1 ? "0" + second : second)
                                );


        }

        public static string ToStringJalaliDateTime(this DateTime? date)
        {
            if (!date.HasValue)
                return null;

            PersianCalendar pc = new PersianCalendar();

            var year = pc.GetYear(date.Value);
            var month = pc.GetMonth(date.Value).ToString();
            var day = pc.GetDayOfMonth(date.Value).ToString();

            var hour = pc.GetHour(date.Value).ToString();
            var minute = pc.GetMinute(date.Value).ToString();
            var second = pc.GetSecond(date.Value).ToString();


            return string.Format("{0}-{1}-{2} {3}:{4}:{5}",
                                    year,
                                    (month.Length == 1 ? "0" + month : month),
                                    (day.Length == 1 ? "0" + day : day),
                                    (hour.Length == 1 ? "0" + hour : hour),
                                    (minute.Length == 1 ? "0" + minute : minute),
                                    (second.Length == 1 ? "0" + second : second)
                                );


        }

    }
}
