﻿using ExpenseTrackerCallAPIWinForms.Data;
using ExpenseTrackerCallAPIWinForms.Data.API.IExternal;
using ExpenseTrackerCallAPIWinForms.Data.API.ModelsAPI.ExpenseCategoryDto;
using ExpenseTrackerCallAPIWinForms.Presenter.DRY;
using ExpenseTrackerCallAPIWinForms.Presenter.MyClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpenseTrackerCallAPIWinForms.Presenter.Views.Sub
{
    public partial class AddExpenseCategoryForm : Form
    {
        private readonly IExpenseCategory useCase;
        private string title;
        public int id { get; set; } = 0;

        public AddExpenseCategoryForm()
        {
            useCase = Factory.CreateExpenseCategory();
            InitializeComponent();
            GetOthers();
        }

        async void GetOthers()
        {
            chBox_isLimitAmount.Checked = true;
            chBox_isLimitAmount.Checked = false;
            GeneralVariables.isExecute = false;
            title = await useCase.GetTitle();
            this.Text = title;
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (ToolsMyClass.check(txtName, "من فضلك إدخل اسم المهنة") == false) return;

                // Call
                ExpenseCategoryRequestDto mdl = new ExpenseCategoryRequestDto()
                {
                    name = txtName.Text.Trim(),
                    isLimitAmount = chBox_isLimitAmount.Checked ? true : false,
                    limitAmount = 0,
                };
                if (chBox_isLimitAmount.Checked)
                    mdl.limitAmount = Convert.ToDecimal(txtLimitAmount.Text.Trim());
                var result = await useCase.Add(mdl);

                // Show Result
                MessageBox.Show(result.Message, title);
                if (result.Success) // 10
                {
                    id = Convert.ToInt32(result.Id);
                    GeneralVariables.isExecute = true;
                    Close();
                }
                else if (result.ResultType != ResultsTypes.Incorrect_Input)
                {
                    ToolsMyClass.SelectAll(txtName);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void chBox_isLimitAmount_CheckedChanged(object sender, EventArgs e)
        {
            var chckBox = sender as CheckBox;
            BackgroundChangeCheckBox(chckBox);
            //txtLimitAmount.Enabled = chckBox.Checked == true ? true : false;
            txtLimitAmount.Enabled = chckBox.Checked;
        }

        private void txtLimitAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckDRY.Amount_KeyPress(sender, e);
        }
        private void txtLimitAmount_TextChanged(object sender, EventArgs e)
        {
            var txt = sender as TextBox;
            CheckDRY.TextChanged(txt);
        }
        private void BackgroundChangeCheckBox(CheckBox chckBox)
        {
            ToolsMyClass.BackgroundChangeCheckBox_CheckedChanged(chckBox);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
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
