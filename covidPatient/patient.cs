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
                Console.WriteLine("\nvous repasserez le test PCR  \n");

                refaireTest();
            }
        }
        public void refaireTest()
        {
            if (Symptoms == false && nbrJrsQuarantaine==14 || hopital.Ameliore())
            {
                Console.WriteLine("\nTu as guéri de covid, tu peux rentrer à la maison");
            }

            else if (Symptoms == true)
            {
                Console.Write("aggravation du patient, vous serez ému et bénéficierez des services de réanimation");
                enReanimation();

            }
        }

        public void enReanimation()
        {
            hopital.Reanimation();
        }
    }
}
