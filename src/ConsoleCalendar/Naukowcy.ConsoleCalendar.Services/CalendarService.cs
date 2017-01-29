using System;
using Naukowcy.ConsoleCalendar.Domain.Entities;

namespace Naukowcy.ConsoleCalendar.Services
{
    public class CalendarService
    {
        private readonly Menu _menu = Menu.Instance; 

        public void Run()
        {
            Calendar.Instance.DrawMonth(DateTime.Today.AddMonths(1));
        }
    }
}
