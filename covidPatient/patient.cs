using System;
using System.Collections.Generic;
using System.Text;

namespace covidPatient
{
    class Patient : citoyen
    {
        private int nbrJrsQuarantaine = 0;

        public void passerQuarantaine(citoyen ct)
        {
            for(int i = 0; i < 14; i++)
            {
                nbrJrsQuarantaine++;
                Console.WriteLine("Quarantaine jour : " + nbrJrsQuarantaine);
            }
            if (age < 40)
            {
                ct.Symptoms = false;
            }

            if (nbrJrsQuarantaine == 14)
            {
                Console.WriteLine("\nvous repasserez le test PCR  \n");

                refaireTest(ct);
            }
        }
        public void refaireTest(citoyen ct)
        {
            if (ct.Symptoms == false && nbrJrsQuarantaine==14)
            {
                Console.WriteLine("\nTu as guéri de covid, tu peux rentrer à la maison");
            }

            else if (ct.Symptoms == true)
            {
                Console.Write("aggravation du patient, vous serez ému et bénéficierez des services de réanimation");
                enReanimation();

            }
        }
        public void enReanimation(citoyen ct =null)
        {
            Hopital hp = new Hopital();
            hp.Reanimation(ct);
        }
    }
}