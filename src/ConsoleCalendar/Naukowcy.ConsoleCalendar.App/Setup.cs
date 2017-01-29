using System.Globalization;
using System.Threading;

namespace Naukowcy.ConsoleCalendar.App
{
    public static class Setup
    {
        public static void SetupCulture()
        {
            var culture = CultureInfo.CreateSpecificCulture("en-US");

            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
        }
    }
}
