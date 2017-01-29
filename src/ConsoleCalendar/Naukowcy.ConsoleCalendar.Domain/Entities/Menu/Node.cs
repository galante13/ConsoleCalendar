using System;

namespace Naukowcy.ConsoleCalendar.Domain.Entities
{
    public class Node
    {
        public string Message { get; private set; }
        public NodeOption OptionId { get; private set; }
        public Action OnOptionChosen { get; private set; }

        public Node(
            string message,
            NodeOption optionId,
            Action onOptionChosen)
        {
            Message = message;
            OptionId = optionId;
            OnOptionChosen = onOptionChosen;
        }

        public void Draw()
        {
            //TODO Implement
        }
    }

    public enum NodeOption
    {
        ShowToday = 1,
        ShowActualMonth = 2,
        ShowGivenMonth = 3,
        AddNote = 4,
        ShowNotes = 5,
        Close = 6
    }
}
