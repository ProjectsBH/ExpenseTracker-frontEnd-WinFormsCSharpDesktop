using ExpenseTrackerCallAPIWinForms.Data;
using ExpenseTrackerCallAPIWinForms.Data.API;
using ExpenseTrackerCallAPIWinForms.Data.API.IExternal;
using ExpenseTrackerCallAPIWinForms.Presenter.DRY;
using ExpenseTrackerCallAPIWinForms.Presenter.MyClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpenseTrackerCallAPIWinForms.Presenter
{
    public partial class Form_Login : Form
    {
        private readonly IUser useCase;

        public Form_Login()
        {
            InitializeComponent();
            useCase = Factory.CreateUser();
            GetOthers();
        }
        void GetOthers()
        {
            lblAPI.Text = LinkAPI.apiLanguage.ToString();
            GeneralVariables.setAppName(lblAppName);
            DefaultUser();
        }
        private void DefaultUser()
        {
            if (Properties.Settings.Default.userName.Trim().Length > 0)
            {
                txtName.Text = Properties.Settings.Default.userName.Trim();
                txtPwd.TabIndex = 0;
                txtName.TabStop = false;
                //txtPwd.Text = "123";
            }

        }
        static void start_Form_main()
        {
            Application.Run(new Views.MainForm());
        }
        private void btn_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private async void btn_login_Click(object sender, EventArgs e)
        {
            try
            {
                //
                if (ToolsMyClass.check(txtName, "يرجى ادخل اسم المستخدم") == false) return;
                if (ToolsMyClass.check(txtPwd, "يرجى ادخل كلمة المرور") == false) return;
                //

                var result =await useCase.Login(txtName.Text.Trim(), txtPwd.Text.Trim());

                if (result.ResultType == ResultsTypes.Exception)
                {
                    MessageBox.Show(result.Message);
                }
                else if (result.Success)
                {
                    if (Properties.Settings.Default.userName.Trim() != txtName.Text.Trim())
                    {
                        Properties.Settings.Default.userName = txtName.Text.Trim();
                        Properties.Settings.Default.Save();
                    }
                    Thread thr = new Thread(start_Form_main);
                    thr.SetApartmentState(ApartmentState.STA);
                    thr.Start();
                    this.Close();


                }
                else
                {
                    MessageBox.Show("بيانات تسجيل الدخول غير صحيحة", "تسجيل الدخول");
                    ToolsMyClass.clear(this.grBoxControl.Controls);
                    ToolsMyClass.focus(txtName);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
