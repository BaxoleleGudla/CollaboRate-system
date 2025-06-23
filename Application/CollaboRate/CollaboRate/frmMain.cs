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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private Form activeForm = null;

        // Method to open a form
        private void openChildForm(Form childForm)
        {
            // If the active form is the same type as the requested form, do nothing
            if (activeForm != null && activeForm.GetType() == childForm.GetType())
            {
                activeForm.BringToFront();
                return;
            }

            // Close and dispose the current active form if any
            if (activeForm != null)
            {
                activeForm.Close();
                activeForm.Dispose();
            }

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.Dock = DockStyle.Fill;

            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(childForm);
            pnlMain.Tag = childForm;

            childForm.BringToFront();
            childForm.Show();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            //openChildForm(new frmHome());
        }

        private void btnProjectGroups_Click(object sender, EventArgs e)
        {
            openChildForm(new frmProjectGroups());
        }

        private void btnMemberEvaluations_Click(object sender, EventArgs e)
        {
            openChildForm(new frmMemberEvaluations());
        }

        private void btnGroupTasks_Click(object sender, EventArgs e)
        {
            openChildForm(new frmGroupTasks());
        }

        private void btnGroupMeetings_Click(object sender, EventArgs e)
        {
            openChildForm(new frmGroupMeetings());
        }

        private void btnGroupChats_Click(object sender, EventArgs e)
        {
            openChildForm(new frmGroupChats());
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            //openChildForm(new frmSettings());
        }
    }
}
