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
        private bool CWIC; // contact With Infected Case
        private bool Symptoms;
    
        void setCin(string n)
        {
            cin = n;
        }
        void setName(string n)
        {
            name = n;
        }
        void setAddress(string n)
        {
            address = n;
        }
        void setAge(int n)
        {
            age = n;
        }
        void cwic(bool n)
        {
            CWIC = n;
        }
        void covidsymptoms(bool n)
        {
            Symptoms = n;
        }

    }
}
