using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackerCallAPIWinForms.Presenter.DRY
{
    class TitleMsg
    {
        public static string Msg(OperationType validType, string title = "")
        {

            Dictionary<OperationType, string> dct = new Dictionary<OperationType, string>();
            dct.Add(OperationType.add, "إضافة");
            dct.Add(OperationType.edit, "تعديل بيانات");
            dct.Add(OperationType.editActive, "تغيير حالة");
            dct.Add(OperationType.editStatus, "تعديل حالة");
            dct.Add(OperationType.delete, "حذف");
            string type = "";
            if (dct.ContainsKey(validType))
            {
                type = dct[validType];
            }

            return type + " " + title;
        }
    }
}
