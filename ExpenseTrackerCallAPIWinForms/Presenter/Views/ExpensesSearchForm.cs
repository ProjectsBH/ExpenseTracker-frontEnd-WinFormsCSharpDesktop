﻿using ExpenseTrackerCallAPIWinForms.Data;
using ExpenseTrackerCallAPIWinForms.Data.API.IExternal;
using ExpenseTrackerCallAPIWinForms.Data.API.ModelsAPI.ExpenseDto;
using ExpenseTrackerCallAPIWinForms.Presenter.DRY;
using ExpenseTrackerCallAPIWinForms.Presenter.Helper.ControlHelper;
using ExpenseTrackerCallAPIWinForms.Presenter.Helper.ValuesHelper;
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

namespace ExpenseTrackerCallAPIWinForms.Presenter.Views
{
    public partial class ExpensesSearchForm : Form
    {
        private readonly IExpenses useCase;
        private string title = "بحث برقم العملية";
        public ExpensesSearchForm()
        {
            InitializeComponent();
            useCase = Factory.CreateExpenses();
            GetOthers();
        }




        void GetOthers()
        {
            lblTitle.Text = title;
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            GetRefreshDataDGV();
        }



        async void GetRefreshDataDGV()
        {
            try
            {
                if (ToolsMyClass.check_num(txtNumberTrans, "من فضلك إدخل رقم العملية") == false) return;

                dGV.Columns.Clear();
                var item = await useCase.GetBy(Convert.ToInt64(txtNumberTrans.Text));
                if (item == null || item.id < 1)
                {
                    MessageBox.Show($"لا يوجد عملية بهذا الرقم المطلوب : {txtNumberTrans.Text}", "get");
                    dGV.DataSource = null;
                    txtNumberTrans.Focus();
                    txtNumberTrans.SelectAll();
                    return;
                }
                IList<ExpenseResponseDto> lstData = new List<ExpenseResponseDto>() { item };


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
                            var result =await useCase.Delete(id);
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


        private void txtNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckDRY.Number_KeyPress(sender, e);
        }

    }
}
