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
    public partial class frmEditGroup : Form
    {
        public frmEditGroup()
        {
            InitializeComponent();
        }

        private void btnCreateGroup_Click(object sender, EventArgs e)
        {
            dgViewUsers.Rows.Add("", "Mia");
        }

        private void btnAddNewMembers_Click(object sender, EventArgs e)
        {
            frmAddNewMembers addNewMembersForm = new frmAddNewMembers();
            addNewMembersForm.ShowDialog();
        }
    }
}
