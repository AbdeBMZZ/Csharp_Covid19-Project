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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void ajouter_Click(object sender, EventArgs e)
        {
            add_citoyen f = new add_citoyen();
            f.Show();

        }

        private void en_attente_Click(object sender, EventArgs e)
        {
            en_attente eA = new en_attente();
            eA.Show();
            
        }

        private void suivre_Click(object sender, EventArgs e)
        {

        }
    }
}
