using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games
{
    class Hangman
    {

        public static void Start()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetWindowSize(60, 20);

            string[] wordsHangman = System.IO.File.ReadAllLines(@"C:\Users\cda06chap\Documents\motsPendu.txt");


            //string word = "ABC";

            char[] letters = new[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

            do
            {
                Random random = new();
                int numWord = random.Next(wordsHangman.Length);

                string word = wordsHangman[numWord];

                int fautes = 0;
                int nbLettersFound = 0;

                bool[] lettersUsed = new bool[letters.Length];

                bool[] lettersFound = new bool[word.Length];

                do
                {
                    UpdateDisplay(word, letters, lettersUsed, lettersFound, fautes);

                    ConsoleKeyInfo keyPressed;
                    int numLetter;
                    do
                    {
                        keyPressed = Console.ReadKey(true);
                        numLetter = (int)keyPressed.KeyChar - 97;
                    } while (numLetter < 0 || numLetter > 25 || lettersUsed[numLetter]);

                    lettersUsed[numLetter] = true;

                    // Verifier si la lettre est dans le mot
                    bool correctLetter = false;

                    for (int i = 0; i < word.Length; i++)
                    {
                        if (!lettersFound[i] && word[i] == letters[numLetter]) // Si la lettre n'a pas encore été trouvée
                        {
                            lettersFound[i] = true;
                            nbLettersFound++;
                            correctLetter = true;
                        }
                    }

                    if (!correctLetter)
                    {
                        fautes++;
                    }

                } while (fautes < 8 && nbLettersFound < word.Length);

                EndDisplay(word, letters, lettersUsed, lettersFound, nbLettersFound, fautes);

            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);


        }

        /// <summary>
        /// Gère l'affichage à tout les tours
        /// </summary>
        /// <param name="word"></param>
        /// <param name="letters"></param>
        /// <param name="lettersUsed"></param>
        /// <param name="lettersFound"></param>
        static void UpdateDisplay(string word, char[] letters, bool[] lettersUsed, bool[] lettersFound, int turnNb)
        {

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;

            Console.Write(("").PadRight(15, ' '));
            Console.WriteLine(("").PadRight(19, '_'));
            Console.Write(("").PadRight(15, ' '));
            Console.WriteLine("|                 |");
            Console.Write(("").PadRight(15, ' '));
            Console.WriteLine("|      Pendu      |");
            Console.Write(("").PadRight(15, ' '));
            Console.WriteLine("|_________________|\n");

            //Console.WriteLine(word + "\n");

            Console.ForegroundColor = ConsoleColor.Magenta;
            switch (turnNb)
            {                
                case 0:
                    Console.WriteLine("      ");
                    Console.WriteLine("      |");
                    Console.WriteLine("      |");
                    Console.WriteLine("      |");
                    Console.WriteLine("      |");
                    Console.WriteLine("    __|__\n");
                    break;
                case 1:
                    Console.WriteLine("      _____");
                    Console.WriteLine("      |/");
                    Console.WriteLine("      |");
                    Console.WriteLine("      |");
                    Console.WriteLine("      |");
                    Console.WriteLine("    __|__\n");
                    break;
                case 2:
                    Console.WriteLine("      _____");
                    Console.WriteLine("      |/   |");
                    Console.WriteLine("      |");
                    Console.WriteLine("      |");
                    Console.WriteLine("      |");
                    Console.WriteLine("    __|__\n");
                    break;
                case 3:
                    Console.WriteLine("      _____");
                    Console.WriteLine("      |/   |");
                    Console.WriteLine("      |    O");
                    Console.WriteLine("      |");
                    Console.WriteLine("      |");
                    Console.WriteLine("    __|__\n");
                    break;
                case 4:
                    Console.WriteLine("      _____");
                    Console.WriteLine("      |/   |");
                    Console.WriteLine("      |    O");
                    Console.WriteLine("      |    |");
                    Console.WriteLine("      |");
                    Console.WriteLine("    __|__\n");
                    break;
                case 5:
                    Console.WriteLine("      _____");
                    Console.WriteLine("      |/   |");
                    Console.WriteLine("      |    O");
                    Console.WriteLine("      |   /|");
                    Console.WriteLine("      |");
                    Console.WriteLine("    __|__\n");
                    break;
                case 6:
                    Console.WriteLine("      _____");
                    Console.WriteLine("      |/   |");
                    Console.WriteLine("      |    O");
                    Console.WriteLine("      |   /|\u005c ");
                    Console.WriteLine("      |");
                    Console.WriteLine("    __|__\n");
                    break;
                case 7:
                    Console.WriteLine("      _____");
                    Console.WriteLine("      |/   |");
                    Console.WriteLine("      |    O");
                    Console.WriteLine("      |   /|\u005c ");
                    Console.WriteLine("      |   / ");
                    Console.WriteLine("    __|__\n");
                    break;
                case 8:
                    Console.WriteLine("      _____");
                    Console.WriteLine("      |/   |");
                    Console.WriteLine("      |    O");
                    Console.WriteLine("      |   /|\u005c ");
                    Console.WriteLine("      |   / \u005c ");
                    Console.WriteLine("    __|__\n");
                    break;

            }


            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(("").PadRight(15, ' '));
            for (int i = 0; i < word.Length; i++)
            {
                if (lettersFound[i])
                {
                    Console.Write(word[i] + " ");
                }
                else
                {
                    Console.Write("_ ");
                }
            }
            Console.WriteLine("\n");


            for (int i = 0; i < letters.Length; i++)
            {
                if (!lettersUsed[i])
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(letters[i] + " ");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write(letters[i] + " ");
                }

            }
            Console.WriteLine("\n");

        }

        static void EndDisplay(string word, char[] letters, bool[] lettersUsed, bool[] lettersFound, int nbLettersFound, int turnNb)
        {
            UpdateDisplay(word, letters, lettersUsed, lettersFound, turnNb);

            if (nbLettersFound == word.Length)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"*Bravo vous avez trouver le mot {word}*");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Dommage! Le mot etait {word}");
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Voulez-vous rejouer ? (Echap pour quitter)");

        }
    }
}
