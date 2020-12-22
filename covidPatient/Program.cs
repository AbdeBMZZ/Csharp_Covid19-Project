using System;
namespace covidPatient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("premiere personne ");
            citoyen person1 = new citoyen("abdellah",19, "r3513355", "mohammedia", false, false);

            Console.WriteLine("deuxieme personne ");

            citoyen person2 = new citoyen("karim", 15,"t305335" ,"mohammedia", true, true);

        }
    }
}
