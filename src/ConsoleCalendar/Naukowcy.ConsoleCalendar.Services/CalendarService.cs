using Naukowcy.ConsoleCalendar.Domain.Entities;

namespace Naukowcy.ConsoleCalendar.Services
{
    public class CalendarService
    {
        private readonly Menu _menu = Menu.Instance; 

        public void Run()
        {
            _menu.Draw();
        }
    }
}
