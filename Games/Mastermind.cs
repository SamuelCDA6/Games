using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games
{
    class Mastermind
    {
        public static void Start()
        {
            Console.Clear();

            string aTrouver;
            aTrouver = InitialiseMastermind();

            int i;

            //for (i = 0; i < 4; i++)
            //{
            //    Console.Write(aTrouver[i] + " ");
            //}
            //Console.WriteLine();

            string nbEntre;
            i = 0;
            int bienPlaces;
            int presents;

            do
            {
                bienPlaces = 0;
                presents = 0;

                nbEntre = SaisieNombres();

                if (!TestCombinaison(aTrouver, nbEntre, ref bienPlaces, ref presents))
                {
                    Console.Write("Bien Placés : " + bienPlaces);
                    Console.WriteLine(" Presents : " + presents);
                    Console.WriteLine($"Encore {9 - i} essais");
                    Console.WriteLine();
                }

                i++;
            } while (bienPlaces != 4 && i < 10);

            if (bienPlaces == 4)
            {
                Console.WriteLine("Bravo!");
            }
            else
            {
                Console.WriteLine("Dommage!");
            }

        }

        static string InitialiseMastermind()
        {
            string aTrouver = "";

            for (int i = 0; i < 4; i++)
            {
                Random objRandom = new();
                aTrouver += objRandom.Next(6) + 1;
            }

            return aTrouver;
        }

        static string SaisieNombres()
        {
            string nbEntre;
            do
            {
                Console.Write($"nombres : ");
                nbEntre = Console.ReadLine();
            } while (nbEntre.Length != 4);

            return nbEntre;
        }

        static bool TestCombinaison(string aTrouver, string nbEntres, ref int bienPlaces, ref int presents)
        {
            bool[] isUsedATrouver = new bool[4]; // Pour bloquer les chiffres de la combinaison a trouver
            bool[] isUsedNbEntres = new bool[4]; // Pour bloquer les chiffres de la combinaison entree

            // Test deja les bien placés
            for (int i = 0; i < aTrouver.Length; i++)
            {
                if (aTrouver[i] == nbEntres[i])
                {
                    bienPlaces++;
                    isUsedATrouver[i] = true;
                    isUsedNbEntres[i] = true;
                }
            }

            // Test pour calculer le nombres de presents
            for (int j = 0; j < aTrouver.Length; j++)
            {
                int k = 0;

                while (k < aTrouver.Length && !isUsedATrouver[j])
                {
                    // pour ne pas avoir de doublons il faut verifier que les nombres n’ont pas deja été utilisés
                    // dans le nb a trouver et le nb entré
                    if (!isUsedATrouver[j] && !isUsedNbEntres[k] && aTrouver[j] == nbEntres[k])
                    {
                        presents++;
                        isUsedNbEntres[k] = true;
                        isUsedATrouver[j] = true;
                    }

                    k++;
                }

            }

            return bienPlaces == 4;
        }
    }
}
