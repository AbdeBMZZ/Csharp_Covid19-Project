using System;
using System.Collections.Generic;
using System.Text;

namespace covidPatient
{
    class citoyen
    {
        public string name;
        public int age;
        public string cin;
        public string address;
        public bool CWIC; // contact With Infected Case
        public bool Symptoms;
        public string code;
        public bool estVaccine;

        public static DateTime patient_date;
        public citoyen()
        {

        }

        public void setInfo()
        {
            Console.WriteLine("votre nom complet : ");
            name = Console.ReadLine();

            Console.WriteLine("votre age : ");
            age = int.Parse(Console.ReadLine());

            Console.WriteLine("votre cin : ");
            cin = Console.ReadLine();

            Console.WriteLine("votre adresse : ");
            address = Console.ReadLine();

            Console.WriteLine("avez-vous contacté un cas infecté : (oui ou non) ");
            string reponse = Console.ReadLine();

            if (reponse == "non")
                CWIC = false;
            else if (reponse == "oui")
                CWIC = true;

            Console.WriteLine("avez-vous les symptômes de covid : (oui ou non) ");
            string reponse2 = Console.ReadLine();

            if (reponse2 == "non")
                Symptoms = false;
            else if (reponse2 == "oui")
                Symptoms = true;


            // persistance citoyen

            persistance persistanceCitoyen = new persistance();
            persistanceCitoyen.insertCitoyen(this);


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
                {
                    code = "red";
                    for(int j = 0; j < 14; j++)
                    {
                        Console.WriteLine("jours sans quarantaine " + j+1);
                    }
                    Console.WriteLine("\naggravation du citoyen\n");
                    patient p2 = new patient();
                    p2.enReanimation();
                }
            }
            else
            {
                Console.WriteLine("faire le test ? ");
                string reponse4 = Console.ReadLine();
                Console.WriteLine("\n");

                if (reponse4 == "oui")
                {
                    faireTest();

                }
            }


            
        }
        public void faireTest()
        {
            if (code == "blue")
            {
                Console.WriteLine("vous êtes vacciné, pas besoin de passer le test de covid");
            }
            else
            {
                int daysWaiting = 0;

                for (int i = 0; i < 2; i++)
                {
                    daysWaiting++;
                    Console.WriteLine("waiting day : " + daysWaiting);

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

                    Console.WriteLine("veuillez entrer la date d'infection : (JJ/MM/YYYY)");
                    patient_date = DateTime.Parse(Console.ReadLine());

                    persistance persistancePatient = new persistance();
                    persistancePatient.insertPatient(this);

                    patient p1 = new patient();
                    persistance pr1 = new persistance();
                    pr1.insertPatient(this);
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

        public void vacciner()
        {
            vaccin.vacciner();
            estVaccine = true;
            code = "blue";
        }

    }
}
