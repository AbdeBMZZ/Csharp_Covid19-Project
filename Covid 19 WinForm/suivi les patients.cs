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
        }

        private void en_quarantaine_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(chaine);
            SqlCommand cmd = new SqlCommand("SELECT citoyen.citoyen_cin, citoyen.citoyen_name, citoyen.citoyen_address, test.test_res FROM citoyen,test WHERE  citoyen.citoyen_cin=test.citoyen_cin and test.test_res = @res", con);
            con.Open();
            cmd.Parameters.AddWithValue("@res", "POSITIF");

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;

            dataGridView1.Visible = true;

            con.Close();

        }

    }
    }   


