using ExpenseTrackerCallAPIWinForms.Data.API.ModelsAPI.ExpenseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackerCallAPIWinForms.ViewModel.IVM
{
    public interface IExpensesReportVM
    {
        Task<string> GetTitle();
        Task<IList<ExpenseResponseDto>> GetBy(int? categoryId, DateTime? formDate, DateTime? toDate);
    }
}
