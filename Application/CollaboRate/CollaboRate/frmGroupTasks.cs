﻿using System;
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
    public partial class frmGroupTasks : Form
    {
        public frmGroupTasks()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dgViewTasks.Rows.Add("", "Document", "Create documentation", "2025 June 5", "Mia", "In progress");
        }

        private void btnCreateNewTask_Click(object sender, EventArgs e)
        {
            frmCreateUpdateTask createTaskForm = new frmCreateUpdateTask();
            createTaskForm.ShowDialog();
        }
    }
}
