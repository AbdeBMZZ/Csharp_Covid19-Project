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

            Console.WriteLine("votre adresse: ");
            string reponse;
        }
        public void setCin(string n)
        {
            cin = n;
        }
        public void setName(string n)
        {
            name = n;
        }
        public void setAddress(string n)
        {
            address = n;
        }
        public void setAge(int n)
        {
            age = n;
        }
        public void cwic(bool n)
        {
            CWIC = n;
        }
        public void covidsymptoms(bool n)
        {
            Symptoms = n;
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
