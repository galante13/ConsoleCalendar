using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;

namespace Naukowcy.ConsoleCalendar.Domain.Entities
{
    public sealed class Calendar
    {
        private const string Gap = " ";
        private static readonly int DayContainerLength = 3;

        public static Calendar Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (SyncRoot)
                    {
                        if (_instance == null)
                        {
                            _instance = new Calendar();
                        }
                    }
                }

                return _instance;
            }
        }

        private static volatile Calendar _instance;
        private static readonly object SyncRoot = new object();

        public ICollection<Note> Note { get; set; }

        public void DrawMonth(DateTime yearAndMonth)
        {
            DrawCalendarHeader();

            Console.WriteLine();

            DrawBody(yearAndMonth);
        }

        private void DrawCalendarHeader()
        {
            var names = CultureInfo.CurrentCulture.DateTimeFormat.AbbreviatedDayNames;

            var header = string.Join(Gap, names);

            Console.Write(header);
        }

        private void DrawBody(DateTime yearAndMonth)
        {
            var year = yearAndMonth.Date.Year;
            var month = yearAndMonth.Date.Month;

            var daysInMonth = DateTime.DaysInMonth(year, month);

            //var firstDayOfWeek = new DateTime(year, month, 1).DayOfWeek;
            //var daysShift = (int)firstDayOfWeek;

            for (int day = 1; day <= daysInMonth; day++)
            {
                WriteDay(day);

                if (day % 7 == 0)
                {
                    Console.Write(Environment.NewLine);
                }
            }
        }

        private void WriteDay(int day)
        {
            Console.Write(day);
            WriteGaps(day);
        }

        private void WriteGaps(int day)
        {
            var gapsCount = GetGapsToFillDayContainerCount(day);

            while (gapsCount-- > 0)
            {
                Console.Write(Gap);
            }

            Console.Write(Gap);

        }

        private int GetGapsToFillDayContainerCount(int day)
        {
            int daysLength = day.ToString().Length;

            return DayContainerLength - daysLength;
        }

    }
}
