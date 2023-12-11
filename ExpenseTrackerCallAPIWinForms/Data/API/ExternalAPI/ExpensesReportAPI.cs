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
    public class ExpensesReportAPI : IExpensesReport
    {
        HttpClient client = ApiHelper.ApiClient;
        //string controllerName = "expensesReport";
        public async Task<IList<ExpenseResponseDto>> GetBy(int categoryId, DateTime fromDate, DateTime toDate)
        {
            //string requestUri = $"{controllerName}/getByCategoryIdDates?categoryId={categoryId}&fromDate={fromDate}&toDate={toDate}";
            string requestUri = LinkAPI.linkExpensesReportViews("getByCategoryIdDates",$"categoryId={categoryId}&fromDate={fromDate}&toDate={toDate}");
            return await _get(requestUri);                            
        }
        
        public async Task<IList<ExpenseResponseDto>> GetBy(DateTime fromDate, DateTime toDate)
        {
            //string requestUri = $"{controllerName}/getByDates?fromDate={fromDate}&toDate={toDate}";
            string requestUri = LinkAPI.linkExpensesReportViews("getByDates",$"fromDate={fromDate}&toDate={toDate}");
            return await _get(requestUri);
        }

        public async Task<IList<ExpenseResponseDto>> GetBy(int categoryId)
        {
            //string requestUri = $"{controllerName}/getByCategoryId/{categoryId}";
            string requestUri = LinkAPI.linkExpensesReportViews(categoryId);
            return await _get(requestUri);
        }

        private async Task<IList<ExpenseResponseDto>> _get(string requestUri)
        {
            try
            {
                if (await ResultAPIDRY.CheckUrlStatus(client))
                {
                    HttpResponseMessage response = await client.GetAsync(requestUri);
                    return await ResultAPIDRY.GetResult<IList<ExpenseResponseDto>>(response);

                }
                throw new ArgumentException(ResultsConstants.ErrorMessageConnection);
            }
            catch (Exception ex)
            {
                ServicesResultsDRY.GetException();
                throw;
            }
        }
        public async Task<string> GetTitle()
        {
            if (await ResultAPIDRY.CheckUrlStatus(client))
            {
                HttpResponseMessage response = await client.GetAsync(LinkAPI.linkExpensesReportGetTitle);
                var item = await ResultAPIDRY.GetResult<ValueDto>(response);
                return item.value.Trim('"');
            }
            return "لا يوجد إتصال";
        }

    }
}
