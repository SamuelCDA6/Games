using System;
using System.Threading;

namespace Games
{
    class Program
    {
        static void Main()
        {
            // Hangman.Start();
            string[] games = { "Mastermind", "Tic-Tac-Toe", "Pendu" };

            int posCursor = 0;

            do
            {
                Console.CursorVisible = false;

                posCursor = UpdateMenu(games, posCursor);

                if (posCursor == 0)
                {
                    Mastermind.Start();
                }
                else if (posCursor == 1)
                {
                    TicTacToe.Start();
                }
                else if (posCursor == 2)
                {
                    Hangman.Start();
                }

            } while (posCursor != -1);
        }

        /// <summary>
        /// Affiche le Menu de selection des jeux
        /// </summary>
        /// <param name="games">liste des jeux</param>
        /// <param name="posCursor">position dans le choix du jeu</param>
        static void DisplayMenu(string[] games, int posCursor)
        {
            Console.SetWindowSize(80, 15 + (games.Length) * 2);

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write(("").PadRight(20, ' '));
            Console.WriteLine(("").PadRight(35, '_'));
            Console.Write(("").PadRight(20, ' '));
            Console.WriteLine("|                                 |");
            Console.Write(("").PadRight(20, ' '));
            Console.WriteLine("|          Jeux de Samuel         |");
            Console.Write(("").PadRight(20, ' '));
            Console.WriteLine("|_________________________________|");

            Console.WriteLine("\n");

            for (int i = 0; i < games.Length; i++)
            {

                Console.Write(("").PadRight(15, ' '));

                if (posCursor == i)
                {

                    Console.ForegroundColor = ConsoleColor.Green;
                    //Console.Write("\u2192 ");

                    Console.WriteLine(games[i]);

                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Gray;

                    Console.WriteLine(games[i]);
                }

                Console.WriteLine();
            }

            Console.WriteLine("\n (Echap pour quitter)");

        }              

        /// <summary>
        /// Met a jour le menu des selection des jeux
        /// </summary>
        /// <param name="games">liste des jeux</param>
        /// <returns></returns>
        static int UpdateMenu(string[] games, int posCursor)
        {
            ConsoleKeyInfo keyPressed;

            do
            {
                DisplayMenu(games, posCursor);

                keyPressed = Console.ReadKey();

                if (keyPressed.Key == ConsoleKey.DownArrow)
                {
                    if (posCursor < games.Length - 1)
                    {
                        posCursor++;
                    }
                }
                else if (keyPressed.Key == ConsoleKey.UpArrow)
                {
                    if (posCursor > 0)
                    {
                        posCursor--;
                    }
                }
                else if (keyPressed.Key == ConsoleKey.Escape)
                {
                    posCursor = -1;
                }

            } while (keyPressed.Key != ConsoleKey.Enter && keyPressed.Key != ConsoleKey.Escape);

            return posCursor;
        }


    }
}
