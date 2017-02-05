using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

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

        private Calendar()
        {
            Notes = new List<Note>();
        }

        private static volatile Calendar _instance;
        private static readonly object SyncRoot = new object();

        public ICollection<Note> Notes { get; set; }

        public void DrawMonth(DateTime yearAndMonth)
        {
            DrawCalendarHeader();

            Console.WriteLine();

            DrawBody(yearAndMonth);
        }

        public void ShowToday()
        {
            Console.WriteLine(DateTime.Today);
        }

        public void ShowActualMonth()
        {
            DrawMonth(DateTime.Today);
        }

        public void ShowGivenMonth()
        {
            var month = ReadNumberDatePart("Month:");
            var year = ReadNumberDatePart("Year:");

            var date = new DateTime(year, month, 1);

            DrawMonth(date);
        }

        public void AddNote()
        {
            var day = ReadNumberDatePart("Day:");
            var month = ReadNumberDatePart("Month:");
            var year = ReadNumberDatePart("Year:");

            var date = new DateTime(year, month, day);
            var content = ReadString("Content");

            var note = new Note(content, date);

            Notes.Add(note);
        }

        public void ShowNotes()
        {
            var day = ReadNumberDatePart("Day:");
            var month = ReadNumberDatePart("Month:");
            var year = ReadNumberDatePart("Year:");

            var date = new DateTime(year, month, day);
            var notes = Notes.Where(x => x.Date.Date == date.Date);

            foreach (var note in notes)
            {
                note.Draw();
                Console.WriteLine();
            }

        }

        public void Close()
        {
            Environment.Exit(Environment.ExitCode);
        }

        private string ReadString(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }

        private short ReadNumberDatePart(string message)
        {
            Console.WriteLine(message);
            var partFromConsole = Console.ReadLine();

            short part;

            if (!Int16.TryParse(partFromConsole, out part))
            {
                //TODO handle error
            }
            //TODO should check scope of the part

            return part;
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

            var firstDayOfWeek = new DateTime(year, month, 1).DayOfWeek;
            var daysShift = (int)firstDayOfWeek;

            WriteGaps(firstDayOfWeek);

            for (int day = 1; day <= daysInMonth; day++)
            {
                WriteDay(day);

                if ((day + daysShift) % 7 == 0)
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

        private void WriteGaps(DayOfWeek day)
        {
            var dayGaps = (int) day;

            WriteGapsWithSkip(dayGaps);
        }

        private void WriteGapsWithSkip(int daysShift)
        {
            while (daysShift-- > 0)
            {
                WriteGaps();
            }
        }

        private void WriteGaps(int? day = null)
        {
            var gapsCount = GetGapsToFillDayContainerCount(day);

            while (gapsCount-- > 0)
            {
                Console.Write(Gap);
            }

            Console.Write(Gap);

        }

        private int GetGapsToFillDayContainerCount(int? day = null)
        {
            int daysLength = 0;

            if (day.HasValue)
            {
                daysLength = day.ToString().Length;
            }

            return DayContainerLength - daysLength;
        }

    }
}
