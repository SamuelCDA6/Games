using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Games
{
    class Hangman
    {
        
        public static void Start()
        {
            // Read each line of the file into a string array. Each element
            // of the array is one line of the file.
            string[] motsPendu = System.IO.File.ReadAllLines(@"C:\Users\Public\Documents\motsPendu.txt");

            Random 
            // Display the file contents by using a foreach loop.
            Console.WriteLine("Contents of motsPendu.txt = ");
            foreach (string mot in motsPendu)
            {
                // Use a tab to indent each line of the file.
                Console.WriteLine("\t" + mot);
            }

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        static void InitializeDisplay()
        {

        }
        
    }
}
