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
    public partial class vaccinated : Form
    {
        static string chaine = @"Data Source=localhost;Initial Catalog=Covid winForm;Integrated Security=True";

        public vaccinated()
        {
            InitializeComponent();

            using (SqlConnection con = new SqlConnection(chaine))
            {
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataTable dt = new DataTable();
                adapter.SelectCommand = new SqlCommand("SELECT citoyen_cin as CIN, c_name as Name, c_birth as Birth_Date, c_address as Address, vaccin_date as Date_Vaccinated FROM vaccin", con);
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();

            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            e.CellStyle.BackColor = Color.LightBlue;
        }
    }
}
