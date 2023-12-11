using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackerCallAPIWinForms.ViewModel.Utils.FinalResults
{
    public class ResponseDto<T> //<T> where T : class, new(
    {
        public bool is_success { get; set; }
        public string message { get; set; }
        public string code { get; set; } // response_code
        public string operation_type { get; set; }
        //public OperationTypeResponse operation_type { get; set; }
        //public dynamic data { get; set; }
        public T data { get; set; }
        public Error error { get; set; }
    }

    public class Error
    {
        public string error_code { get; set; }
        public string error_message { get; set; }
    }


}
