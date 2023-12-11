using ExpenseTrackerCallAPIWinForms.Data.API.IExternal;
using ExpenseTrackerCallAPIWinForms.Data.API.ModelsAPI;
using ExpenseTrackerCallAPIWinForms.Data.API.ModelsAPI.ExpenseCategoryDto;
using ExpenseTrackerCallAPIWinForms.ViewModel.Utils.FinalResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackerCallAPIWinForms.Data.API.ExternalAPI
{
    public class ExpenseCategoryAPI : IExpenseCategory
    {
        #region snippet_HttpClient
        HttpClient client = ApiHelper.ApiClient;
        #endregion

        //string controllerName = "expenseCategory";


        //install Microsoft.AspNet.WebApi.Client
        // Newtonsoft.Json
        public async Task<string> GetTitle()
        {
            if (await ResultAPIDRY.CheckUrlStatus(client))// من أجل فحص الاتصال اولا
            {
                //HttpResponseMessage response = await client.GetAsync($"{controllerName}/getTitle");
                HttpResponseMessage response = await client.GetAsync(LinkAPI.linkCategoryGetTitle);
                var item = await ResultAPIDRY.GetResult<ValueDto>(response);
                /*
                if (response.IsSuccessStatusCode)
                {
                    //item = await response.Content.ReadAsStringAsync(); // string
                    item = await response.Content.ReadAsAsync<ResponseDto<ValueDto>>();
                }
                return item.data.value.Trim('"');
                 */
                return item.value.Trim('"');
            }
            return "لا يوجد إتصال";
            //throw new NotImplementedException();
        }

        public async Task<IList<ExpenseCategoryResponseDto>> GetAll()
        {
            try
            {
                if (await ResultAPIDRY.CheckUrlStatus(client))
                {
                    //ResponseDto<IList<ExpenseCategoryResponseDto>> items = null;
                    HttpResponseMessage response = await client.GetAsync(LinkAPI.linkCategoryViews);
                    /*
                    if (response.IsSuccessStatusCode)
                    {
                        items = await response.Content.ReadAsAsync<ResponseDto<IList<ExpenseCategoryResponseDto>>>();
                    }
                    return items.data;
                     */
                    return await ResultAPIDRY.GetResult<IList<ExpenseCategoryResponseDto>>(response);
                    
                }
                throw new ArgumentException(ResultsConstants.ErrorMessageConnection);
            }
            catch (Exception ex)
            {
                ServicesResultsDRY.GetException();
                throw;
            }
        }

        public async Task<IList<ValueIdDto>> GetValueIdAll()
        {
            try
            {
                if (await ResultAPIDRY.CheckUrlStatus(client))
                {
                    //ResponseDto<IList<ValueIdDto>> items = null;
                    //HttpResponseMessage response = await client.GetAsync(controllerName+"/valueId");
                    HttpResponseMessage response = await client.GetAsync(LinkAPI.linkCategoryValueId);
                    return  await ResultAPIDRY.GetResult<IList<ValueIdDto>>(response);
                    /*
                    if (response.IsSuccessStatusCode)
                    {
                        items = await response.Content.ReadAsAsync<ResponseDto<IList<ValueIdDto>>>();
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


        public async Task<ServicesResultsDto> Add(ExpenseCategoryRequestDto entity)
        {
            try
            {
                if (await ResultAPIDRY.CheckUrlStatus(client))
                {
                    HttpResponseMessage response = await client.PostAsJsonAsync(LinkAPI.linkCategoryAdd, entity);
                    return await ResultAPIDRY.CheckResultWithId(response);
                }
                else return ServicesResultsDRY.GetError(ResultsTypes.None, ResultsConstants.ErrorMessageConnection);

            }
            catch (Exception)
            {
                return ServicesResultsDRY.GetException();
            }
        }

        
        public async Task<ServicesResultsDto> Edit(int id, ExpenseCategoryRequestDto entity)
        {
            try
            {
                if (await ResultAPIDRY.CheckUrlStatus(client))
                {
                    //HttpResponseMessage response = await client.PutAsJsonAsync($"{controllerName}/{id}", entity);
                    HttpResponseMessage response = await client.PutAsJsonAsync(LinkAPI.linkCategoryEdit(id), entity);
                    //response.EnsureSuccessStatusCode();
                    return await ResultAPIDRY.CheckResult(response);
                    /*
                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsAsync<ResponseDto<dynamic>>();
                        if(result.is_success)
                        return ServicesResultsDRY.GetSuccess();
                        else
                            return ServicesResultsDRY.GetError(ResultsTypes.Incorrect_Input,message: result.message);
                    }
                    else return ServicesResultsDRY.GetError(ResultsTypes.None);
                    */
                }
                else return ServicesResultsDRY.GetError(ResultsTypes.None, ResultsConstants.ErrorMessageConnection);

            }
            catch (Exception)
            {
                return ServicesResultsDRY.GetException();
            }
        }

        public async Task<ServicesResultsDto> Delete(int id)
        {
            try
            {
                if (await ResultAPIDRY.CheckUrlStatus(client))
                {
                    HttpResponseMessage response = await client.DeleteAsync(LinkAPI.linkCategoryDelete(id));
                    return await ResultAPIDRY.CheckResult(response);
                }
                else return ServicesResultsDRY.GetError(ResultsTypes.None, ResultsConstants.ErrorMessageConnection);


            }
            catch (Exception ex)
            {
                return ServicesResultsDRY.GetException();
            }
        }


        

        

    }
}
