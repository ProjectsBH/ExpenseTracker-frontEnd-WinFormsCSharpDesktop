using ExpenseTrackerCallAPIWinForms.Data.API.ModelsAPI;
using ExpenseTrackerCallAPIWinForms.Data.API.ModelsAPI.ExpenseCategoryDto;
using ExpenseTrackerCallAPIWinForms.ViewModel.Utils.FinalResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackerCallAPIWinForms.Data.API.IExternal
{
    public interface IExpenseCategory
    {
        /*
         * من المفروض ان هذا الجزء من الكلاس تكون ارجاعها نفس ارجاع الخدمات البعيدة ثم
         * تكون في جزئية ثانية تكون ارجاعها مناسب ومفلتر للواجهة المستخدم بحيث
         * يكون الكلاس فيه فحص قيم المتغيرات قبل ارسالها وهل تم تعديلها عند التعديل
         */
        Task<string> GetTitle();
        Task<IList<ExpenseCategoryResponseDto>> GetAll();
        Task<IList<ValueIdDto>> GetValueIdAll();
        Task<ServicesResultsDto> Add(ExpenseCategoryRequestDto entity);
        Task<ServicesResultsDto> Edit(int id, ExpenseCategoryRequestDto entity);
        Task<ServicesResultsDto> Delete(int id);
    }
}
