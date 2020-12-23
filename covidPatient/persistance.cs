using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;


namespace covidPatient
{
    class persistance
    {
        static string chaine = @"Data Source = localhost; Initial Catalog = Covid; Integrated Security = True";
        static SqlConnection cnx = new SqlConnection(chaine);
        static SqlCommand cmd = new SqlCommand();
        static SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        
        public void insertCitoyen(citoyen ct)
        {
            cnx.Open();
            cmd.Connection = cnx;

            cmd.CommandText = "INSERT INTO Citoyen VALUES('" + ct.name + "','" + ct.age + "','" + ct.cin + "','" + ct.address + "','" + ct.tel + "')";
            int i = cmd.ExecuteNonQuery();

            Console.WriteLine("citoyen added ");
            cnx.Close();

        }
        public void insertDeath(DateTime dtime, string lieu, string raison) 
        {
            cnx.Open();
            cmd.Connection = cnx;
            cmd.CommandText = "INSERT INTO deces VALUES('" + dtime + "','" + lieu + "','" + raison + "')";
            int i = cmd.ExecuteNonQuery();
                Console.WriteLine("cas deces added");
            cnx.Close();
        }
        public void insertPatient(citoyen ct, DateTime datePatient)
        {
            cnx.Open();
            cmd.Connection = cnx;
            cmd.CommandText = "INSERT INTO patient VALUES('" + ct.name + "','" + datePatient + "','" + ct.cin + "')";
            int i = cmd.ExecuteNonQuery();
            cnx.Close();
            Console.WriteLine("nice buddy");
        }

        // cette methode

        public void get_possible_cases(citoyen c)
        {
            cnx.Open();
            cmd.CommandText = "SELECT * FROM Citoyen WHERE tel="+c.tel +"";
            cmd.Connection = cnx;
            cmd.ExecuteNonQuery();
            
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            int i = 0;
            foreach (DataRow dataRow in dt.Rows)
            {
                Console.WriteLine("\n");
                Console.WriteLine("suspect case numero : " + ++i);

                foreach (var item in dataRow.ItemArray)
                {

                    Console.WriteLine(item);
                    
                }
                Console.WriteLine("\n");

            }
            cnx.Close();
        }
    }
}
