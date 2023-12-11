﻿using ExpenseTrackerCallAPIWinForms.Presenter.DRY;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpenseTrackerCallAPIWinForms.Presenter
{
    public partial class Form_splash : Form
    {
        public Form_splash()
        {
            InitializeComponent();
            GeneralVariables.setAppName(lblAppName);
            timer1.Interval = 10;
            timer1.Start();
        }

        int startProgress = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            startProgress += 1;
            progressBar1.Value = startProgress;
            lblCount.Text = startProgress + "%";
            if (progressBar1.Value == 101)
            {
                progressBar1.Value = 0;
                timer1.Stop();

                new Form_Login().Show();

                this.Hide();
            }
        }

        // تحريك الواجهة بالماوس
        private Point _mouseLoc;
        private void pnlHeader_MouseDown(object sender, MouseEventArgs e)
        {
            _mouseLoc = e.Location;
        }

        private void pnlHeader_MouseMove(object sender, MouseEventArgs e)
        {
            FormMouseMove.MouseMoveHeader(this, _mouseLoc, e);
        }

    }
}
