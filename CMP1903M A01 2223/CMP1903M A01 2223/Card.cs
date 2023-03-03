using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    class Card
    {
        //'Card.cs' class includes the 'Value', 'SuitArray', and 'Suit' attributes for the 'Card' object.
        internal static string[] ValueArray = new string[] { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };
        internal string Value;
        internal static string[] SuitArray = new string[] { "of Hearts", "of Diamonds", "of Clubs", "of Spades" };
        internal string Suit;

        //'Card' method used to assign 'Value' and 'Suit' attributes to the object.
        public Card(string value, string suit)
        {
            Value = value;
            Suit = suit;
        }
    }
}