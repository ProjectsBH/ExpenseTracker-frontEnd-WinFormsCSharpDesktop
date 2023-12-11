using ExpenseTrackerCallAPIWinForms.ViewModel.Utils.FinalResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackerCallAPIWinForms.Data.API
{
    class ResultAPIDRY
    {
        public static async Task<T> GetResult<T>(HttpResponseMessage response)
        {
            ResponseDto<T> items = null;
            if (response.IsSuccessStatusCode)
            {
                items = await response.Content.ReadAsAsync<ResponseDto<T>>();
            }
            return items.data;
        }
        public static async Task<ServicesResultsDto> CheckResult(HttpResponseMessage response)
        {
            return await CheckResult<dynamic>(response);
        }
        public static async Task<ServicesResultsDto> CheckResult<T>(HttpResponseMessage response)
        {
            var result = await getResponse<dynamic>(response);
            if (result != null)
            {
                if (result.is_success)
                    return ServicesResultsDRY.GetSuccess();
                else
                    return ServicesResultsDRY.GetError(ResultsTypes.Incorrect_Input, message: result.message);
            }
            else return ServicesResultsDRY.GetError(ResultsTypes.None);
            /*
            // التحقق من نجاح الاستجابة ورمي استثناء في حالة عدم النجاح
            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsAsync<ResponseDto<T>>();
                if (result.is_success)
                    return ServicesResultsDRY.GetSuccess();
                else
                    return ServicesResultsDRY.GetError(ResultsTypes.Incorrect_Input, message: result.message);
            }
            else return ServicesResultsDRY.GetError(ResultsTypes.None);
            */

        }

        public static async Task<ServicesResultsDto> CheckResultWithId(HttpResponseMessage response)
        {
            var result =await getResponse<dynamic>(response);
            if (result!= null)
            {
                if (result.is_success)
                    return ServicesResultsDRY.GetSuccessWithId(result.data["id"]);
                else
                    return ServicesResultsDRY.GetError(ResultsTypes.Incorrect_Input, message: result.message);
            }
            else return ServicesResultsDRY.GetError(ResultsTypes.None);
        }

        private static async Task<ResponseDto<T>> getResponse<T>(HttpResponseMessage response)
        {
            // التحقق من نجاح الاستجابة ورمي استثناء في حالة عدم النجاح
            ResponseDto<T> result = null;
            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsAsync<ResponseDto<T>>();
            }
            return result;
        }


        static bool isValidUri = false;
        // دالة فحص الاتصال هل يوجد اتصال او لا يوجد
        public static async Task<bool> CheckUrlStatus(HttpClient client)
        {
            try
            {
                // var client = ApiHelper.ApiClient
                //var controllerName = "values";
                if (isValidUri == false)
                {
                    //string method = $"{controllerName}/contact";
                    //HttpResponseMessage response = await client.GetAsync(method);
                    HttpResponseMessage response = await client.GetAsync(LinkAPI.linkCheckUrlStatus);
                    if (response.IsSuccessStatusCode)
                    {
                        isValidUri = true;
                    }
                    //isValidUri= false;
                }
                return isValidUri;
            }
            catch
            {
                return false;
            }
        }

        #region MyRegion

        #endregion
    }
}
