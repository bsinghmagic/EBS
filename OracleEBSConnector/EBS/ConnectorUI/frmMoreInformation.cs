using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConnectorUI
{
    public partial class frmMoreInformation : Form
    {
       public string description { get; set; }
        public frmMoreInformation()
        {
            InitializeComponent();
        }

        private void frmMoreInformation_Load(object sender, EventArgs e)
        {

            richTextBox1.Text = description;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    private void button1_Click(object sender, EventArgs e)
    {
      System.Diagnostics.Process.Start("http://support.mineraltree.com");

    }
  }
}
