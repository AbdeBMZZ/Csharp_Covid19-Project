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
                adapter.SelectCommand = new SqlCommand("SELECT citoyen.citoyen_cin As CIN, citoyen.citoyen_name As Name, citoyen.citoyen_address As Address,test.test_res As Result FROM citoyen,test", con);
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();

            }
        }
    }
}