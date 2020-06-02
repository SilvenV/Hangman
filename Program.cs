using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangmanTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = { "cat", "dog",
                               "soap", "roar", "beer", "glee", "home", 
                               "state", "blast", "beast", 
                               "droves", "fables", 
                               "machine", 
                               "backfire", 
                               "onslaught", 
                               "aftershock", "occupation", "mastermind" };
            bool goAgain = true;

            while (goAgain)
            {
                Random rand = new Random();
                string testWord = words[rand.Next(words.Length)];
                bool wordGuessed = false;
                int guesses = 0;
                int letterCount = -1;


                StringBuilder testGuess = new StringBuilder("", testWord.Length);
                for (int i = 0; i < testWord.Length; i++)
                {
                    testGuess.Append(".");
                }

                Console.WriteLine("Guess a letter:");
                Console.WriteLine(testGuess);

                while (guesses < 6)
                {
                    string guess = Console.ReadLine();
                    if (guess.Length != 1)
                    {
                        Console.WriteLine("Please enter a single letter.");
                    }
                    else
                    {
                        char guessChar = char.Parse(guess);

                        if (testWord.IndexOf(guess) != -1)
                        {
                            foreach (char c in testWord)
                            {
                                letterCount++;
                                if (c.Equals(guessChar))
                                {
                                    testGuess[letterCount] = guessChar;
                                }

                            }
                            //testGuess[testWord.IndexOf(guess)] = guessChar; - Remnant of previous code, safekeeping.
                            Console.WriteLine(testGuess + "\n");
                            letterCount = -1;
                        }
                        else
                        {
                            Console.WriteLine($"The word does not contain the letter {guess}.");
                            guesses++;
                            Console.WriteLine($"You have {6 - guesses} guess(es) left. \n");
                        }
                        string testGuessStr = testGuess.ToString();
                        if (String.Compare(testWord, testGuessStr) == 0)
                        {
                            wordGuessed = true;
                            break;
                        }
                    }
                }
                if (guesses == 6)
                {
                    Console.WriteLine($"You didn't guess the word, it was {testWord}.");
                }
                else if (wordGuessed)
                {
                    Console.WriteLine($"You succesfully guessed the word, it was {testWord}!");
                }
                else
                {
                    Console.WriteLine("How did you get here?");
                }
                Console.WriteLine("Want to try again? Y/N");
                string answer = Console.ReadLine().ToUpper();
                if (answer == "Y")
                {
                    goAgain = true;
                    Console.Clear();
                }
                else
                {
                    goAgain = false;
                }
            }
            Console.WriteLine("See you next time.");
            Console.ReadLine();
        }
    }
}
