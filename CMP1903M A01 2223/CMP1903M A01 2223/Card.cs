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
        public int Value;
        public static string[] SuitArray = new string[] { "Hearts", "Diamonds", "Clubs", "Spades" };
        public string Suit;

        //'Card' method used to assign 'Value' and 'Suit' attributes to the object.
        public Card(int value, string suit)
        {
            Value = value;
            Suit = suit;
        }
        //'Card' method used to swap out assigned attribute values for user friendly 'temp' values that are used to output the values to console.
        public Card(string input)
        {
            string temp = "";
            string suitSetence = "";
            switch (Value)
            {
                case 1:
                    temp = "Ace";
                    break;
                case 11:
                    temp = "Jack";
                    break;
                case 12:
                    temp = "Queen";
                    break;
                case 13:
                    temp = "King";
                    break;
                default:
                    temp = Value.ToString();
                    break;
            }
            switch (Suit)
            {
                case "Hearts":
                    suitSetence = " of Hearts";
                    break;
                case "Diamonds":
                    suitSetence = " of Diamonds";
                    break;
                case "Clubs":
                    suitSetence = " of Clubs";
                    break;
                case "Spades":
                    suitSetence = " of Spades";
                    break;
            }
            input = temp + suitSetence;
        }
    }
}