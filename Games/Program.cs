using System;
using System.Threading;

namespace Games
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] games = { "Mastermind", "Tic-Tac-Toe" };
            
            int posCursor = 0;

            do
            {
                Console.CursorVisible = false;                

                posCursor = UpdateMenu(games, posCursor);

                if (posCursor == 0)
                {
                    TicTacToe.TicTacToeMain();
                }
                else if (posCursor == 1)
                {
                    TicTacToe.TicTacToeMain();
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
                if (posCursor == i)
                {
                    Console.Write(("").PadRight(15, ' '));
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("\u2192 ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine(games[i]);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(("").PadRight(15, ' '));
                    Console.WriteLine("  " + games[i]);
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
                else if(keyPressed.Key == ConsoleKey.Escape)
                {
                    posCursor = -1;
                }

            } while (keyPressed.Key != ConsoleKey.Enter && keyPressed.Key != ConsoleKey.Escape);

            return posCursor;
        }

        ///// <summary>
        ///// Jeu du Tic-Tac-Toe
        ///// </summary>
        //static void TicTacToe()
        //{

        //    do
        //    {
        //        char[] cells = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        //        int choice;
        //        int player = 1;
        //        int winner;

        //        Console.OutputEncoding = System.Text.Encoding.Unicode;
        //        Console.SetWindowSize(50, 20);

        //        do
        //        {
        //            InitializeDisplay(cells);

        //            ConsoleKeyInfo keyPressed;

        //            Console.Write("\n Tour du joueur " + player);

        //            do
        //            {
        //                keyPressed = Console.ReadKey();
                        
        //            } while ((int)keyPressed.KeyChar < 49 || (int)keyPressed.KeyChar > 57);

        //            choice = (int)keyPressed.KeyChar - 48;

        //            if (cells[choice] != 'X' && cells[choice] != 'O')
        //            {
        //                if (player == 1)
        //                {
        //                    player = 2;
        //                    cells[choice] = 'X';
        //                }
        //                else
        //                {
        //                    player = 1;
        //                    cells[choice] = 'O';
        //                }

        //            }

        //            winner = TestWin(cells);

        //        } while (winner == 0 && player < 10);


        //        InitializeDisplay(cells, winner);

        //    } while (Console.ReadKey(true).Key != ConsoleKey.Escape);

        //}

        ///// <summary>
        ///// Initialise l'affichage a chaque tour du Tic-Tac-Toe
        ///// </summary>
        ///// <param name="cases">tableau des cases du tic-tac-toe</param>
        //static void InitializeDisplay(char[] cells)
        //{
        //    Console.Clear();
        //    Console.ForegroundColor = ConsoleColor.DarkRed;

        //    Console.Write(("").PadRight(15,' '));
        //    Console.WriteLine(("").PadRight(19, '_'));
        //    Console.Write(("").PadRight(15, ' '));
        //    Console.WriteLine("|                 |");
        //    Console.Write(("").PadRight(15, ' '));
        //    Console.WriteLine("|   Tic-Tac-Toe   |");
        //    Console.Write(("").PadRight(15, ' '));
        //    Console.WriteLine("|_________________|\n");

        //    Console.ForegroundColor = ConsoleColor.DarkCyan;
        //    Console.Write(("").PadRight(10, ' '));
        //    Console.WriteLine(("").PadRight(19, '_'));

        //    int i = 0;
        //    do
        //    {
        //        Console.Write(("").PadRight(10, ' '));
        //        Console.WriteLine("|     |     |     |");
        //        Console.Write(("").PadRight(10, ' '));
        //        Console.Write("|  ");
        //        Console.ForegroundColor = ConsoleColor.Gray;
        //        Console.Write(cells[i + 1]);
        //        Console.ForegroundColor = ConsoleColor.DarkCyan;
        //        Console.Write("  |  ");
        //        Console.ForegroundColor = ConsoleColor.Gray;
        //        Console.Write(cells[i + 2]);
        //        Console.ForegroundColor = ConsoleColor.DarkCyan;
        //        Console.Write("  |  ");
        //        Console.ForegroundColor = ConsoleColor.Gray;
        //        Console.Write(cells[i + 3]);
        //        Console.ForegroundColor = ConsoleColor.DarkCyan;
        //        Console.WriteLine("  |");
        //        //Console.WriteLine("|  {0}  |  {1}  |  {2}  |", cells[i + 1], cells[i + 2], cells[i + 3]);
        //        Console.Write(("").PadRight(10, ' '));
        //        Console.WriteLine("|_____|_____|_____|");
        //        i += 3;
        //    } while (i < 9);

        //    Console.ForegroundColor = ConsoleColor.Gray;

        //}

        ///// <summary>
        ///// Initialise l'affichage à la fin de la partie du Tic-Tac-Toe
        ///// </summary>
        ///// <param name="cells">tableau des cases du tic-tac-toe</param>
        ///// <param name="winner">le numéro du gagnant</param>
        //static void InitializeDisplay(char[] cells, int winner)
        //{
        //    InitializeDisplay(cells);

        //    if (winner == 0)
        //    {
        //        Console.ForegroundColor = ConsoleColor.Cyan;
        //        Console.WriteLine("\n * Egalité *");
        //    }
        //    else
        //    {
        //        Console.ForegroundColor = ConsoleColor.Yellow;
        //        Console.WriteLine("\n * Bravo Joueur " + winner + " *");
        //    }

        //    Console.ForegroundColor = ConsoleColor.White;
        //    Console.WriteLine("Voulez-vous rejouer ? (echap pour quitter)");

        //}

        ///// <summary>
        ///// Test si il y a un gagnant au Tic-Tac-Toe
        ///// </summary>
        ///// <param name="cells">tableau des cases du tictactoe</param>
        ///// <returns>le numero du gagnant  ou 0 si pas de gagnant</returns>
        //static int TestWin(char[] cells)
        //{
        //    int winner = 0;

        //    #region Test Horizontal
        //    if (cells[1] == cells[2] && cells[1] == cells[3])
        //    {
        //        if (cells[1] == 'X')
        //        {
        //            winner = 1;
        //        }
        //        else
        //        {
        //            winner = 2;
        //        }
        //    }
        //    else if (cells[4] == cells[5] && cells[4] == cells[6])
        //    {
        //        if (cells[4] == 'X')
        //        {
        //            winner = 1;
        //        }
        //        else
        //        {
        //            winner = 2;
        //        }
        //    }
        //    else if (cells[7] == cells[8] && cells[7] == cells[9])
        //    {
        //        if (cells[7] == 'X')
        //        {
        //            winner = 1;
        //        }
        //        else
        //        {
        //            winner = 2;
        //        }
        //    }
        //    #endregion

        //    #region Test Vertical
        //    else if (cells[1] == cells[4] && cells[1] == cells[7])
        //    {
        //        if (cells[1] == 'X')
        //        {
        //            winner = 1;
        //        }
        //        else
        //        {
        //            winner = 2;
        //        }
        //    }
        //    else if (cells[2] == cells[5] && cells[2] == cells[8])
        //    {
        //        if (cells[2] == 'X')
        //        {
        //            winner = 1;
        //        }
        //        else
        //        {
        //            winner = 2;
        //        }
        //    }
        //    else if (cells[3] == cells[6] && cells[3] == cells[9])
        //    {
        //        if (cells[3] == 'X')
        //        {
        //            winner = 1;
        //        }
        //        else
        //        {
        //            winner = 2;
        //        }
        //    }
        //    #endregion

        //    #region Test Diagonal
        //    else if (cells[1] == cells[5] && cells[1] == cells[9])
        //    {
        //        if (cells[1] == 'X')
        //        {
        //            winner = 1;
        //        }
        //        else
        //        {
        //            winner = 2;
        //        }
        //    }
        //    else if (cells[3] == cells[5] && cells[3] == cells[7])
        //    {
        //        if (cells[3] == 'X')
        //        {
        //            winner = 1;
        //        }
        //        else
        //        {
        //            winner = 2;
        //        }
        //    }
        //    #endregion

        //    return winner;
        //}
    }
}
