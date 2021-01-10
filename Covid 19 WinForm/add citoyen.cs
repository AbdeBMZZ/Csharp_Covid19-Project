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
                    command2.CommandText = "INSERT INTO test1 VALUES(@test_res, @cin2)";

                    if (radioButton2.Checked == true && radioButton4.Checked == true)
                    {
                        command2.Parameters.AddWithValue("@test_res", "NEGATIF");
                    }
                    else
                    {

                        command2.Parameters.AddWithValue("@test_res", "POSITIF");
                        SqlCommand command3 = new SqlCommand("INSERT INTO patient_quarantaine VALUES(@cin, @name, @birth, @add)",con);
                        SqlCommand command4 = new SqlCommand("INSERT INTO test2 VALUES(@test_res, @cin_p)", con);
                        command4.Parameters.AddWithValue("@test_res", "POSITIF");
                        command4.Parameters.AddWithValue("@cin_p", cinText.Text);
                        
                        command3.Parameters.AddWithValue("@cin", cinText.Text);
                        command3.Parameters.AddWithValue("@name", nomText.Text);
                        command3.Parameters.AddWithValue("@birth", dateTime_text.Value.ToString());
                        command3.Parameters.AddWithValue("@add", addressText.Text);
                        try
                        {
                            int recordsAffected3 = command3.ExecuteNonQuery();
                            int recordsAffected4 = command4.ExecuteNonQuery();


                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }


                    }


                    command2.Parameters.AddWithValue("@cin2", cinText.Text);

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
                        cinText.Text = "";
                        nomText.Text = "";
                        dateTimePicker1.Value = DateTime.Now;
                        addressText.Text = "";
                        radioButton1.Checked = false;
                        radioButton2.Checked = false;
                        radioButton3.Checked = false;
                        radioButton4.Checked = false;


                    }
                }
                else
                    MessageBox.Show("please check your informations");



            }


        }

        private void faire_vaccin_Click(object sender, EventArgs e)
        {

            using (SqlConnection con = new SqlConnection(chaine))
            {
                if (cinText.Text != "" && nomText.Text != "" && addressText.Text != "")
                {
                    con.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = con;

                    command.CommandText = "INSERT INTO vaccin VALUES(@datevaccin,@cin, @name,@birth, @address)";

                    command.Parameters.AddWithValue("@datevaccin", dateTimePicker1.Value.ToString());
                    command.Parameters.AddWithValue("@cin", cinText.Text);
                    command.Parameters.AddWithValue("@name", nomText.Text);
                    command.Parameters.AddWithValue("@birth", dateTime_text.Value.ToString());
                    command.Parameters.AddWithValue("@address", addressText.Text);


                    try
                    {
                        int recordsAffected = command.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        con.Close();
                        con.Close();
                        testing t = new testing();
                        t.Show();
                        cinText.Text = "";
                        nomText.Text = "";
                        dateTimePicker1.Value = DateTime.Now;
                        addressText.Text = "";
                        radioButton1.Checked = false;
                        radioButton2.Checked = false;
                        radioButton3.Checked = false;
                        radioButton4.Checked = false;
                    }
                }
                else
                    MessageBox.Show("please check your informations");


            }
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton6.Checked == true)
            {
                label8.Visible = true;
                dateTimePicker1.Visible = true;
                flowLayoutPanel1.Visible = false;
                flowLayoutPanel2.Visible = false;
                label5.Visible = false;
                label6.Visible = false;

                faire_vaccin.Visible = true;
                button1.Visible = false;
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked == true)
            {
                label8.Visible = false;
                dateTimePicker1.Visible = false;
                flowLayoutPanel1.Visible = true;
                flowLayoutPanel2.Visible = true;
                label5.Visible = true;
                label6.Visible = true;


                faire_vaccin.Visible = false;
                button1.Visible = true;
            }
        }
    }
}
