using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kortSpilConsole
{
    class Player
    {
        private Game _game;
        public List<Card> Hand = new List<Card>();

        public string Name { get; set; }

        public Player(Game game, string name)
        {
            _game = game;
            Name = name;
        }

        public void DrawCard()
        {
            Hand.Add(_game.Deck.Draw());
        }

        public void DrawCard(int numberOfCards)
        {
            for (int i = 0; i < numberOfCards; i++)
            {
                DrawCard();
            }
        }

        public override string ToString()
        {
            Console.Write($"Player: {Name},\tHand: ");
            StringBuilder sb = new StringBuilder();
            for (var i = 0; i < Hand.Count; i++)
            {
                sb.Append(Hand[i]);
                sb.Append(", ");
            }

            return sb.ToString();
        }
    }
}
