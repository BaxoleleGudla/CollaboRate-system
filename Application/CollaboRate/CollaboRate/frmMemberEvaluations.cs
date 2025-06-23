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
    public partial class frmMemberEvaluations : Form
    {
        public frmMemberEvaluations()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dgViewMemberEvaluations.Rows.Add("Mia", "5", "20", "Yes");
        }
    }
}
