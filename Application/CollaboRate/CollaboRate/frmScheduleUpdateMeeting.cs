using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CollaboRate
{
    public partial class frmScheduleUpdateMeeting : Form
    {
        private const string ApiBaseUrl = "https://localhost:7287";
        private readonly HttpClient client = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(30)
        };

        public frmScheduleUpdateMeeting()
        {
            InitializeComponent();
        }

        // Method to check for errors
        private bool InputValidation()
        {
            bool hasError = false;

            // Meeting title validation
            if (string.IsNullOrWhiteSpace(txtMeetingTitle.Texts))
            {
                if (!lblMeetingTitleError.Visible)
                    lblMeetingTitleError.Visible = true;

                lblMeetingTitleError.Text = "Please enter meeting title";

                if (this.txtMeetingTitle.BorderColor != Color.Red)
                {
                    this.txtMeetingTitle.BorderColor = Color.Red;
                }

                hasError = true;
            }
            else
            {
                if (lblMeetingTitleError.Visible)
                    lblMeetingTitleError.Visible = false;

                if (txtMeetingTitle.BorderColor != Color.DimGray)
                    txtMeetingTitle.BorderColor = Color.DimGray;
            }

            // Meeting date validation
            if (dtpMeetingDate.Value == null)
            {
                if (!lblMeetingDateError.Visible)
                    lblMeetingDateError.Visible = true;

                lblMeetingDateError.Text = "Please select meeting date";

                if (this.dtpMeetingDate.BorderColor != Color.Red)
                {
                    this.dtpMeetingDate.BorderColor = Color.Red;
                }

                hasError = true;
            }
            else if (dtpMeetingDate.Value <= DateTime.Now)
            {
                if (!lblMeetingDateError.Visible)
                    lblMeetingDateError.Visible = true;

                lblMeetingDateError.Text = "Meeting date must be in the future.";

                if (this.dtpMeetingDate.BorderColor != Color.Red)
                {
                    this.dtpMeetingDate.BorderColor = Color.Red;
                }

                hasError = true;
            }
            else
            {
                if (lblMeetingDateError.Visible)
                    lblMeetingDateError.Visible = false;

                if (dtpMeetingDate.BorderColor != Color.LightGray)
                    dtpMeetingDate.BorderColor = Color.LightGray;
            }

            return hasError;
        }

        private void btnScheduleUpdateMeeting_Click(object sender, EventArgs e)
        {
            InputValidation();
        }
    }
}
