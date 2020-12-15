using System;

namespace covidPatient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("abdo");
            patient p1 = new patient();
            p1.setName("abdellah");
            p1.setAge(53);
            p1.setCin("t3151920");
            p1.setAddress("casablanca mohammedia");
            p1.cwic(true);
            p1.covidsymptoms(true);

            p1.faireTest();
        }
    }
}
