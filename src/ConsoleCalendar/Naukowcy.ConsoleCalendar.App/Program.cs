﻿using System;
using Naukowcy.ConsoleCalendar.Services;

namespace Naukowcy.ConsoleCalendar.App
{
    class Program
    {
        static void Main(string[] args)
        {
            new CalendarService().Run();

            Console.ReadKey();
        }
    }
}
