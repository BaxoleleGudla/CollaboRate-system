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

                // If the owner form is minimized, hide the alert box
                if (this.Owner.WindowState == FormWindowState.Minimized)
                {
                    this.Visible = false;
                    return;
                }
                else
                {
                    this.Visible = true;
                }

                // Calculate Horizontal Center: 
                // Start at Main X + half of Main Width, then subtract half of the Alert Width
                int xPos = mainFormX + (mainFormWidth / 2) - (this.Width / 2);

                // Position it at the top of the main form (with a small 10px margin)
                int yPos = mainFormY + 10;

                // Handle the case where the parent is maximized (coordinates can behave slightly differently)
                if (this.Owner.WindowState == FormWindowState.Maximized)
                {
                    // Screen working area handles taskbar offsets automatically
                    var screen = Screen.FromControl(this.Owner);
                    xPos = screen.WorkingArea.X + (screen.WorkingArea.Width / 2) - (this.Width / 2);
                    yPos = screen.WorkingArea.Y + 10;
                }

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
            if (pnlAlertBox.Width >= 353)
            {
                timerAnimation.Stop(); 
                this.Close();
            }
        }

        // Event handler for when the parent moves or resizes
        private void Owner_PositionChanged(object sender, EventArgs e)
        {
            PositionAlertBox();
        }

        private void frmAlertBox_Load(object sender, EventArgs e)
        {
            PositionAlertBox();

            // Wire up parent form events so the toast moves dynamically
            if (this.Owner != null)
            {
                this.Owner.LocationChanged += Owner_PositionChanged;
                this.Owner.SizeChanged += Owner_PositionChanged;
            }

            timerAnimation.Interval = 20; // Adjust speed here (ms)
            timerAnimation.Start();
        }

        private void frmAlertBox_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Unsubscribe from events to clean up memory
            if (this.Owner != null)
            {
                this.Owner.LocationChanged -= Owner_PositionChanged;
                this.Owner.SizeChanged -= Owner_PositionChanged;
            }
        }

        private void pbxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
