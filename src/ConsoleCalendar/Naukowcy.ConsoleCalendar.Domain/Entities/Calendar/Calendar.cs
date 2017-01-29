using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;

namespace Naukowcy.ConsoleCalendar.Domain.Entities
{
    public sealed class Calendar
    {
        private const string Gap = " ";

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

        public void Draw()
        {
            DrawCalendarHeader();
        }

        private void DrawCalendarHeader()
        {
            var names = CultureInfo.CurrentCulture.DateTimeFormat.AbbreviatedDayNames;

            var header = string.Join(Gap, names);

            Console.Write(header);
        }
    }
}
