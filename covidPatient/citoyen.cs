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
        
        public void whatShouldDo()
        {
            if(CWIC == true && Symptoms == true)
            {
                patient p1 = new patient();
            }
        }

    }
}
