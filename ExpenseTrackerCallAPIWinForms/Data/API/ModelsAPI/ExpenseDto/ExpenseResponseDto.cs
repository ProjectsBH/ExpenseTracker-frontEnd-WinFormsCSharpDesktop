
using System;

namespace ExpenseTrackerCallAPIWinForms.Data.API.ModelsAPI.ExpenseDto
{
    public class ExpenseResponseDto
    {
        public long id { get; set; }
        public int categoryId { get; set; }       
        public DateTime theDate { get; set; }
        public decimal amount { get; set; }
        public string categoryName { get; set; }
        public string theStatement { get; set; }
        public DateTime created_in { get; set; }
        public int created_by { get; set; }

        
    }
}
