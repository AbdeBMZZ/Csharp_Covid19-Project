using System;
using System.Collections.Generic;
using System.Text;

namespace covidPatient
{
    class Hopital
    {
        private static int ReanimationNbrJrs = 0;
        static Random rand = new Random();
        static bool ameliore = false;
        public void Aggravation_Amelioration(citoyen c = null)
        {
            int test = rand.Next(0, 2);
            if (test == 1)
            {
                Console.WriteLine("\n etat amélioré \n");
                ameliore = true;
                Patient p1 = new Patient();
                p1.passerQuarantaine();
            }
            else
            {
                Console.WriteLine("\n décès du patient en raison de l'aggravation \n");


                // insert death :

                Console.WriteLine("entrer la date de deces : (JJ/MM/YYYY)");

                DateTime dt = DateTime.Now;
                string format = Console.ReadLine();

                Console.WriteLine("entrer le lieu du deces ");
                string lieu = Console.ReadLine();

                Console.WriteLine("entrer le raison du deces ");
                string raison = Console.ReadLine();

                // add death cases
                persistance pr3 = new persistance();

                pr3.insertDeath(c,dt.ToString(format), lieu,raison);



            }

        }

        public bool Ameliore()
        {
            if (ameliore == true)
                return true;
            else
                return false;

        }
        public void Reanimation(citoyen ct)
        {
            for(int i = 0; i < 7; i++)
            {
                ReanimationNbrJrs++;
                Console.WriteLine("en Reanimation jour " + ReanimationNbrJrs);

            }

            Aggravation_Amelioration(ct);


        }

        
    }
}
