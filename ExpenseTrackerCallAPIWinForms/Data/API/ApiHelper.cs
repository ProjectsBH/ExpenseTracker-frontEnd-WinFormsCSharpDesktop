using ExpenseTrackerCallAPIWinForms.Data.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackerCallAPIWinForms.Data.API
{
    public class ApiHelper
    {
        //public static HttpClient ApiClient { get; set; }
        private static HttpClient instance = null;
        public static HttpClient ApiClient
        {
            get
            {
                if (instance == null)
                {
                    instance = new HttpClient();
                    InitializeClient();
                }
                return instance;
            }
        }
        public static void InitializeClient()
        {
            // تهيئة الكلاس فس دالة البناء واسناد رابط الخدمة البعيدة
            //client.BaseAddress = new Uri("http://localhost:5075/api/");
            ApiClient.BaseAddress = new Uri(LinkAPI.urlServer);
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }



        #region Singleton Design Pattern
        /*
         * Private and parameterless single constructor.
         * Sealed class.
         * Static variable to hold a reference to the single created instance.
         * A public and static way of getting the reference to the created instance.
         */
        /*
       private ApiHelper() { }
       private static ApiHelper instance = null;
       public static ApiHelper Instance
       {
           get
           {
               if (instance == null)
               {
                   instance = new ApiHelper();
                   InitializeClient();
               }
               return instance;
           }
       }
       */
        #endregion

    }
}
