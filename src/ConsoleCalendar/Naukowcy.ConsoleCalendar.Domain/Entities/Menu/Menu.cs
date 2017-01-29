using System.Collections.Generic;

namespace Naukowcy.ConsoleCalendar.Domain.Entities
{
    public class Menu
    {
        public static Menu Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (SyncRoot)
                    {
                        if (_instance == null)
                        {
                            _instance = new Menu();
                        }
                    }
                }

                return _instance;
            }
        }

        private Menu()
        {
        }

        private static volatile Menu _instance;
        private static readonly object SyncRoot = new object();

        public ICollection<Node> Nodes { get; private set; }

    }
}
