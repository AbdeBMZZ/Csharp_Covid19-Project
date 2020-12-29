using System;
namespace covidPatient
{
    class Program
    {
        static void Main(string[] args)
        {
            citoyen ct = new citoyen("H221", "Ahmed", 99, "tangier", "08125512", true, true);
            ct.suspect();
        }
    }
}
