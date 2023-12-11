using ExpenseTrackerCallAPIWinForms.Data.API.ModelsAPI.ExpenseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackerCallAPIWinForms.Data.API.IExternal
{
    public interface IExpensesReport
    {
        Task<string> GetTitle();
        Task<IList<ExpenseResponseDto>> GetBy(int categoryId);
        Task<IList<ExpenseResponseDto>> GetBy(int categoryId, DateTime formDate, DateTime toDate);
        Task<IList<ExpenseResponseDto>> GetBy(DateTime formDate, DateTime toDate);

        

    }
}
