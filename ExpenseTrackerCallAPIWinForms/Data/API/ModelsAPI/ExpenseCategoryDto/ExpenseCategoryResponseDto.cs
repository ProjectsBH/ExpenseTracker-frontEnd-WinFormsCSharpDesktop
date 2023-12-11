using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackerCallAPIWinForms.Data.API.ModelsAPI.ExpenseCategoryDto
{
    public class ExpenseCategoryResponseDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public bool isLimitAmount { get; set; }
        public decimal limitAmount { get; set; }
        public DateTime created_in { get; set; }
        public int created_by { get; set; }
        public string isLimitAmountName { get; set; }
    }
}
