
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackerCallAPIWinForms.Data.API.ModelsAPI.ExpenseDto
{
    public class ExpenseRequestDto
    {
        public int categoryId { get; set; }
        public DateTime theDate { get; set; }
        public decimal amount { get; set; }
        public string theStatement { get; set; }
        public int userId { get; set; } = 1;

    }
}
