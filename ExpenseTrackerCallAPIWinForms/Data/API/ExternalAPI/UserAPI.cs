using ExpenseTrackerCallAPIWinForms.Data.API.IExternal;
using ExpenseTrackerCallAPIWinForms.Data.API.ModelsAPI.UserDto;
using ExpenseTrackerCallAPIWinForms.ViewModel.Utils.FinalResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackerCallAPIWinForms.Data.API.ExternalAPI
{
    public class UserAPI : IUser
    {
        HttpClient client = ApiHelper.ApiClient;
        //string controllerName = LinkAPI.linkUser;

        public async Task<ServicesResultsDto> Login(string userName, string password)
        {
            try
            {
                LoginDto entity = new LoginDto() {userName=userName,password=password };
                if (await ResultAPIDRY.CheckUrlStatus(client))
                {
                    HttpResponseMessage response = await client.PostAsJsonAsync(LinkAPI.linkLogin, entity);
                    return await ResultAPIDRY.CheckResult(response);
                }
                else return ServicesResultsDRY.GetError(ResultsTypes.None, ResultsConstants.ErrorMessageConnection);

            }
            catch (Exception)
            {
                return ServicesResultsDRY.GetException();
            }
        }

        public async Task<ServicesResultsDto> SignUp(UserRequestDto entity)
        {
            try
            {
                if (await ResultAPIDRY.CheckUrlStatus(client))
                {
                    HttpResponseMessage response = await client.PostAsJsonAsync(LinkAPI.linkSignUp, entity);
                    return await ResultAPIDRY.CheckResult(response);
                }
                else return ServicesResultsDRY.GetError(ResultsTypes.None, ResultsConstants.ErrorMessageConnection);

            }
            catch (Exception)
            {
                return ServicesResultsDRY.GetException();
            }
        }


    }
}
