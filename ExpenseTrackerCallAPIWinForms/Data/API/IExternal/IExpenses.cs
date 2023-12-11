using ExpenseTrackerCallAPIWinForms.Data.API.ModelsAPI.ExpenseDto;
using ExpenseTrackerCallAPIWinForms.ViewModel.Utils.FinalResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackerCallAPIWinForms.Data.API.IExternal
{
    public interface IExpenses
    {
        Task<string> GetTitle();
        Task<IList<ExpenseResponseDto>> GetTop();
        Task<ExpenseResponseDto> GetBy(long id);
        Task<ServicesResultsDto> Add(ExpenseRequestDto entity);
        Task<ServicesResultsDto> Edit(long id, ExpenseRequestDto entity);
        Task<ServicesResultsDto> Delete(long id);
    }
}
