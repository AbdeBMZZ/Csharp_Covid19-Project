using System;
using System.Collections.Generic;
using System.Text;

namespace covidPatient
{
    class patient:citoyen
    {
        private int nbrJrsQuarantaine = 0;

        public void passerQuarantaine()
        {
            for(int i = 0; i < 14; i++)
            {
                nbrJrsQuarantaine++;
                Console.WriteLine("Quarantaine jour : " + nbrJrsQuarantaine);
            }
            if (age < 40)
            {
                Symptoms = false;
            }

            if (nbrJrsQuarantaine == 14)
            {
                Console.WriteLine("you'll repass the PCR test \n");

                refaireTest();
            }
        }
        public void refaireTest()
        {
            if (Symptoms == false && nbrJrsQuarantaine==14 || hopital.Ameliore())
            {
                Console.WriteLine("\nyou've healed from covid, you can go home");
            }

            else if (CWIC == true && Symptoms == true)
            {
                Console.Write("you will go to the Urgence");

            }
        }

        public void enReanimation()
        {
            hopital.Reanimation();
        }
    }
}
