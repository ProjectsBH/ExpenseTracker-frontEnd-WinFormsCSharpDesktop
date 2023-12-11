
using System;

namespace ExpenseTrackerCallAPIWinForms.Data.API.ModelsAPI.UserDto
{
    public class UserRequestDto
    {
        public string userName { get; set; }
        public string password { get; set; }
        public string confirmPassword { get; set; }
        public string email { get; set; }
        
    }
}
