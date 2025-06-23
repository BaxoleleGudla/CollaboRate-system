using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CollaboRate
{
    public partial class frmGroupChats : Form
    {
        public frmGroupChats()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lstChats.Items.Add("Mia Jones" + "  " + "2025/06/17 10:12AM");
            lstChats.Items.Add("When are we going to start with the project guys?");
            lstChats.Items.Add("");
        }
    }
}
