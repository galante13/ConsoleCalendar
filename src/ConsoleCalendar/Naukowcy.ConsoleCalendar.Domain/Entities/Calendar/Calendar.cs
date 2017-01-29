using System.Collections;
using System.Collections.Generic;

namespace Naukowcy.ConsoleCalendar.Domain.Entities.Calendar
{
    public sealed class Calendar
    {
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
    }
}
