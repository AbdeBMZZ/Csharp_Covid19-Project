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

        public void setInfo()
        {
            Console.WriteLine("votre nom complet : ");
            name = Console.ReadLine();

            Console.WriteLine("votre adresse : ");
            cin = Console.ReadLine();

            Console.WriteLine("votre age : ");
            age = int.Parse(Console.ReadLine());

            Console.WriteLine("avez-vous contacté un cas infecté : (oui ou non) ");
            string reponse = Console.ReadLine();

            if (reponse == "non")
                CWIC = false;
            else if (reponse == "oui")
                CWIC = true;

            Console.WriteLine("avez-vous les symptômes de covid : (oui ou non) ");
            string reponse2 = Console.ReadLine();

            if (reponse2 == "non")
                CWIC = false;
            else if (reponse2 == "oui")
                CWIC = true;
        }
        
        public string getCode()
        {
            return code;
        }

        public void faireTest()
        {
            if (CWIC == false && Symptoms == false)
                Console.WriteLine("You are healthy");

            else if (CWIC == true && Symptoms == true)
            {
                patient p1 = new patient();
                p1.setCode();
                p1.passerQuarantaine();
                p1.refaireTest();
            }
        }

    }
}
