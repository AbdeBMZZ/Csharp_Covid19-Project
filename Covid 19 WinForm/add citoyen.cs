using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Covid_19_WinForm
{
    public partial class add_citoyen : Form
    {
        static string chaine = @"Data Source=localhost;Initial Catalog=Covid winForm;Integrated Security=True";
        public add_citoyen()
        {
            InitializeComponent();

        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(chaine))
            {
                if (cinText.Text != "" && nomText.Text != "" && addressText.Text != "")
                {
                    con.Open();
                    SqlCommand command = new SqlCommand();
                    SqlCommand command2 = new SqlCommand();
                    command.Connection = con;
                    command2.Connection = con;

                    command.CommandText = "INSERT INTO citoyen VALUES(@cin, @name, @birth, @address,@code)";
                    command2.CommandText = "INSERT INTO test VALUES(@test_res, @cin)";

                    if (radioButton2.Checked == true && radioButton4.Checked == true)

                        command2.Parameters.AddWithValue("@test_res", "NEGATIF");
                    else
                        command2.Parameters.AddWithValue("@test_res", "POSITIF");
                    command2.Parameters.AddWithValue("@cin", cinText.Text);

                    command.Parameters.AddWithValue("@cin", cinText.Text);
                    command.Parameters.AddWithValue("@name", nomText.Text);
                    command.Parameters.AddWithValue("@birth", dateTime_text.Value.ToString());
                    command.Parameters.AddWithValue("@address", addressText.Text);
                    if(radioButton2.Checked==true && radioButton4.Checked == true)
                        command.Parameters.AddWithValue("@code","green");
                    else
                        command.Parameters.AddWithValue("@code", "orange");

                    try
                    {
                        int recordsAffected = command.ExecuteNonQuery();
                        int recordsAffected2 = command2.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        con.Close();
                        testing t = new testing();
                        t.Show();
                    }
                }
                else
                    MessageBox.Show("abdo");


            }
        }
    }
}
