using ExpenseTrackerCallAPIWinForms.Data.API.ModelsAPI.UserDto;
using ExpenseTrackerCallAPIWinForms.ViewModel.Utils.FinalResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackerCallAPIWinForms.Data.API.IExternal
{
    public interface IUser
    {
        Task<ServicesResultsDto> Login(string userName, string password);
        Task<ServicesResultsDto> SignUp(UserRequestDto entity);
    }
}
