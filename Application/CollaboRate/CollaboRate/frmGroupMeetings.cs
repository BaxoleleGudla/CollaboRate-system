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
    public partial class frmGroupMeetings : Form
    {
        public frmGroupMeetings()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dgViewMeetings.Rows.Add("Meet1", "Assign tasks to members", "2025-06-18", "2025");
        }

        private void btnScheduleNewMeeting_Click(object sender, EventArgs e)
        {
            frmScheduleUpdateMeeting scheduleMeetingForm = new frmScheduleUpdateMeeting();
            scheduleMeetingForm.ShowDialog();
        }
    }
}
