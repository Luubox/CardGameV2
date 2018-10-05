using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kortSpilConsole
{
    class Deck
    {
        private List<Card> _cards = new List<Card>();
        private readonly List<Card> _cardsRevealed = new List<Card>();
        private Game _game;

        public Deck(Game game)
        {
            this._game = game;
            for (int i = 0; i < 10; i++)
            {
                _cards.Add(new Card("Red", i));
                _cards.Add(new Card("Blue", i));
                _cards.Add(new Card("Green", i));
                _cards.Add(new Card("Yellow", i));
                if (i != 0)
                {
                    _cards.Add(new Card("Red", i));
                    _cards.Add(new Card("Blue", i));
                    _cards.Add(new Card("Green", i));
                    _cards.Add(new Card("Yellow", i));
                }
            }
            Shuffle();
            _cardsRevealed.Add(Draw());
        }

        public Card Draw()
        {
            Card drawnCard = _cards[0]; 
            _cards.Remove(drawnCard); 
            return drawnCard; 
        }

        public bool PlayCard(Card card, Player player)
        {
            if (card.Colour == _cardsRevealed.Last().Colour || card.Value == _cardsRevealed.Last().Value)
            {
                _cardsRevealed.Add(card);
                player.Hand.Remove(card);
                return true;
            }
            else return false;
        }

        public Card Peek()
        {
            return _cardsRevealed.Last();
        }

        public void Shuffle()
        {
            Random random = new Random();
            _cards = _cards.OrderBy(x => random.Next()).ToList();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var card in _cards)
            {
                sb.Append(card);
                sb.Append("; ");
            }
            return sb.ToString();
        }
    }
}
