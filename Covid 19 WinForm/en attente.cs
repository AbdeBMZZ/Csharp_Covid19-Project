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
    public partial class en_attente : Form
    {
        static string chaine = @"Data Source=localhost;Initial Catalog=Covid winForm;Integrated Security=True";
        public en_attente()
        {
            InitializeComponent();
            using (SqlConnection con = new SqlConnection(chaine))
            {
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataTable dt = new DataTable();
                adapter.SelectCommand = new SqlCommand("SELECT citoyen.citoyen_cin as cin, citoyen_name as name, citoyen_address as address,test.test_res as PCR_Result FROM citoyen, test WHERE citoyen.citoyen_cin=test.citoyen_cin", con);
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                
            }

        }
    }
}