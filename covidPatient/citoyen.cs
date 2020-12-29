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
        public string tel;
        persistance pr = new persistance();
        public string telR()
        {
            return tel;
        }
        public citoyen(string cin = null, string name=null, int age=0, string address=null , string tel =null, bool cwic=false, bool symptoms=false)
        {

            this.cin = cin;
            this.name = name;
            this.age = age;
            this.address = address;
            this.tel = tel;
            this.CWIC = cwic;
            this.Symptoms = symptoms;
        }
        public void suspect()
        {
            pr.insertCitoyen(this);

            if (CWIC == true && Symptoms == true)
            {
                Console.WriteLine("vous devez faire le test immédiatement !! vouloir le faire ?");
                string reponse = Console.ReadLine();
                Console.WriteLine("\n");

                if (reponse == "oui")
                    faireTest();
                else
                {
                    Patient p2 = new Patient();
                    code = "red";
                    for (int j = 0; j < 14; j++)
                    {
                        Console.WriteLine("jours sans quarantaine " + j + 1);
                    }
                    Console.WriteLine("\naggravation du citoyen\n");
                    p2.enReanimation(this);
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
                    Patient p1 = new Patient();
                    //date d'infection 
                    Console.WriteLine("entrer la date d'infection : (MM/JJ/YYYY)");


                    DateTime dt = DateTime.Now;
                    string format = Console.ReadLine();

                    pr.insertPatient(this, dt.ToString(format));


                    //trouver les cas suspects:
                    Console.WriteLine("entrez les numéros de téléphone des personnes avec lesquelles vous avez pris contact");
                    tel = Console.ReadLine();

                    pr.get_possible_cases(tel);



                    if (code == "orange")
                    {
                        p1.passerQuarantaine(this);
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
