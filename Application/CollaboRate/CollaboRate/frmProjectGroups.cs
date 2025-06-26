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
    public partial class frmProjectGroups : Form
    {
        public frmProjectGroups()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dgViewJoinRequests.Rows.Add(1, "Mia");
            dgViewProjectGroups.Rows.Add(1, "Mia");
        }

        private void btnCreateNewGroup_Click(object sender, EventArgs e)
        {
            frmCreateNewGroup createNewGroupForm = new frmCreateNewGroup();
            createNewGroupForm.ShowDialog();
        }

        private void btnEditGroup_Click(object sender, EventArgs e)
        {
            frmEditGroup editGroupForm = new frmEditGroup();
            editGroupForm.ShowDialog();
        }
    }
}
