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
    public partial class frmEvaluateAllMembers : Form
    {
        public frmEvaluateAllMembers()
        {
            InitializeComponent();
        }

        private void btnSubmitEvaluations_Click(object sender, EventArgs e)
        {
            dgViewUsers.Rows.Add("", "Mia");
        }
    }
}
