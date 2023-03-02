using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace CMP1903M_A01_2223
{
    internal class Pack
    {
        //'Pack.cs' class includes the 'cards' array and 'pointer' attributes for the 'Pack' object. 
        public static Card[] cards = new Card[52];
        public static int pointer;

        //'createPack' method as part of the 'Pack.cs' class. Supposed to assign values to the 'cards' array and 'pointer' attributes.
        public static void createPack()
        {
            //Initialise the card pack here
            /*52 cards in a pack, 4 types, and 13 cards per type. 
             * Potentially use two seperate arrays and have them match up in the program.
             * Inlude pointer class for outputting (dealing) cards to the console.
             */
            int index = 0;
            foreach (string suit in Card.SuitArray)
            {
                for (int value = 1; value <= 13; value++)
                {
                    Card card = new Card(value, suit);
                    cards[index] = card;
                    index++;
                }
            }
            pointer = 0;
        }

        public static void shuffleCardPack(int typeOfShuffle)
        {
            /*Types of shuffles that need to be included
             * Fisher-Yates shuffle: Keep randomly choosing an element (card) from the original sequence, and then adding it to a new sequence until the original sequence is empty; assign shuffled sequence to original sequence variable header to finish. 
             * Riffle Shuffle: Half the array containing the cards, and then take the first from the array from each side, continueing until all cards are in pack with alternating pattern between two halves. 
             * No Shuffle: Return the pack of cards how they are, without shuffling them. 
             */

            if (typeOfShuffle == 1) //'typeOfShuffle', 1 is Fisher-Yates Shuffle.
            {
                Console.WriteLine("The Fisher-Yates shuffled card order now looks like this: ");
                Card[] shuffledDeck = new Card[52];
                Random rnd = new Random();
                for (int i = 0; i <= 51;)
                {
                    int random = rnd.Next(0, 52);
                    if (shuffledDeck.Contains<Card>(cards[random]) != true)
                    {
                        Card temp = cards[random];
                        shuffledDeck[i] = temp;
                        i++;
                    }
                }
                for (int i = 0; i < 52; i++)
                {
                    cards[i] = shuffledDeck[i];
                }
                //Will print shuffled pack to the console.
                Pack.printCards();
            }
            
            if (typeOfShuffle == 2) //'typeOfShuffle', 2 is Riffle Shuffle.
            {
                Console.WriteLine("The Riffle shuffled card order now looks like this: ");
                Card[] shuffledDeck = new Card[52];
                Random rnd = new Random();
                int random = rnd.Next(5, 10);
                for (int j = 0; j <= random; j++)
                {
                    int initial = 0;
                    int mid = 21;
                    for (int i = 0; i < 52;)
                    {
                        Card temp = cards[initial];
                        shuffledDeck[i] = temp;
                        initial++;
                        i++;
                        temp = cards[mid];
                        shuffledDeck[i] = temp;
                        mid++;
                        i++;
                    }
                    for (int i = 0; i < 52; i++)
                    {
                        cards[i] = shuffledDeck[i];
                    }
                }
                //Will print shuffled pack to the console.
                Pack.printCards();
            }

            if (typeOfShuffle == 3) //'typeOfShuffle', 3 is No Shuffle.
            {
                //Will print unshuffled pack to the console.
                Console.WriteLine("The No Shuffle card order now looks like this: ");
                Pack.printCards();
            }
        }
        //'printCards' method as part of the 'Pack.cs' class. Supposed to print entire deck when it has been shuffled in the 'shuffleCardPack' method.
        public static void printCards()
        {
            for (int i = 0; i < 52; i++)
            {
                Console.WriteLine($"{cards[i].Value} {cards[i].Suit}");
                Console.Write("\n");
            }
        }
        //'dealCard' method as part of the 'Pack.cs' class. Supposed to deal one card to console.
        public static string dealCard()
        {
            string completion = "";
            //if statement that triggers if there is enough cards to output one card to console.
            if (pointer < 52)
            {
                //Outputs one card to console, increments the pointer, and will return the 'completion' status for the 'testing.cs' class to handle.
                Console.WriteLine($"Card being dealt is: {cards[pointer].Value} {cards[pointer].Suit}.");
                pointer++;
                completion = "t";
                return completion;
            }
            //if statement that triggers if there are no cards in the deck.
            if (pointer >= 52)
            {
                //Will return the 'completion' status for the 'testing.cs' class to handle.
                completion = "f";
                return completion;
            }
            //Will return empty and the program will keep running.
            return completion;
        }
        //'deal' method as part of the 'Pack.cs' class. Supposed to deal the passed in 'amount' value of cards to the console.
        public static string deal(int amount)
        {
            string completion = "";
            int estimatePointer = pointer + amount;
            //if statement that triggers if there enough cards to output the inputted 'amount'.
            if (estimatePointer < 52)
            {
                //for loop to output the stated 'amount' of cards to the console.
                for (int i = pointer; i < estimatePointer; i++)
                {
                    Console.WriteLine($"Card being dealt is: {cards[i].Value} {cards[i].Suit}.");
                }
                //Sets new pointer location and will return the 'completion' status for the 'testing.cs' class to handle.
                pointer = estimatePointer;
                completion = "t";
                return completion;
            }
            //if statement that triggers if there still cards, but not enough to output the inputted 'amount'.
            if (estimatePointer >= 52)
            { 
                //Will return the 'completion' status for the 'testing.cs' class to handle.
                completion = "r";
                return completion;
            }
            //if statement that triggers if there are no cards in the deck.
            if (pointer >= 52)
            {
                //Will return the 'completion' status for the 'testing.cs' class to handle.
                completion = "f";
                return completion;
            }
            //Will return empty and the program will keep running.
            return completion;
        }
    }
}
