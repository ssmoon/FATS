using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using FATS.Models;
using FATS.DataDefine;
using FATS.BusinessObject;

namespace FATS.Controllers
{
    public class UICommonController : Controller
    {
        //
        // GET: /UICommon/

        public ActionResult Index()
        {
            return View();
        }
        [ChildActionOnly]
        public ActionResult CapitalDate()
        {
            DateTime date = Convert.ToDateTime(RouteData.Values["date"]);
            StringBuilder sb = new StringBuilder(12);
            string year = date.Year.ToString();
            foreach (char c in year)
            {
                sb.Append(CommFunctions.GetCapitalNumber(c));
            }
            sb.Append("年");
            return PartialView("CapitalDate", sb.ToString());
        }

        public static string[] Chinese_MoneyUnit_Arr = new string[4] { "仟", "佰", "拾", string.Empty };
        public static string[] Chinese_MoneyNumber_Arr = new string[10] { "零", "壹", "贰", "叁", "肆", "伍", "陆", "柒", "捌", "玖" };

  
        public ActionResult CapitalMoney()
        {
            string money = Convert.ToDecimal(RouteData.Values["money"]).ToString("0000000.00");
            StringBuilder sb = new StringBuilder(10);

            string part1 = money.Substring(0, 3).Insert(0, "0");
            for (int i = 0; i <= part1.Length - 1; i++)
            {
                if (part1[i] != '0')
                    sb.Append(Chinese_MoneyNumber_Arr[Convert.ToInt32(part1[i].ToString())] + Chinese_MoneyUnit_Arr[i]);
                if ((sb.ToString() != string.Empty) && (i != part1.Length - 1) && (part1[i] == '0'))
                    sb.Append("零");
            }
            sb.Append("万");
            string part2 = money.Substring(3, 4);
            for (int i = 0; i <= part1.Length - 1; i++)
            {
                if (part2[i] != '0')
                    sb.Append(Chinese_MoneyNumber_Arr[Convert.ToInt32(part2[i].ToString())] + Chinese_MoneyUnit_Arr[i]);
                if ((sb.ToString() != string.Empty) && (i != part2.Length - 1) && (part2[i] == '0'))
                    sb.Append("零");
            }
            sb.Append("元");
            string part3 = money.Substring(8, 2);

            if ((part3[0] == '0') && (part3[1] == '0'))
                sb.Append("整");
            else if ((part3[0] != '0') && (part3[1] == '0'))
                sb.Append(Chinese_MoneyNumber_Arr[Convert.ToInt32(part3[0].ToString())] + "角整");
            else if ((part3[0] == '0') && (part3[1] != '0'))
                sb.Append("零" + Chinese_MoneyNumber_Arr[Convert.ToInt32(part3[1].ToString())] + "分");
            else sb.Append(Chinese_MoneyNumber_Arr[Convert.ToInt32(part3[0].ToString())] + "角" + Chinese_MoneyNumber_Arr[Convert.ToInt32(part3[1].ToString())] + "分");

            return PartialView("CapitalMoney", sb.ToString());
        }

        [ChildActionOnly]
        public ActionResult TabledMoney()
        {
            string money = Convert.ToDecimal(RouteData.Values["money"]).ToString("0000000.00");
            money = money.Replace(".", string.Empty).Replace("0", " ");
            string[] tabledArr = new string[9];
            bool encounterFirstNumber = false;
            for (int i = 0; i <= money.Length - 1; i++)
            {
                tabledArr[i] = Convert.ToString(money[i]);
                if (tabledArr[i].Trim() != string.Empty)
                    encounterFirstNumber = true;
                if ((encounterFirstNumber) && (tabledArr[i].Trim() == string.Empty))
                {
                    tabledArr[i] = "0";
                }
            }
            return PartialView("TabledMoney", tabledArr);
        }
    }
}
