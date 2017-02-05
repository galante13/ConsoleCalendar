using System;
using Naukowcy.ConsoleCalendar.Domain.Entities;

namespace Naukowcy.ConsoleCalendar.Services
{
    public class CalendarService
    {
        public void Run()
        {
            Menu.Instance.Draw();
            NodeOption? option;
            do
            {
                option = ReadOption();

            } while (!option.HasValue);

            Menu.Instance.ChooseOption(option.Value);

            Run();
        }

        private NodeOption? ReadOption()
        {
            var userOption = Console.ReadLine();

            NodeOption nodeOption;

            if (!Enum.TryParse(userOption, out nodeOption))
            {
                Console.WriteLine($"Cannot choose option {userOption}");
                return null;
            }

            return nodeOption;
        }
    }
}
