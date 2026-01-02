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
    public partial class frmAlertBox : Form
    {
        public frmAlertBox()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual; // Required for custom Location
        }

        public Color BackColorAlertBox
        {
            get { return this.BackColor; }
            set { this.BackColor = value; }
        }

        public Color ColorAlertBox
        {
            get { return pnlAlertBox.BackColor; }
            set { pnlAlertBox.BackColor = lblTitleAlertBox.ForeColor = lblTextAlertBox.ForeColor = value; }
        }

        public Image IconAlertBox
        {
            get { return pbxAlertIcon.Image; }
            set { pbxAlertIcon.Image = value; }
        }

        public string TitleAlertBox
        {
            get { return lblTitleAlertBox.Text; }
            set { lblTitleAlertBox.Text = value; }
        }

        public string TextAlertBox
        {
            get { return lblTextAlertBox.Text; }
            set { lblTextAlertBox.Text = value; }
        }

        private void PositionAlertBox()
        {
            if (this.Owner != null)
            {
                // Get the location and size of the main form
                int mainFormX = this.Owner.Location.X;
                int mainFormY = this.Owner.Location.Y;
                int mainFormWidth = this.Owner.Width;

                // Calculate Horizontal Center: 
                // Start at Main X + half of Main Width, then subtract half of the Alert Width
                int xPos = mainFormX + (mainFormWidth / 2) - (this.Width / 2);

                // Position it at the top of the main form (with a small 10px margin)
                int yPos = mainFormY + 10;

                this.Location = new Point(xPos, yPos);
            }
            else
            {
                // Fallback: Center at the top of the primary screen if no owner is found
                int xPos = (Screen.PrimaryScreen.WorkingArea.Width / 2) - (this.Width / 2);
                this.Location = new Point(xPos, 10);
            }
        }

        private void timerAnimation_Tick(object sender, EventArgs e)
        {
            pnlAlertBox.Width += 2;

            // Use >= instead of == to be safe
            if (pnlAlertBox.Width >= 500)
            {
                timerAnimation.Stop(); 
                this.Close();
            }
        }

        private void frmAlertBox_Load(object sender, EventArgs e)
        {
            PositionAlertBox();

            timerAnimation.Interval = 10; // Adjust speed here (ms)
            timerAnimation.Start();
        }
    }
}
