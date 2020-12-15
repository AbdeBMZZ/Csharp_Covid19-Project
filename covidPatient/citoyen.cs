using System;
using System.Collections.Generic;
using System.Text;

namespace covidPatient
{
    class citoyen
    {
        protected string cin;
        protected string name;
        protected string address;
        protected int age;
        protected bool CWIC; // contact With Infected Case
        protected bool Symptoms;
        protected string code;
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
