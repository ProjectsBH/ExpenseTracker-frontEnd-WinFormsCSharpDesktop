using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackerCallAPIWinForms.Data.API
{
    public class LinkAPI
    {
        #region MyRegion

        #endregion

        public static APILanguage apiLanguage = APILanguage.Php;
        
        #region urlServer       
        //public const string urlServer = "http://localhost:5297/api/";
        public static string urlServer
        {
            get
            {
                string value = "";
                switch (apiLanguage)
                {

                    case APILanguage.CSharp:
                        value = "http://localhost:5297/api/"; break;
                    case APILanguage.Php:
                        value = "http://localhost:8012/expenseTrackerApi/"; break;
                    case APILanguage.NodeJS:
                        value = "http://localhost:3000/"; break;
                    case APILanguage.Python:
                        value = ""; break;
                        //default:
                        //    value = ""; break;
                }
                return value;
            }
        }
        #endregion

        #region CheckUrlStatus
        public static string linkCheckUrlStatus
        {
            get
            {
                string value = "";
                switch (apiLanguage)
                {
                    case APILanguage.CSharp:
                    case APILanguage.NodeJS:
                        value = "values/contact"; break;
                    case APILanguage.Php:
                        value = "values/contact.php"; break;
                    case APILanguage.Python:
                        value = "values/contact"; break;
                }
                return value;
            }
        }
        #endregion

        #region category
        //const string linkCategoryCSharp = "expenseCategory";
        //const string linkCategoryPhp = "category";
        public static string linkCategory
        {           
            get
            {
                string value="";
                switch (apiLanguage)
                {                    
                    case APILanguage.CSharp:
                        value= "expenseCategory"; break;
                    case APILanguage.Php:
                    case APILanguage.NodeJS:
                        value = "category"; break;
                    case APILanguage.Python:
                        value = "category"; break;
                        
                }
                return value;
            }
        }

        public static string linkCategoryGetTitle
        {
            get
            {
                //http://localhost:8012/expenseTrackerApi/category/getTitle.php
                string value = "";
                switch (apiLanguage)
                {
                    case APILanguage.CSharp:
                    case APILanguage.NodeJS:
                        value = $"{linkCategory}/getTitle"; break;
                    case APILanguage.Php:
                        value = $"{linkCategory}/getTitle.php"; break;
                    case APILanguage.Python:
                        value = $"{linkCategory}/getTitle"; break;
                }
                return value;
            }
        }

        public static string linkCategoryViews
        {
            get
            {
                string value = "";
                switch (apiLanguage)
                {
                    case APILanguage.CSharp:
                    case APILanguage.NodeJS:
                    case APILanguage.Java:
                        value = linkCategory; break;
                    case APILanguage.Php:
                        value = $"{linkCategory}/views.php"; break;
                    case APILanguage.Python:
                        value = $"{linkCategory}"; break;
                }
                return value;
            }
        }

        public static string linkCategoryValueId
        {
            get
            {
                string value = "";
                switch (apiLanguage)
                {
                    case APILanguage.CSharp:
                    case APILanguage.NodeJS:
                    case APILanguage.Java:
                        value = $"{linkCategory}/valueId"; break;
                    case APILanguage.Php:
                        value = $"{linkCategory}/valueId.php"; break;
                    case APILanguage.Python:
                        value = $"{linkCategory}"; break;
                }
                return value;
            }
        }

        public static string linkCategoryAdd
        {
            get
            {
                string value = "";
                switch (apiLanguage)
                {
                    case APILanguage.CSharp:
                    case APILanguage.NodeJS:
                    case APILanguage.Java:
                        value = linkCategory; break;
                    case APILanguage.Php:
                        value = $"{linkCategory}/add.php"; break;
                    case APILanguage.Python:
                        value = $"{linkCategory}"; break;
                }
                return value;
            }
        }

        public static string linkCategoryEdit(int id)
        {            
            string value = "";
            switch (apiLanguage)
            {
                case APILanguage.CSharp:
                case APILanguage.NodeJS:
                case APILanguage.Java:
                    value = $"{linkCategory}/{id}"; break;
                case APILanguage.Php:
                    value = $"{linkCategory}/edit.php?id={id}"; break;
                case APILanguage.Python:
                    value = $"{linkCategory}"; break;
            }
            return value;            
        }

        public static string linkCategoryDelete(int id)
        {
            string value = "";
            switch (apiLanguage)
            {
                case APILanguage.CSharp:
                case APILanguage.NodeJS:
                case APILanguage.Java:
                    value = $"{linkCategory}/{id}"; break;
                case APILanguage.Php:
                    value = $"{linkCategory}/delete.php?categoryId={id}"; break;
                case APILanguage.Python:
                    value = $"{linkCategory}"; break;
            }
            return value;           
        }


        #endregion

        #region Expenses
        public static string linkExpense
        {
            get
            {
                string value = "";
                switch (apiLanguage)
                {
                    case APILanguage.CSharp:
                    case APILanguage.NodeJS:
                    case APILanguage.Java:
                        value = "expenses"; break;
                    case APILanguage.Php:
                        value = "expenses"; break;
                    case APILanguage.Python:
                        value = "expenses"; break;
                }
                return value;
            }
        }

        public static string linkExpenseGetTitle
        {
            get
            {
                string value = "";
                switch (apiLanguage)
                {
                    case APILanguage.CSharp:
                    case APILanguage.NodeJS:
                        value = $"{linkExpense}/getTitle"; break;
                    case APILanguage.Php:
                        value = $"{linkExpense}/getTitle.php"; break;
                    case APILanguage.Python:
                        value = $"{linkExpense}/getTitle"; break;
                }
                return value;
            }
        }

        public static string linkExpenseViews
        {
            get
            {
                string value = "";
                switch (apiLanguage)
                {
                    case APILanguage.CSharp:
                    case APILanguage.NodeJS:
                    case APILanguage.Java:
                        value = linkExpense; break;
                    case APILanguage.Php:
                        value = $"{linkExpense}/views.php"; break;
                    case APILanguage.Python:
                        value = $"{linkExpense}"; break;
                }
                return value;
            }
        }

        public static string linkExpenseItem(long id)
        {
            string value = "";
            switch (apiLanguage)
            {
                case APILanguage.CSharp:
                case APILanguage.NodeJS:
                case APILanguage.Java:
                    value = $"{linkExpense}/{id}"; break;
                case APILanguage.Php:
                    value = $"{linkExpense}/viewBy.php?id={id}"; break;
                case APILanguage.Python:
                    value = $"{linkExpense}"; break;
            }
            return value;           
        }

        public static string linkExpenseAdd
        {
            get
            {
                string value = "";
                switch (apiLanguage)
                {
                    case APILanguage.CSharp:
                    case APILanguage.NodeJS:
                    case APILanguage.Java:
                        value = linkExpense; break;
                    case APILanguage.Php:
                        value = $"{linkExpense}/add.php"; break;
                    case APILanguage.Python:
                        value = $"{linkExpense}"; break;
                }
                return value;
            }
        }

        public static string linkExpenseEdit(long id)
        {
            string value = "";
            switch (apiLanguage)
            {
                case APILanguage.CSharp:
                case APILanguage.NodeJS:
                case APILanguage.Java:
                    value = $"{linkExpense}/{id}"; break;
                case APILanguage.Php:
                    value = $"{linkExpense}/edit.php?id={id}"; break;
                case APILanguage.Python:
                    value = $"{linkExpense}"; break;
            }
            return value;
        }

        public static string linkExpenseDelete(long id)
        {
            string value = "";
            switch (apiLanguage)
            {
                case APILanguage.CSharp:
                case APILanguage.NodeJS:
                case APILanguage.Java:
                    value = $"{linkExpense}/{id}"; break;
                case APILanguage.Php:
                    value = $"{linkExpense}/delete.php?id={id}"; break;
                case APILanguage.Python:
                    value = $"{linkExpense}"; break;
            }
            return value;
        }

        #endregion

        #region ExpensesReport
        public static string linkExpensesReport
        {
            get
            {
                string value = "";
                switch (apiLanguage)
                {
                    case APILanguage.CSharp:
                    case APILanguage.NodeJS:
                    case APILanguage.Java:
                        value = "expensesReport"; break;
                    case APILanguage.Php:
                        value = "expensesReport"; break;
                    case APILanguage.Python:
                        value = "expensesReport"; break;
                }
                return value;
            }
        }

        public static string linkExpensesReportGetTitle
        {
            get
            {
                string value = "";
                switch (apiLanguage)
                {
                    case APILanguage.CSharp:
                    case APILanguage.NodeJS:
                        value = $"{linkExpensesReport}/getTitle"; break;
                    case APILanguage.Php:
                        value = $"{linkExpensesReport}/getTitle.php"; break;
                    case APILanguage.Python:
                        value = $"{linkExpensesReport}/getTitle"; break;
                }
                return value;
            }
        }
        public static string linkExpensesReportViews(string method, string queryParams)
        {
            string value = "";
            switch (apiLanguage)
            {
                case APILanguage.CSharp:
                case APILanguage.NodeJS:
                case APILanguage.Java:
                    value = $"{linkExpensesReport}/{method}?{queryParams}"; break;
                case APILanguage.Php:
                    value = $"{linkExpensesReport}/{method}.php?{queryParams}"; break;
                case APILanguage.Python:
                    value = $"{linkExpensesReport}"; break;
            }
            return value;
        }
        public static string linkExpensesReportViews(int categoryId)
        {
            string value = "";
            switch (apiLanguage)
            {
                case APILanguage.CSharp:
                case APILanguage.NodeJS:
                    value = $"{linkExpensesReport}/getByCategoryId/{categoryId}"; break;
                case APILanguage.Php:
                    value = $"{linkExpensesReport}/getByCategoryId.php?categoryId={categoryId}"; break;
                case APILanguage.Python:
                    value = $"{linkExpensesReport}"; break;
            }
            return value;
        }

        #endregion


        #region Auth user
        public static string linkUser
        {
            get
            {
                string value = "";
                switch (apiLanguage)
                {
                    case APILanguage.CSharp:
                    case APILanguage.Java:
                        value = "user"; break;
                    case APILanguage.Php:
                    case APILanguage.NodeJS:
                        value = "auth"; break;
                    case APILanguage.Python:
                        value = "auth"; break;
                }
                return value;
            }
        }
        public static string linkLogin
        {
            get
            {
                string value = "";
                switch (apiLanguage)
                {
                    case APILanguage.CSharp:
                    case APILanguage.NodeJS:
                    case APILanguage.Java:
                        value = $"{linkUser}/login"; break;
                    case APILanguage.Php:
                        value = $"{linkUser}/login.php"; break;
                    case APILanguage.Python:
                        value = $"{linkUser}"; break;
                }
                return value;
            }
        }

        public static string linkSignUp
        {
            get
            {
                string value = "";
                switch (apiLanguage)
                {
                    case APILanguage.CSharp:
                    case APILanguage.NodeJS:
                    case APILanguage.Java:
                        value = $"{linkUser}/signUp"; break;
                    case APILanguage.Php:
                        value = $"{linkUser}/signup.php"; break;
                    case APILanguage.Python:
                        value = $"{linkUser}"; break;
                }
                return value;
            }
        }
        #endregion

        


        #region MyRegion

        #endregion
                
        
    }
    public enum APILanguage
    {
        CSharp,
        Php,
        Python,
        NodeJS,
        Java
    }

    #region MyRegion

    #endregion

}
