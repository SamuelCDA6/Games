using System;
using System.Threading;

namespace Games
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] games = { "Mastermind", "Tic-Tac-Toe" };

            int choice = UpdateMenu(games);

            if (choice == 0)
            {
                TicTacToe();
            }
            else if (choice == 1)
            {

            }
        }

        /// <summary>
        /// Affiche le Menu de selection des jeux
        /// </summary>
        /// <param name="games">liste des jeux</param>
        /// <param name="posCursor">position dans le choix du jeu</param>
        static void DisplayMenu(string[] games, int posCursor)
        {
            Console.SetWindowSize(80, 20 + (games.Length) * 3);

            Console.Clear();
            Console.Write(("").PadRight(20, ' '));
            Console.WriteLine(("").PadRight(35, '_'));
            Console.Write(("").PadRight(20, ' '));
            Console.WriteLine("|                                 |");
            Console.Write(("").PadRight(20, ' '));
            Console.WriteLine("|       Jeux de Samuel Chapel     |");
            Console.Write(("").PadRight(20, ' '));
            Console.WriteLine("|_________________________________|");

            Console.WriteLine("\n\n");                      

            for (int i = 0; i < games.Length; i++)
            {
                if (posCursor == i)
                {
                    Console.Write(("").PadRight(15, ' '));
                    Console.WriteLine("\u2192 " + games[i]);
                }
                else
                {
                    Console.Write(("").PadRight(15, ' '));
                    Console.WriteLine("  " + games[i]);
                }

                Console.WriteLine("\n");
            }
                                    
        }

        /// <summary>
        /// Met a jour le menu des selection des jeux
        /// </summary>
        /// <param name="games">liste des jeux</param>
        /// <returns></returns>
        static int UpdateMenu(string[] games)
        {
            ConsoleKeyInfo keyPressed;

            int posCursor = 0;

            do
            {
                
                DisplayMenu(games, posCursor);

                keyPressed = Console.ReadKey();

                if (keyPressed.Key == ConsoleKey.DownArrow)
                {
                    if (posCursor < games.Length)
                    {
                        posCursor++;
                    }
                }
                else if (keyPressed.Key == ConsoleKey.UpArrow)
                {
                    if (posCursor > -1)
                    {
                        posCursor--;
                    }
                }

            } while (keyPressed.Key != ConsoleKey.Enter);

            return posCursor;
        }

        /// <summary>
        /// Jeu du Tic-Tac-Toe
        /// </summary>
        static void TicTacToe()
        {

            do
            {
                char[] cells = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
                int choice;
                int player = 1;
                int winner;

                Console.OutputEncoding = System.Text.Encoding.Unicode;
                Console.SetWindowSize(50, 20);

                do
                {
                    InitializeDisplay(cells);

                    Console.WriteLine("\n Entrez la position : ");
                    do
                    {
                        choice = int.Parse(Console.ReadLine());

                    } while (choice > 9 || choice < 1);

                    if (cells[choice] != 'X' && cells[choice] != 'O')
                    {
                        if (player % 2 == 0)
                        {
                            cells[choice] = 'O';
                        }
                        else
                        {
                            cells[choice] = 'X';
                        }

                        player++;
                    }

                    winner = TestWin(cells);

                } while (winner == 0 && player < 10);


                InitializeDisplay(cells, winner);

            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);



        }

        /// <summary>
        /// Initialise l'affichage a chaque tour du Tic-Tac-Toe
        /// </summary>
        /// <param name="cases">tableau des cases du tic-tac-toe</param>
        static void InitializeDisplay(char[] cells)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine(("").PadRight(19, '_'));
            Console.WriteLine("|                 |");
            Console.WriteLine("|   Tic-Tac-Toe   |");
            Console.WriteLine("|_________________|");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(("").PadRight(19, '_'));



            int i = 0;
            do
            {
                Console.WriteLine("|     |     |     |");
                Console.WriteLine("|  {0}  |  {1}  |  {2}  |", cells[i + 1], cells[i + 2], cells[i + 3]);
                Console.WriteLine("|_____|_____|_____|");
                i += 3;
            } while (i < 9);


        }

        /// <summary>
        /// Initialise l'affichage à la fin de la partie du Tic-Tac-Toe
        /// </summary>
        /// <param name="cells">tableau des cases du tic-tac-toe</param>
        /// <param name="winner">le numéro du gagnant</param>
        static void InitializeDisplay(char[] cells, int winner)
        {
            InitializeDisplay(cells);

            if (winner == 0)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n * Egalité *");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n * Bravo Joueur " + winner + " *");
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Voulez-vous rejouer ? (escape pour quitter)");

        }

        /// <summary>
        /// Test si il y a un gagnant au Tic-Tac-Toe
        /// </summary>
        /// <param name="cells">tableau des cases du tictactoe</param>
        /// <returns>le numero du gagnant  ou 0 si pas de gagnant</returns>
        static int TestWin(char[] cells)
        {
            int winner = 0;

            #region Test Horizontal
            if (cells[1] == cells[2] && cells[1] == cells[3])
            {
                if (cells[1] == 'X')
                {
                    winner = 1;
                }
                else
                {
                    winner = 2;
                }
            }
            else if (cells[4] == cells[5] && cells[4] == cells[6])
            {
                if (cells[4] == 'X')
                {
                    winner = 1;
                }
                else
                {
                    winner = 2;
                }
            }
            else if (cells[7] == cells[8] && cells[7] == cells[9])
            {
                if (cells[7] == 'X')
                {
                    winner = 1;
                }
                else
                {
                    winner = 2;
                }
            }
            #endregion

            #region Test Vertical
            else if (cells[1] == cells[4] && cells[1] == cells[7])
            {
                if (cells[1] == 'X')
                {
                    winner = 1;
                }
                else
                {
                    winner = 2;
                }
            }
            else if (cells[2] == cells[5] && cells[2] == cells[8])
            {
                if (cells[2] == 'X')
                {
                    winner = 1;
                }
                else
                {
                    winner = 2;
                }
            }
            else if (cells[3] == cells[6] && cells[3] == cells[9])
            {
                if (cells[3] == 'X')
                {
                    winner = 1;
                }
                else
                {
                    winner = 2;
                }
            }
            #endregion

            #region Test Diagonal
            else if (cells[1] == cells[5] && cells[1] == cells[9])
            {
                if (cells[1] == 'X')
                {
                    winner = 1;
                }
                else
                {
                    winner = 2;
                }
            }
            else if (cells[3] == cells[5] && cells[3] == cells[7])
            {
                if (cells[3] == 'X')
                {
                    winner = 1;
                }
                else
                {
                    winner = 2;
                }
            }
            #endregion

            return winner;
        }
    }
}
