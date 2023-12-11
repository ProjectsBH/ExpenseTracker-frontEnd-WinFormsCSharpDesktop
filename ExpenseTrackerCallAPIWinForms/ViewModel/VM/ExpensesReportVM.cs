using ExpenseTrackerCallAPIWinForms.Data;
using ExpenseTrackerCallAPIWinForms.Data.API.IExternal;
using ExpenseTrackerCallAPIWinForms.Data.API.ModelsAPI.ExpenseDto;
using ExpenseTrackerCallAPIWinForms.ViewModel.IVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackerCallAPIWinForms.ViewModel.VM
{
    public class ExpensesReportVM : IExpensesReportVM
    {
        private readonly IExpensesReport useCase;
        public ExpensesReportVM()
        {
            useCase = Factory.CreateExpensesReport();
        }
        public async Task<IList<ExpenseResponseDto>> GetBy(int? categoryId, DateTime? formDate, DateTime? toDate)
        {
            DateTime _formDate = (DateTime)formDate, _toDate = (DateTime)toDate;
            if (categoryId != null || categoryId > 0)
                return await useCase.GetBy((int)categoryId, _formDate, _toDate);
            else
                return await useCase.GetBy(_formDate, _toDate);
        }

        public async Task<string> GetTitle()
        {
            return await useCase.GetTitle();
        }
    }
}
