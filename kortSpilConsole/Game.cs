using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kortSpilConsole
{
    class Game
    {
        public Deck Deck;
        public Player PlayerOne;
        public Player PlayerTwo;

        public Game()
        {
            PlayerOne = new Player(this, "Alpha");
            PlayerTwo = new Player(this, "Beta");
            Deck = new Deck(this);

            PlayerOne.DrawCard(7);
            PlayerTwo.DrawCard(7);

            while (PlayerOne.Hand.Count > 0 || PlayerTwo.Hand.Count > 0)
            {
                Turn(PlayerOne);
                Turn(PlayerTwo);
            }

            Console.WriteLine("game over");
        }

        private void Turn(Player player)
        {
            Console.WriteLine($"\nPile: {Deck.Peek()}");

            Console.WriteLine(player);
            Console.WriteLine("Choose a card or Pass:");

            string playerChoice = Console.ReadLine();
            if (playerChoice == "Pass")
            {
                player.DrawCard();
            }
            else if (Deck.PlayCard(player.Hand[Convert.ToInt32(playerChoice) - 1], player))
            {
                Console.WriteLine($"Pile: {Deck.Peek()}");
            }
            else
            {
                Console.WriteLine("Invalid card! try again");
                Turn(player);
            }
            if (player.Hand.Count == 0)
            {
                Console.WriteLine($"Congratulations {player.Name}! You have won!");
            }

            //bool playerChoice = Deck.PlayCard(player.Hand[Convert.ToInt32(Console.ReadLine())], player);
        }
    }
}
