using System;
using System.Collections.Generic;
using System.Text;

namespace covidPatient
{
    class hopital
    {
        private int ReanimationNbrJrs = 0;
        static Random rand = new Random();
        static bool ameliore = false;
        public static void Aggravation_Amelioration()
        {
            int test = rand.Next(1, 2);
            if (test == 1)
            {
                Console.WriteLine("\n etat amélioré \n");
                ameliore = true;
                patient p1 = new patient();
                p1.passerQuarantaine();
            }
            else
            {
                Console.WriteLine("\n décès du patient en raison de l'aggravation \n");

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
                Console.WriteLine("en Reanimation");
            }

            Aggravation_Amelioration();


        }
    }
}
