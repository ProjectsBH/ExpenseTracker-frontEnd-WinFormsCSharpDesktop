using ExpenseTrackerCallAPIWinForms.Data.API.IExternal;
using ExpenseTrackerCallAPIWinForms.Data.API.ModelsAPI;
using ExpenseTrackerCallAPIWinForms.Data.API.ModelsAPI.ExpenseDto;
using ExpenseTrackerCallAPIWinForms.ViewModel.Utils.FinalResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackerCallAPIWinForms.Data.API.ExternalAPI
{
    internal class ExpensesAPI : IExpenses
    {
        HttpClient client = ApiHelper.ApiClient;
        //string controllerName = "expenses";
        
        public async Task<string> GetTitle()
        {
            if (await ResultAPIDRY.CheckUrlStatus(client))
            {
                HttpResponseMessage response = await client.GetAsync(LinkAPI.linkExpenseGetTitle);
                var item = await ResultAPIDRY.GetResult<ValueDto>(response);
                return item.value.Trim('"');
            }
            return "لا يوجد إتصال";
        }
        public async Task<ServicesResultsDto> Add(ExpenseRequestDto entity)
        {
            try
            {
                if (await ResultAPIDRY.CheckUrlStatus(client))
                {
                    HttpResponseMessage response = await client.PostAsJsonAsync(LinkAPI.linkExpenseAdd, entity);
                    return await ResultAPIDRY.CheckResultWithId(response);
                }
                else return ServicesResultsDRY.GetError(ResultsTypes.None, ResultsConstants.ErrorMessageConnection);

            }
            catch (Exception)
            {
                return ServicesResultsDRY.GetException();
            }
        }
        public async Task<ServicesResultsDto> Edit(long id, ExpenseRequestDto entity)
        {
            try
            {
                if (await ResultAPIDRY.CheckUrlStatus(client))
                {
                    HttpResponseMessage response = await client.PutAsJsonAsync(LinkAPI.linkExpenseEdit(id), entity);
                    return await ResultAPIDRY.CheckResult(response);
                    
                }
                else return ServicesResultsDRY.GetError(ResultsTypes.None, ResultsConstants.ErrorMessageConnection);

            }
            catch (Exception)
            {
                return ServicesResultsDRY.GetException();
            }
        }
        public async Task<ServicesResultsDto> Delete(long id)
        {
            try
            {
                if (await ResultAPIDRY.CheckUrlStatus(client))
                {
                    HttpResponseMessage response = await client.DeleteAsync(LinkAPI.linkExpenseDelete(id));
                    return await ResultAPIDRY.CheckResult(response);
                }
                else return ServicesResultsDRY.GetError(ResultsTypes.None, ResultsConstants.ErrorMessageConnection);


            }
            catch (Exception)
            {
                return ServicesResultsDRY.GetException();
            }
        }

        public async Task<ExpenseResponseDto> GetBy(long id)
        {
            try
            {
                if (await ResultAPIDRY.CheckUrlStatus(client))
                {
                    //ResponseDto<ExpenseCategoryResponseDto> items = null;
                    HttpResponseMessage response = await client.GetAsync(LinkAPI.linkExpenseItem(id));
                    return await ResultAPIDRY.GetResult<ExpenseResponseDto>(response);
                    /*
                   if (response.IsSuccessStatusCode)
                   {
                       items = await response.Content.ReadAsAsync<ResponseDto<ExpenseCategoryResponseDto>>();
                   }
                   return items.data;
                   */
                }
                throw new ArgumentException(ResultsConstants.ErrorMessageConnection);
            }
            catch (Exception)
            {
                ServicesResultsDRY.GetException();
                throw;
            }
        }

        public async Task<IList<ExpenseResponseDto>> GetTop()
        {
            try
            {
                if (await ResultAPIDRY.CheckUrlStatus(client))
                {
                    HttpResponseMessage response = await client.GetAsync(LinkAPI.linkExpenseViews);
                    return await ResultAPIDRY.GetResult<IList<ExpenseResponseDto>>(response);

                }
                throw new ArgumentException(ResultsConstants.ErrorMessageConnection);
            }
            catch (Exception)
            {
                ServicesResultsDRY.GetException();
                throw;
            }
        }


    }
}
