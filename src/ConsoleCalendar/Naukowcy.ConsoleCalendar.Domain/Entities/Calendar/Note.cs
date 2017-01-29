using System;

namespace Naukowcy.ConsoleCalendar.Domain.Entities.Calendar
{
    public class Note
    {
        public Note(
            string content,
            DateTime date)
        {
            Content = content;
            Date = date;
        }
        public int Id { get; set; }

        public string Content { get; private set; }
        public DateTime Date { get; private set; }

        public void Draw()
        {
            Console.Write(Content);
        }
    }
}
