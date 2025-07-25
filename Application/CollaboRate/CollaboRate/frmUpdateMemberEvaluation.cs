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
    public partial class frmUpdateMemberEvaluation : Form
    {
        private const string ApiBaseUrl = "https://localhost:7287";
        private readonly HttpClient client = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(30)
        };
        public int ratee_ID = 0;

        public frmUpdateMemberEvaluation()
        {
            InitializeComponent();
        }

        // Method to check for errors
        private bool InputValidation()
        {
            bool hasError = false;

            if (ratee_ID <= 0)
            {
                return true;
            }

            return hasError;
        }

        private void frmUpdateMemberEvaluation_Load(object sender, EventArgs e)
        {
            MessageBox.Show("User_ID: " + ratee_ID);
        }
    }
}
