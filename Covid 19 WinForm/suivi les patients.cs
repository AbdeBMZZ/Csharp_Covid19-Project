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
        System.Timers.Timer t2;

        int s,s2;
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

            DataGridViewTextBoxColumn textboxColumn3 = new DataGridViewTextBoxColumn();
            textboxColumn3.Name = "days_r";
            textboxColumn3.HeaderText = "jrs en reanimation";
            dataGridView2.Columns.Add(textboxColumn3);



            t = new System.Timers.Timer();
            t.Interval = 1000;
            t.Elapsed += OnTimeEvent;

            t2 = new System.Timers.Timer();
            t2.Interval = 1000;
            t2.Elapsed += OnTimeEvent2;
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

        private void OnTimeEvent2(object sender, System.Timers.ElapsedEventArgs e)
        {
            Invoke(new Action(() =>
            {
                refresh2();
                s2 += 1;
                if (s2 == 6)
                {
                    t2.Stop();

                    this.dataGridView2.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.Dgv_CellFormatting2);

                }

            }));
        }

        private void Dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            using (SqlConnection conn = new SqlConnection(chaine))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT patient_birth from patient_quarantaine WHERE patient_cin = @cn", conn);
                cmd.Parameters.AddWithValue("@cn", row.Cells["CIN"].Value.ToString());

                object result = cmd.ExecuteScalar();
                DateTime resAge = DateTime.Now;
                if (result != null)
                {
                    resAge = (DateTime)result;
                }

                conn.Close();

                int age = CalculateAge(resAge);
                MessageBox.Show(age.ToString());

                if (age > 60)
                {
                    e.CellStyle.BackColor = Color.Red;
                    insertCritiques(row.Cells["CIN"].Value.ToString(), row.Cells["Name"].Value.ToString(), row.Cells["Address"].Value.ToString());
                    deleteCases_quarantined(row.Cells["CIN"].Value.ToString());

                }
                else if(age<50)
                {
                    e.CellStyle.BackColor = Color.Green;
                    insertGueris(row.Cells["CIN"].Value.ToString(), row.Cells["Name"].Value.ToString(), row.Cells["Address"].Value.ToString());

                    deleteCases_quarantined(row.Cells["CIN"].Value.ToString());


                }

            }

        }


        private void Dgv_CellFormatting2(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];
            using (SqlConnection conn = new SqlConnection(chaine))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT patient_birth from patient_quarantaine WHERE patient_cin = @cn", conn);
                cmd.Parameters.AddWithValue("@cn", row.Cells["CIN"].Value.ToString());

                object result = cmd.ExecuteScalar();
                DateTime resAge = DateTime.Now;
                if (result != null)
                {
                    resAge = (DateTime)result;
                }

                conn.Close();
                int age = CalculateAge(resAge);

                if (age > 65)
                {
                    e.CellStyle.BackColor = Color.Black;
                    insertdeaths(row.Cells["CIN"].Value.ToString(), row.Cells["Name"].Value.ToString(), row.Cells["Address"].Value.ToString());
                    deleteC_reanimation(row.Cells["CIN"].Value.ToString());

                }
                else if (age < 65)
                {
                    e.CellStyle.BackColor = Color.Orange;
                    insertQuarantined(row.Cells["CIN"].Value.ToString(), row.Cells["Name"].Value.ToString(), row.Cells["Address"].Value.ToString());
                    deleteC_reanimation(row.Cells["CIN"].Value.ToString());

                }

            }

        }

        public void refresh()
        {

            SqlConnection con = new SqlConnection(chaine);
            SqlCommand cmd = new SqlCommand("SELECT patient_cin as CIN, patient_name as Name, patient_address as Address  FROM patient_quarantaine", con);

            con.Open();

            var dt = new DataTable();

            using ( var sqlDataReader = cmd.ExecuteReader())
            {
                dt.Load(sqlDataReader);
            }


            dataGridView1.DataSource = dt;


            con.Close();
        }

        public void refresh2()
        {
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
        private void en_quarantaine_Click(object sender, EventArgs e)
        {

            s = 0;
            if(dataGridView1.Rows.Count != 0)
                t.Start();
            

            dataGridView1.Visible = true;
            dataGridView3.Visible = false;
            dataGridView2.Visible = false;
            dataGridView4.Visible = false;

            SqlConnection con = new SqlConnection(chaine);
            SqlCommand cmd = new SqlCommand("SELECT patient_cin as CIN, patient_name as Name, patient_address as Address FROM patient_quarantaine", con);
            con.Open();

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
                    SqlCommand cmd = new SqlCommand("SELECT patient_birth from patient_quarantaine WHERE patient_cin = @cn", conn);
                    cmd.Parameters.AddWithValue("@cn", row.Cells["CIN"].Value.ToString());
                    DateTime result = (DateTime)cmd.ExecuteScalar();
                    conn.Close();

                    int age = CalculateAge(result);
                    if (age > 50)
                    {
                        insertCritiques(row.Cells["CIN"].Value.ToString(), row.Cells["Name"].Value.ToString(), row.Cells["Address"].Value.ToString());
                        row.DefaultCellStyle.ForeColor = Color.Red;
                        deleteCases_quarantined(row.Cells["CIN"].Value.ToString());
                    }
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
                SqlConnection conn = new SqlConnection(chaine);

                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT patient_birth from patient_quarantaine WHERE patient_cin = @cn", conn);
                cmd.Parameters.AddWithValue("@cn", row.Cells["CIN"].Value.ToString());
                DateTime result = (DateTime)cmd.ExecuteScalar();
                conn.Close();
                insertVaccinated(DateTime.Now, row.Cells["CIN"].Value.ToString(), row.Cells["Name"].Value.ToString(), result, row.Cells["Address"].Value.ToString());
                deleteCases_quarantined(row.Cells["CIN"].Value.ToString());

                MessageBox.Show("patient vaccinated");
            }

        }

        public void insertVaccinated(DateTime t, string cin, string name, DateTime b, string address)
        {
            SqlConnection conn = new SqlConnection(chaine);
            conn.Open();
            SqlCommand cmd2 = new SqlCommand("INSERT INTO vaccin VALUES(@d, @cin, @name, @date, @add)", conn);
            cmd2.Parameters.AddWithValue("@d", DateTime.Now.ToString());
            cmd2.Parameters.AddWithValue("@cin", cin);
            cmd2.Parameters.AddWithValue("@name", name);
            cmd2.Parameters.AddWithValue("@add", address);
            cmd2.Parameters.AddWithValue("@date", b.ToString());
            try
            {
                int recordsAffected = cmd2.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();

            }

        }

        public void insertQuarantined(string cin, string name, string address)
        {
            SqlConnection conn = new SqlConnection(chaine);
            conn.Open();
            SqlCommand cmd2 = new SqlCommand("INSERT INTO patient_quarantaine VALUES(@cin, @name, @date, @add)", conn);
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
                //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();

            }
        }

        public void insertdeaths(string cin, string name, string address)
        {
            SqlConnection conn = new SqlConnection(chaine);
            conn.Open();
            SqlCommand cmd2 = new SqlCommand("INSERT INTO decedes VALUES(@cin, @name, @add, @date)", conn);
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
                //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();

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
                //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            SqlCommand cmd = new SqlCommand("DELETE FROM patient_quarantaine WHERE patient_cin=@cin", conn);
            cmd.Parameters.AddWithValue("@cin", cin);
            try
            {
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
        private void deleteC_reanimation(string cin)
        {
            SqlConnection conn = new SqlConnection(chaine);
            conn.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM patient_en_reanimation WHERE p_cin=@cin", conn);
            cmd.Parameters.AddWithValue("@cin", cin);
            try
            {
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
        private void insertCritiques(string cin, string name, string address)
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
                //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];
            row.Cells["days_r"].Value = string.Format("{0}", s2.ToString().PadLeft(2, '0'));
            e.CellStyle.BackColor = Color.Red;
        }

        private void gueris_btn_Click(object sender, EventArgs e)
        {
            dataGridView3.Visible = true;
            dataGridView2.Visible = false;
            dataGridView1.Visible = false;
            dataGridView4.Visible = false;

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
            s2 = 0;
            if (dataGridView2.Rows.Count != 0)
                t2.Start();
            dataGridView2.Visible = true;
            dataGridView1.Visible = false;
            dataGridView3.Visible = false;
            dataGridView4.Visible = false;
            
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

        private void dataGridView3_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void decedes_Click(object sender, EventArgs e)
        {
            dataGridView4.Visible = true;
            dataGridView3.Visible = false;
            dataGridView2.Visible = false;
            dataGridView1.Visible = false;
            SqlConnection con = new SqlConnection(chaine);
            SqlCommand cmd = new SqlCommand("SELECT d_cin as CIN, d_name as Name, d_address as Address, d_date as date  FROM decedes ", con);
            con.Open();

            var dt = new DataTable();

            using (var sqlDataReader = cmd.ExecuteReader())
            {
                dt.Load(sqlDataReader);
            }

            dataGridView4.DataSource = dt;


            con.Close();
        }
    }
}



