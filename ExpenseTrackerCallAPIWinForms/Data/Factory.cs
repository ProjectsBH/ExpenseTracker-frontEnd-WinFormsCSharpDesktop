using ExpenseTrackerCallAPIWinForms.Data.API.ExternalAPI;
using ExpenseTrackerCallAPIWinForms.Data.API.IExternal;
using ExpenseTrackerCallAPIWinForms.ViewModel.IVM;
using ExpenseTrackerCallAPIWinForms.ViewModel.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackerCallAPIWinForms.Data
{
    public class Factory
    {

        #region Dao
        //private static ProjectDao _projectDao = null;
        //internal static ProjectDao CreateProjectDao()
        //{
        //    if (_projectDao == null)
        //        _projectDao = new ProjectDao();
        //    return _projectDao;
        //}
        internal static IExpenseCategory CreateExpenseCategory()
        {
            return new ExpenseCategoryAPI();
        }
        internal static IExpenses CreateExpenses()
        {
            return new ExpensesAPI();
        }
        internal static IExpensesReport CreateExpensesReport()
        {
            return new ExpensesReportAPI();
        }
        internal static IUser CreateUser()
        {
            return new UserAPI();
        }

        #endregion

        #region UseCase 
        internal static IExpensesReportVM CreateExpensesReportVM()
        {
            return new ExpensesReportVM();
        }
        //
        #endregion
    }

}
