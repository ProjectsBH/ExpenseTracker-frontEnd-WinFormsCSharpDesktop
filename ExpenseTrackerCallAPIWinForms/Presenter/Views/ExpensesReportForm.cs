﻿using ExpenseTrackerCallAPIWinForms.Data;
using ExpenseTrackerCallAPIWinForms.Data.API.IExternal;
using ExpenseTrackerCallAPIWinForms.Data.API.ModelsAPI.ExpenseDto;
using ExpenseTrackerCallAPIWinForms.Presenter.DRY;
using ExpenseTrackerCallAPIWinForms.Presenter.Helper.ControlHelper;
using ExpenseTrackerCallAPIWinForms.Presenter.Helper.ValuesHelper;
using ExpenseTrackerCallAPIWinForms.Presenter.MyClasses;
using ExpenseTrackerCallAPIWinForms.ViewModel.IVM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpenseTrackerCallAPIWinForms.Presenter.Views
{
    public partial class ExpensesReportForm : Form
    {
        private readonly IExpensesReportVM useCase;
        private readonly IExpenses expensesUC;
        private string title = "تقارير";
        public ExpensesReportForm()
        {
            InitializeComponent();
            useCase = Factory.CreateExpensesReportVM();
            expensesUC = Factory.CreateExpenses();
            GetOthers();
        }


        async void GetOthers()
        {
            try
            {
                dateTimePck_theDate.Value = DateTime.Now;
                chBox_ByCategory.Checked = true;
                chBox_ByCategory.Checked = false;
                title = await useCase.GetTitle();
                lblTitle.Text = title;
                var obj = Factory.CreateExpenseCategory();
                var ExpenseCategoryValueIdDto = await obj.GetValueIdAll();
                ComboBoxHelper.SetCmbData(cmbCategory, ExpenseCategoryValueIdDto.ToList(), false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (chBox_ByCategory.Checked && ToolsMyClass.check(cmbCategory, "من فضلك إختار الفئة") == false) return;
                if (ToolsMyClass.checkTrans(dateTimePck_theDate, "من فضلك من تاريخ") == false) return;
                if (ToolsMyClass.checkTrans(dateTimePck_toDate, "من فضلك الى تاريخ") == false) return;

                GetRefreshDataDGV();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        async Task<IList<ExpenseResponseDto>> GetData()
        {
            int? categoryId = null;
            if (chBox_ByCategory.Checked)
                categoryId = Convert.ToInt32(cmbCategory.SelectedValue);
            DateTime? formDate = Convert.ToDateTime(dateTimePck_theDate.Value.ToShortDateString());
            DateTime? toDate = Convert.ToDateTime(dateTimePck_toDate.Value.ToShortDateString());
            
            return await useCase.GetBy(categoryId, formDate, toDate);
        }
        async void GetRefreshDataDGV()
        {
            try
            {

                IList<ExpenseResponseDto> lstData =await GetData();

                dGV.Columns.Clear();
                dGV.DataSource = lstData;
                dGV.ColumnHeaderText(Pair.Of("id", "المعرف"), Pair.Of("categoryName", "الفئة")
               , Pair.Of("amount", "المبلغ"), Pair.Of("theStatement", "البيان")
               , Pair.Of("theDate", "التاريخ"), Pair.Of("created_in", "تاريخ الإضافة"));

                dGV.ColumnHide("id", "categoryId", "created_by", "created_in");

                dGV.InsertColumnsForDGV("btnDelete", "حذف", "X");
                dGV.InsertColumnsForDGV("btnUpdate", "تعديل", "U", 1);

                dGV.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dGV.Columns["theStatement"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                DataGridViewColumn column2 = dGV.Columns["theStatement"];
                column2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                txtTotal.Text = lstData.Sum(a => a.amount).ToString("#,##0.##");
                lblCount.Text = lstData.Count.ToString();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dGV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {

                if (e.ColumnIndex == dGV.Columns["amount"].Index)
                {
                    if (e.Value != null && !string.IsNullOrEmpty(e.Value.ToString()))
                    {
                        double d = Math.Abs(double.Parse(CheckDRY.CheckNullOrEmpty(e.Value.ToString()).ToString()));
                        e.Value = d.ToString("#,###.##");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

        private void chBox_ByCategory_CheckedChanged(object sender, EventArgs e)
        {
            var chckBox = sender as CheckBox;
            ToolsMyClass.BackgroundChangeCheckBox_CheckedChanged(chckBox);
            cmbCategory.Enabled = chckBox.Checked;
        }

        private async void dGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView dgv = sender as DataGridView;
                if (dgv.Rows.Count > 0 && dgv.CurrentRow != null)
                {
                    if (e.ColumnIndex == dgv.Columns["btnUpdate"].Index)
                    {
                        IList<ExpenseResponseDto> lstData = (List<ExpenseResponseDto>)dgv.DataSource;
                        ExpenseResponseDto data = lstData.GetEntity(a => a.id == dgv.GetId64FromDGV());

                        new ExpenseForm(data).ShowDialog();
                        if (GeneralVariables.isExecute)
                            GetRefreshDataDGV();
                    }
                    else if (e.ColumnIndex == dgv.Columns["btnDelete"].Index)
                    {
                        int id = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells["id"].Value);

                        if (MessageBox.Show("هل تريد حذف بيانات العملية رقم : " + id + "  بالتأكيد ؟ ", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            var result =await expensesUC.Delete(id);
                            MessageBox.Show(result.Message, "delete");
                            if (result.Success)
                            {
                                GetRefreshDataDGV();
                            }
                        }

                    }
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void dateTimePck_theDate_ValueChanged(object sender, EventArgs e)
        {

            ToolsMyClass.toDate_ValueChanged(dateTimePck_theDate, dateTimePck_toDate);
        }
    }
}
