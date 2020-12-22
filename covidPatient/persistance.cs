using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;


namespace covidPatient
{
    class persistance
    {
        static string chaine = @"Data Source = localhost; Initial Catalog = Csharp; Integrated Security = True";
        static SqlConnection cnx = new SqlConnection(chaine);
        static SqlCommand cmd = new SqlCommand();
        static SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        
        public void insertCitoyen(citoyen ct)
        {
            cnx.Open();
            cmd.Connection = cnx;
            cmd.CommandText = "INSERT INTO Citoyen VALUES('" + ct.name+ "','" + ct.age + "','" + ct.cin + "','" + ct.address + "')";
            cmd.ExecuteNonQuery();
            cnx.Close();
        }
        
        public void insertDeath() 
        {
            cnx.Open();
            cmd.Connection = cnx;
            cmd.CommandText = "INSERT INTO deces VALUES('" + hopital.dateDeces + "','" + hopital.lieu + "','" + hopital.raison + "')";
            cmd.ExecuteNonQuery();
                Console.WriteLine("citoyen added");
            cnx.Close();
        }

        public void insertPatient(citoyen ct)
        {
            cnx.Open();
            cmd.Connection = cnx;
            cmd.CommandText = "INSERT INTO patient VALUES('" + ct.name + "','" + patient.patient_date + "')";
            int i = cmd.ExecuteNonQuery();
            cnx.Close();
        }

    }
}
