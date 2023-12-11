using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackerCallAPIWinForms.Data.API.ModelsAPI.ExpenseCategoryDto
{
    public class ExpenseCategoryRequestDto
    {
        public string name { get; set; }
        public bool isLimitAmount { get; set; }
        public decimal limitAmount { get; set; }
        public int userId { get; set; } = 1;
    }
}
