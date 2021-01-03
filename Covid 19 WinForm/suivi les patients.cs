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
        int h, m, s;
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
            
            dataGridView1.Columns.Add(textboxColumn);


            t = new System.Timers.Timer();
            t.Interval = 1000;
            t.Elapsed += OnTimeEvent;
        }



        private void OnTimeEvent(object sender, System.Timers.ElapsedEventArgs e)
        {
            Invoke(new Action(() =>
            {
                s += 1;
                if (s == 14)
                {
                    t.Stop();
                }

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
            }));
        }

        private void en_quarantaine_Click(object sender, EventArgs e)
        {

            s = 1;
            t.Start();

            dataGridView2.Visible = false;
            dataGridView1.Visible = true;
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            row.Cells["days"].Value = string.Format("{0}:{1}:{2}",h.ToString().PadLeft(2,'0'),m.ToString().PadLeft(2,'0'),s.ToString().PadLeft(2,'0'));
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
                    if(age>50)
                        insertCritiques(age, row.Cells["CIN"].Value.ToString(), row.Cells["Name"].Value.ToString(), row.Cells["Address"].Value.ToString());



                }

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

        }

        private void dataGridView1_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            dataGridView2.Visible = true;

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

        private void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            e.CellStyle.BackColor = Color.Red;
        }
    }
}



