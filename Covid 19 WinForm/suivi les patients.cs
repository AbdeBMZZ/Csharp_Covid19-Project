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
    public partial class suivi_les_patients : Form
    {
        static string chaine = @"Data Source=localhost;Initial Catalog=Covid winForm;Integrated Security=True";

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


        }


        private void en_quarantaine_Click(object sender, EventArgs e)
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

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

                e.CellStyle.BackColor = Color.Orange;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["pcr"].Index)
            {
                int rowIndx = e.RowIndex;
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                MessageBox.Show(row.Cells["Name"].Value.ToString());

            }
        }

        private void suivi_les_patients_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells["days"].Value = "1";

        }
    }
}



