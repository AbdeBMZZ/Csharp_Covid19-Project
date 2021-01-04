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
    public partial class distribution : Form
    {
        static string chaine = @"Data Source=localhost;Initial Catalog=Covid winForm;Integrated Security=True";

        public distribution()
        {
            InitializeComponent();
            using (SqlConnection con = new SqlConnection(chaine))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT count(*) FROM decedes ", con);
                SqlCommand cmd2 = new SqlCommand("SELECT count(*) FROM gueris ", con);

                int result = (int)cmd.ExecuteScalar();
                int result2 = (int)cmd2.ExecuteScalar();

                textBox1.Text = result.ToString();
                textBox2.Text = result2.ToString();

                con.Close();

            }

        }

        private void distribution_Load(object sender, EventArgs e)
        {

        }
    }
}
