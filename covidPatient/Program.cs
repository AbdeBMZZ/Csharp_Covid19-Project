using System;
namespace covidPatient
{
    class Program
    {
        static void Main(string[] args)
        {
            citoyen ct = new citoyen("G5321", "yassuo", 99, "Jp", "08125512", true);
            ct.suspect();
        }
    }
}
