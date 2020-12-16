using System;
using System.Collections.Generic;
using System.Text;

namespace covidPatient
{
    class patient:citoyen
    {
        private string PCR;
        private int nbrJrsQuarantaine = 0;
        public patient()
        {
            Console.WriteLine("tu es infecté");
        }

        public void passerQuarantaine()
        {
            for(int i = 0; i < 14; i++)
            {
                nbrJrsQuarantaine++;
            }
            if (age < 40)
            {
                Symptoms = false;
                CWIC = false;
            }

        }
        public void refaireTest()
        {
            if (CWIC == false && Symptoms == false)
                PCR = "negatif";

            else if (CWIC == true && Symptoms == true)
            {
                PCR = "positif";
            }
        }
        public void setCode()
        {
            if (PCR == "negatif")
                code = "green";

            if (PCR == "positif")
                code = "orange";

            if (PCR == "positif" && age > 60)
                code = "red";
        }

    }
}
