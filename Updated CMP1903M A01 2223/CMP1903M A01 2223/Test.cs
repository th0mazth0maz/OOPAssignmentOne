using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static CMP1903M_A01_2223.Pack;

namespace CMP1903M_A01_2223
{
    public class Test
    {
        public static void TestEverything()
        {
            //Create boolean variables 'exitProgram' and 'exitPack' to control the flow of the testing program. 
            bool exitProgram = false;
            //while loop will hold the entirety of the test program. When 'exitProgram' is true and loop is exited, the console program should finish executing.
            while (exitProgram == false)
            {
                //Calls 'createPack' method, part of the 'Pack.cs' class. Supposed to create the pack of cards used for testing. 
                createPack();
                //bool exitPack dictates whether to continue with current pack 'false' or create a new pack 'true'.
                bool exitPack = false;
                Console.WriteLine("A new pack of cards has been created!");
                Console.WriteLine("Choose the type of shuffle, 'f' is Fisher-Yates Shuffle, 'r' is Riffle Shuffle, and 'n' is No Shuffle: ");
                string typeOfShuffle = "";
                //bool input dictates whether an input from console is valid.
                bool input = false;
                //while loop contains input validation for 'typeOfShuffle' variable.
                while (input == false)
                {
                    typeOfShuffle= Console.ReadLine();
                    if (typeOfShuffle == "f" || typeOfShuffle == "r" || typeOfShuffle == "n")
                    {
                        input = true;
                    }
                    else
                    {
                        Console.WriteLine("Please input valid option:");
                    }
                }
                //Calls 'shuffleCardPack' method, part of the 'Pack.cs' class. Supposed to shuffle the cards using the method specified by the 'typeOfShuffle' variable, previously inputted. 
                shuffleCardPack(typeOfShuffle);
                //while loop will hold the actions that can be carried out on a single instance of the 'cards' or pack of cards that has been generated. 
                while (exitPack == false)
                {
                    Console.WriteLine("Would you like to 'd' deal one card, 'm' deal multiple cards, or 'e' exit program?");
                    string choice = "";
                    //bool input dictates whether an input from console is valid.
                    input = false;
                    string completion = "";
                    //while loop contains input validation for 'choice' variable.
                    while (input == false)
                    {
                        choice = Console.ReadLine();
                        if (choice == "d" || choice == "m" || choice == "e")
                        {
                            input = true;
                        }
                        else
                        {
                            Console.WriteLine("Please input valid option:");
                        }
                    }
                    //if statement branches to call the 'dealCard' method which is part of the 'Pack.cs' class. Supposed to deal a single card to the console. 
                    if (choice == "d")
                    {
                        completion = dealCard();
                        //if statement to catch if the deck has ran out of cards, 'exitPack' is set to true, so that it will exit this pack and create another instance of 'cards'. Based on the 'completion' variable. 
                        if (completion == "f")
                        {
                            Console.WriteLine("Ran out of cards in the pack, creating new pack now...");
                            exitPack = true;
                        }
                    }
                    //if statement branches to call the 'deal' method which is part of the 'Pack.cs' class. Supposed to deal a set number of cards to the console based on the 'amount' variable. 
                    if (choice == "m")
                    {
                        bool enough = false;
                        while (enough == false)
                        {
                            Console.WriteLine("Input number of cards being dealt: ");
                            input = false;
                            int amount = 1;
                            //while loop contains input validation for 'amount' variable, to ensure that an integer number is inputted.
                            while (input == false)
                            {
                                string tempAmount = Console.ReadLine();
                                if (int.TryParse(tempAmount, out amount))
                                {
                                    input = true;
                                }
                                else
                                {
                                    Console.WriteLine("Please input valid number:");
                                }
                            }
                            completion = deal(amount);
                            //if statement to catch if the 'amount' of cards specific has been outputted to the console. Program will continue as normal. Based on the returned 'completion' variable. 
                            if (completion == "t")
                            {
                                enough = true;
                            }
                            //if statement to catch if there are still cards in the pack but not enough to output the 'amount' of cards specified. Based on the returned 'completion' variable. 
                            if (completion == "r")
                            {
                                enough = false;
                                Console.WriteLine("There's not enough cards in the pack... \n'n' if you want a new pack, or 'c' if you want to continue with current pack: ");
                                input = false;
                                //Ensures that a valid input has been inputted into the console. 
                                while (input == false)
                                {
                                    choice = Console.ReadLine();
                                    if (choice == "n" || choice == "c")
                                    {
                                        input = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Please input valid option: ");
                                    }
                                }
                                //if statement sets 'exitPack' to true, so that it will exit this pack and create another instance of 'cards'.
                                if (choice == "n")
                                {
                                    enough = true;
                                    exitPack = true;
                                }
                                //if statement to let the program run with the current pack of shuffled cards.
                                if (choice == "c")
                                {
                                    enough = true;
                                }
                            }
                            //if statement to catch if the deck has ran out of cards, 'exitPack' is set to true, so that it will exit this pack and create another instance of 'cards. Based on the returned 'completion' variable. 
                            if (completion == "f")
                            {
                                Console.WriteLine("There's no more cards in this pack...");
                                enough = true;
                                exitPack = true;
                            }
                        }

                    }
                    //if statement branches to stop the program and exit the console.
                    if (choice == "e")
                    {
                        exitPack = true;
                        exitProgram = true;
                        Console.WriteLine("Test program is closing...");
                        Environment.Exit(0);
                    }
                }
            }
        }
    }
}