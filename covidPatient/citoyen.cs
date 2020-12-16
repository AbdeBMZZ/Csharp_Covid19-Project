using System;
using System.Collections.Generic;
using System.Text;

namespace covidPatient
{
    class citoyen
    {
        protected string name;
        protected int age;
        protected string cin;
        protected string address;
        protected bool CWIC; // contact With Infected Case
        protected bool Symptoms;
        protected string code;
        public citoyen()
        {

        }

        public void setInfo()
        {
            Console.WriteLine("votre nom complet : ");
            name = Console.ReadLine();
            Console.WriteLine("\n");

            Console.WriteLine("votre adresse : ");
            cin = Console.ReadLine();
            Console.WriteLine("\n");

            Console.WriteLine("votre age : ");
            age = int.Parse(Console.ReadLine());
            Console.WriteLine("\n");

            Console.WriteLine("avez-vous contacté un cas infecté : (oui ou non) ");
            string reponse = Console.ReadLine();
            Console.WriteLine("\n");

            if (reponse == "non")
                CWIC = false;
            else if (reponse == "oui")
                CWIC = true;

            Console.WriteLine("avez-vous les symptômes de covid : (oui ou non) ");
            string reponse2 = Console.ReadLine();
            Console.WriteLine("\n");

            if (reponse2 == "non")
                Symptoms = false;
            else if (reponse2 == "oui")
                Symptoms = true;


            if (CWIC==true && Symptoms == true)
            {
                Console.WriteLine("vous devez faire le test immédiatement !! vouloir le faire ?");
                string reponse3 = Console.ReadLine();
                Console.WriteLine("\n");

                if (reponse3 == "oui")
                {   
                    faireTest();

                }
                else if (reponse3 == "non")
                    code = "red";
            }
        }
        public void faireTest()
        {
            int daysW8ing = 0;

            for(int i = 0; i < 2; i++)
            {
                daysW8ing++;
                Console.WriteLine("waiting day : " + daysW8ing);

            }
            Console.WriteLine("\n");

            if (CWIC == false && Symptoms == false)
            {
                Console.WriteLine("vous avez testé négatif pour covid \n");
                code = "green";
            }

            else if (CWIC == true && Symptoms == true)
            {
                if (age < 60)
                    code = "orange";

                else if (age >= 60)
                    code = "red";

                Console.WriteLine("vous avez testé positif pour covid \n");
                patient p1 = new patient();
                if (code == "orange")
                {
                    p1.passerQuarantaine();
                }
                else if (code == "red")
                {
                    p1.enReanimation();
                }
                
            }
        }

    }
}
