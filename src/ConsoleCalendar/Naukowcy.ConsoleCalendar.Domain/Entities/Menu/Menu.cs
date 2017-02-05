using System;
using System.Collections.Generic;
using System.Linq;

namespace Naukowcy.ConsoleCalendar.Domain.Entities
{
    public sealed class Menu
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
            InitNodes();
        }

        public ICollection<Node> Nodes { get; private set; }

        private static volatile Menu _instance;
        private static readonly object SyncRoot = new object();

        public void Draw()
        {
            Console.WriteLine("Please choose an option to proceed: ");

            foreach (var node in Nodes)
            {
                node.Draw();
                Console.WriteLine();
            }
        }

        public void ChooseOption(NodeOption option)
        {
            var node = Nodes.SingleOrDefault(x => x.OptionId == option);

            if (node == null)
            {
                //TODO Handle error
                return;
            }

            node.OnOptionChosen();
        }

        private void InitNodes()
        {
            Nodes = new List<Node>();

            //TODO onOptionChosen

            Nodes.Add(new Node("Show today.", NodeOption.ShowToday, Calendar.Instance.ShowToday));
            Nodes.Add(new Node("Show actual month.", NodeOption.ShowActualMonth, Calendar.Instance.ShowActualMonth));
            Nodes.Add(new Node("Show given month.", NodeOption.ShowGivenMonth, Calendar.Instance.ShowGivenMonth));
            Nodes.Add(new Node("Add note.", NodeOption.AddNote, Calendar.Instance.AddNote));
            Nodes.Add(new Node("Show note.", NodeOption.ShowNotes, Calendar.Instance.ShowNotes));
            Nodes.Add(new Node("Close.", NodeOption.Close, Calendar.Instance.Close));

        }

    }
}
