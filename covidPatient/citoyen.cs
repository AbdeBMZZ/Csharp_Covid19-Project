using System;
using System.Collections.Generic;
using System.Text;

namespace covidPatient
{
    class citoyen
    {
        private string cin;
        private string name;
        private string address;
        private int age;
        private bool contactWithInfectedCase;
        private bool Symptoms;
    
        void setCin()
        {
            Console.WriteLine("votre cin");
            cin = Console.ReadLine();
        }

    }
}
