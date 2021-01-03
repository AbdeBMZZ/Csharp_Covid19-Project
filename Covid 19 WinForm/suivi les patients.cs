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
using System.Windows.Threading;

namespace Covid_19_WinForm
{
    public partial class suivi_les_patients : Form
    {
        static string chaine = @"Data Source=localhost;Initial Catalog=Covid winForm;Integrated Security=True";
        System.Timers.Timer t;
        int s;
        public suivi_les_patients()
        {
            InitializeComponent();
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "Refaire PCR";
            btn.Name = "pcr";
            btn.Text = "refaire pcr";
            btn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(btn);

            DataGridViewTextBoxColumn textboxColumn = new DataGridViewTextBoxColumn();
            textboxColumn.Name = "days";
            textboxColumn.HeaderText = "jrs en quarantaine";

            DataGridViewButtonColumn btn2 = new DataGridViewButtonColumn();
            btn2.HeaderText = "Faire le Vaccin";
            btn2.Name = "vaccin";
            btn2.Text = "Faire le Vaccin";
            btn2.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(btn2);

            dataGridView1.Columns.Add(textboxColumn);


            t = new System.Timers.Timer();
            t.Interval = 1000;
            t.Elapsed += OnTimeEvent;
        }



        private void OnTimeEvent(object sender, System.Timers.ElapsedEventArgs e)
        {
            Invoke(new Action(() =>
            {
                refresh();
                s += 1;
                if (s == 14)
                {
                    t.Stop();
                    
                    this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.Dgv_CellFormatting);
                }

            }));
        }
        private void Dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            using (SqlConnection conn = new SqlConnection(chaine))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT citoyen_birth from citoyen WHERE citoyen_cin = @cn", conn);
                cmd.Parameters.AddWithValue("@cn", row.Cells["CIN"].Value.ToString());
                DateTime result = (DateTime)cmd.ExecuteScalar();
                conn.Close();

                int age = CalculateAge(result);
                if (age > 50)
                {
                    e.CellStyle.BackColor = Color.Red;
                    insertCritiques(age, row.Cells["CIN"].Value.ToString(), row.Cells["Name"].Value.ToString(), row.Cells["Address"].Value.ToString());
                }
                else
                {
                    e.CellStyle.BackColor = Color.Green;
                    insertGueris(row.Cells["CIN"].Value.ToString(), row.Cells["Name"].Value.ToString(), row.Cells["Address"].Value.ToString());
                }
            }

        }

        public void refresh()
        {

            SqlConnection con = new SqlConnection(chaine);
            SqlCommand cmd = new SqlCommand("SELECT citoyen.citoyen_cin as CIN, citoyen.citoyen_name as Name, citoyen.citoyen_address as Address, test.test_res as PCR FROM citoyen,test WHERE  citoyen.citoyen_cin=test.citoyen_cin and test.test_res = @res", con);
            con.Open();
            cmd.Parameters.AddWithValue("@res", "POSITIF");

            var dt = new DataTable();

            using (var sqlDataReader = cmd.ExecuteReader())
            {
                dt.Load(sqlDataReader);
            }

            dataGridView1.DataSource = dt;

            dataGridView1.Visible = true;

            con.Close();
        }
        private void en_quarantaine_Click(object sender, EventArgs e)
        {

            s = 0;
            if(dataGridView1.Rows.Count != 0)
                t.Start();
            

            dataGridView1.Visible = true;
            dataGridView3.Visible = false;
            dataGridView2.Visible = false;
            SqlConnection con = new SqlConnection(chaine);
            SqlCommand cmd = new SqlCommand("SELECT citoyen.citoyen_cin as CIN, citoyen.citoyen_name as Name, citoyen.citoyen_address as Address, test.test_res as PCR FROM citoyen,test WHERE  citoyen.citoyen_cin=test.citoyen_cin and test.test_res = @res", con);
            con.Open();
            cmd.Parameters.AddWithValue("@res", "POSITIF");

            var dt = new DataTable();

            using (var sqlDataReader = cmd.ExecuteReader())
            {
                dt.Load(sqlDataReader);
            }

            dataGridView1.DataSource = dt;

            dataGridView1.Visible = true;

            con.Close();
            


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        }


        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            row.Cells["days"].Value = string.Format("{0}",s.ToString().PadLeft(2,'0'));
            e.CellStyle.BackColor = Color.Orange;

        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["pcr"].Index)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                using (SqlConnection conn = new SqlConnection(chaine))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT citoyen_birth from citoyen WHERE citoyen_cin = @cn", conn);
                    cmd.Parameters.AddWithValue("@cn", row.Cells["CIN"].Value.ToString());
                    DateTime result = (DateTime)cmd.ExecuteScalar();
                    conn.Close();

                    int age = CalculateAge(result);
                    if (age > 50)
                    {
                        insertCritiques(age, row.Cells["CIN"].Value.ToString(), row.Cells["Name"].Value.ToString(), row.Cells["Address"].Value.ToString());
                        row.DefaultCellStyle.ForeColor = Color.Red;
                        deleteCases_quarantined(row.Cells["CIN"].Value.ToString());
                    }
                    t.Stop();
                    if (age < 50)
                    {
                        row.DefaultCellStyle.ForeColor = Color.Green;
                        insertGueris(row.Cells["CIN"].Value.ToString(), row.Cells["Name"].Value.ToString(), row.Cells["Address"].Value.ToString());
                        deleteCases_quarantined(row.Cells["CIN"].Value.ToString());
                        MessageBox.Show("le patient " + row.Cells["Name"].Value.ToString() + " a guéri définitivement de covid-19");
                    }

                }

            }
            if (e.ColumnIndex == dataGridView1.Columns["vaccin"].Index)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                row.DefaultCellStyle.ForeColor = Color.Azure;
                using (SqlConnection con = new SqlConnection(chaine))
                {
                        con.Open();
                        SqlCommand command = new SqlCommand();
                        command.Connection = con;

                        command.CommandText = "INSERT INTO vaccin VALUES(@datevaccin,@cin, @name,@birth, @address)";

                    /*    command.Parameters.AddWithValue("@datevaccin", dateTimePicker1.Value.ToString());
                        command.Parameters.AddWithValue("@cin", cinText.Text);
                        command.Parameters.AddWithValue("@name", nomText.Text);
                        command.Parameters.AddWithValue("@birth", dateTime_text.Value.ToString());
                        command.Parameters.AddWithValue("@address", addressText.Text);

                    */
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

                        }


                }
            }

        }
        public void insertGueris(string cin, string name, string address)
        {
            SqlConnection conn = new SqlConnection(chaine);
            conn.Open();
            SqlCommand cmd2 = new SqlCommand("INSERT INTO gueris VALUES(@cin, @name, @add,@date)", conn);
            cmd2.Parameters.AddWithValue("@cin", cin);
            cmd2.Parameters.AddWithValue("@name", name);
            cmd2.Parameters.AddWithValue("@add", address);
            cmd2.Parameters.AddWithValue("@date", DateTime.Now.ToString());
            try
            {
                int recordsAffected = cmd2.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();

            }

        }
        private void deleteCases_quarantined(string cin)
        {
            SqlConnection conn = new SqlConnection(chaine);
            conn.Open();
            SqlCommand cmd1 = new SqlCommand("DELETE FROM test WHERE citoyen_cin=@cin", conn);
            SqlCommand cmd = new SqlCommand("DELETE FROM citoyen WHERE citoyen_cin=@cin", conn);
            cmd.Parameters.AddWithValue("@cin", cin);
            cmd1.Parameters.AddWithValue("@cin", cin);

            try
            {
                int recordsAffected1 = cmd1.ExecuteNonQuery();

                int recordsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();

            }
        }
        private void insertCritiques(int age, string cin, string name, string address)
        {
            SqlConnection conn = new SqlConnection(chaine);
            conn.Open();
            SqlCommand cmd2 = new SqlCommand("INSERT INTO patient_en_reanimation VALUES(@cin, @name, @add)", conn);
            cmd2.Parameters.AddWithValue("@cin", cin);
            cmd2.Parameters.AddWithValue("@name", name);
            cmd2.Parameters.AddWithValue("@add", address);
            try
            {
                int recordsAffected = cmd2.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();

            }
        }
        private int CalculateAge(DateTime dateOfBirth)
        {
            int age = 0;
            age = DateTime.Now.Year - dateOfBirth.Year;
            if (DateTime.Now.DayOfYear < dateOfBirth.DayOfYear)
                age = age - 1;

            return age;
        }

        private void suivi_les_patients_Load(object sender, EventArgs e)
        {
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView3.AllowUserToAddRows = false;


        }

        private void dataGridView1_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {

        }


        private void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            e.CellStyle.BackColor = Color.Red;
        }

        private void gueris_btn_Click(object sender, EventArgs e)
        {
            dataGridView3.Visible = true;
            dataGridView2.Visible = false;
            dataGridView1.Visible = false;

            SqlConnection con = new SqlConnection(chaine);
            SqlCommand cmd = new SqlCommand("SELECT gueri_cin as CIN, gueri_name as Name, gueri_address as Address, gueri_date as date  FROM gueris ", con);
            con.Open();

            var dt = new DataTable();

            using (var sqlDataReader = cmd.ExecuteReader())
            {
                dt.Load(sqlDataReader);
            }

            dataGridView3.DataSource = dt;


            con.Close();
        }

        private void en_reanimation_btn_Click_1(object sender, EventArgs e)
        {
            dataGridView2.Visible = true;
            dataGridView1.Visible = false;
            dataGridView3.Visible = false;
            t.Stop();

            SqlConnection con = new SqlConnection(chaine);
            SqlCommand cmd = new SqlCommand("SELECT p_cin as CIN, p_name as Name, p_address as Address FROM patient_en_reanimation ", con);
            con.Open();

            var dt = new DataTable();

            using (var sqlDataReader = cmd.ExecuteReader())
            {
                dt.Load(sqlDataReader);
            }

            dataGridView2.DataSource = dt;


            con.Close();
        }

        private void dataGridView3_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            e.CellStyle.BackColor = Color.LightGreen;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}



