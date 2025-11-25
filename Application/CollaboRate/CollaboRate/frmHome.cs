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
    public partial class frmHome : Form
    {
        public frmHome()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dgViewMembers.Rows.Add(1, "Mia");
            dgViewMemberEvaluations.Rows.Add(1, "Mia", 4.5);
            dgViewTasks.Rows.Add(1, "Design GUI", "Due on Monday 6/11/2025");
            dgViewMeetings.Rows.Add(1, "Discuss Progress", "7/11/2025 18:30");
        }
    }
}
