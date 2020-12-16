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
        protected bool isPassedTest = false;
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
                Console.WriteLine("you should do the test immediatly!! want to do it ?");
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
       
        public string getCode()
        {
            return code;
        }

        public void faireTest()
        {
            isPassedTest = true;    
            if (CWIC == false && Symptoms == false)
            {
                Console.WriteLine("état sain");
                code = "green";
            }

            else if (CWIC == true && Symptoms == true)
            {
                if (age < 60)
                    code = "orange";

                else if (age >= 60)
                    code = "red";

                Console.WriteLine("you have the covid ");
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
