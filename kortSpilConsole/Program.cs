using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace kortSpilConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck myDeck = new Deck();
            Console.WriteLine(myDeck);

            Card c = myDeck.Draw();
            Console.WriteLine(c);
            Console.WriteLine("");
            Console.WriteLine(myDeck);

            Console.ReadLine();
        }
    }
}
