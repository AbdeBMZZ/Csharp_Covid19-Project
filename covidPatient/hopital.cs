using System;
using System.Collections.Generic;
using System.Text;

namespace covidPatient
{
    class hopital
    {
        private static int ReanimationNbrJrs = 0;
        static Random rand = new Random();
        static bool ameliore = false;
        public static DateTime dateDeces;
        public static string lieu;
        public static string raison;

        public DateTime date_deces()
        {
            return dateDeces;
        }

        public string lieu_deces()
        {
            return lieu;
        }
        public string raison_deces()
        {
            return raison;
        }
        public static void Aggravation_Amelioration()
        {
            int test = rand.Next(0, 5);
            if (test == 4)
            {
                Console.WriteLine("\n etat amélioré \n");
                ameliore = true;
                patient p1 = new patient();
                p1.passerQuarantaine();
            }
            else
            {
                Console.WriteLine("\n décès du patient en raison de l'aggravation \n");

                Console.WriteLine("entrer la date de deces : (JJ/MM/YYYY  H:M:S )");
                dateDeces = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("entrer dans le lieu du décès \n");
                lieu = Console.ReadLine();

                Console.WriteLine("entrer dans la raison de la mort : \n");
                raison = Console.ReadLine();

                // add death cases
                persistance pr2 = new persistance();
                pr2.insertDeath();

            }

        }

        public static bool Ameliore()
        {
            if (ameliore == true)
                return true;
            else
                return false;

        }
        public static void Reanimation()
        {
            for(int i = 0; i < 7; i++)
            {
                ReanimationNbrJrs++;
                Console.WriteLine("en Reanimation jour " + ReanimationNbrJrs);

            }

            Aggravation_Amelioration();


        }

        
    }
}
