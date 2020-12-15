using System;
using System.Collections.Generic;
using System.Text;

namespace covidPatient
{
    class patient:citoyen
    {
        private string PCR;

        public void faireTest()
        {
            if (CWIC == false && Symptoms == false)
                PCR = "negatif";

            else if (CWIC == true && Symptoms == true)
                PCR = "positif";
        }
        void setCode()
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
