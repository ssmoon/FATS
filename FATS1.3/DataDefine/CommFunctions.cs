using System;
using System.Collections;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FATS.DataDefine
{
    public class CommFunctions
    {
        // Assert Method with warning msg required
        public static void Assert(bool condition, string message)
        {
            System.Diagnostics.Debug.Assert(condition, message);
        }

        public static void Assert(bool condition)
        {
            System.Diagnostics.Debug.Assert(condition, "Transaction is null!");
        }

        public static string GetFormatedMonthData()
        {
            return DateTime.Now.Year + DateTime.Now.Month.ToString("00");
        }

        //获得日期中的时间并格式化
        public static string GetFormatedTimeStr(DateTime time)
        {
            return time.Hour.ToString("00") + ":" + time.Minute.ToString("00");
        }

        //获得日期中的月日并格式化
        public static string GetFormatedDateStr(DateTime time)
        {
            return time.Month.ToString("00") + "-" + time.Day.ToString("00");
        }


        //格式化时间至XX年X月X日的形式
        public static string FormatDateTimeToNormal(DateTime dt)
        {
            return String.Format("{0}年{1}月{2}日", dt.Year.ToString(), dt.Month.ToString(), dt.Day.ToString());
        }

        //格式化时间至XX年X月的形式
        public static string FormatDateTimeToMonth(DateTime dt)
        {
            return String.Format("{0}年{1}月", dt.Year.ToString(), dt.Month.ToString());
        }

        //格式化时间至XXXX-XX-XX的形式


        public static DateTime GetDateTimeDatePart(DateTime dt)
        {
            return Convert.ToDateTime(FormatDateTimeToCompact(dt));
        }

        //add by cjl
        public static string FormatDateTimeToSimplyDate(DateTime dt)
        {
            return dt.Year.ToString().Substring(2) + dt.Month.ToString("00") + dt.Day.ToString("00");
        }

        //add by qjl
        public static string FormatDateTimeToMonthAndDay(DateTime dt)
        {
            return dt.Month.ToString("00") + "-" + dt.Day.ToString("00") + " " + dt.Hour.ToString("00") + ":" + dt.Minute.ToString("00");
        }

        public static string FormatDateTimeToCompact(DateTime dt)
        {
            return dt.Year.ToString("0000") + "-" + dt.Month.ToString("00") + "-" + dt.Day.ToString("00");
        }

        public static string FormatDateTimeToDate(DateTime dt)
        {
            return dt.Year.ToString("0000") + dt.Month.ToString("00") + dt.Day.ToString("00");
        }

        //modified to cut day part
        public static string FormatDateTimeToSpecialForm1(DateTime dt)
        {
            return dt.Hour.ToString("00") + dt.Minute.ToString("00") + dt.Second.ToString("00");
        }

        public static string FormatDateTimeToSpecialForm2(DateTime dt)
        {
            return dt.Year.ToString("0000") + dt.Month.ToString("00") + dt.Day.ToString("00") + dt.Hour.ToString("00") + dt.Minute.ToString("00") + dt.Second.ToString("00");
        }

        public static string FormatDateTimeToSpecialForm3(DateTime dt)
        {
            return dt.Month.ToString("00") + dt.Day.ToString("00") + dt.Minute.ToString("00") + (new Random()).Next(1000, 9999).ToString();
        }

        public static string FormatDateTimeToFormat1(DateTime dt)
        {
            return dt.Month.ToString("00") + "-" + dt.Day.ToString("00");
        }

        public static string FormatDateTimeToFull(DateTime dt)
        {
            return dt.Year.ToString("0000") + "-" + dt.Month.ToString("00") + "-" + dt.Day.ToString("00") + " " + dt.Hour.ToString("00") + ":" + dt.Minute.ToString("00") + ":" + dt.Second.ToString("00");
        }

        public static string FormatDateTimeToFullWithoutSecond(DateTime dt)
        {
            return dt.Year.ToString("0000") + "-" + dt.Month.ToString("00") + "-" + dt.Day.ToString("00") + " " + dt.Hour.ToString("00") + ":" + dt.Minute.ToString("00");
        }

        public static string GetTimeDiff(DateTime compareTime, DateTime currTime)
        {
            if (currTime.Date != compareTime.Date)
                return CommFunctions.FormatDateTimeToMonthAndDay(compareTime);
            else
            {
                TimeSpan span = currTime.Subtract(compareTime);
                if (span.TotalHours < 1)
                    return span.TotalMinutes.ToString("F0") + "分钟前";
                else return span.TotalHours.ToString("F0") + "小时前";
            }
        }

        public static string GetTimeDiffEx(DateTime compareTime, DateTime currTime)
        {
            if (currTime.Date != compareTime.Date)
                return CommFunctions.FormatDateTimeToFullWithoutSecond(compareTime);
            else
            {
                TimeSpan span = currTime.Subtract(compareTime);
                if (span.TotalHours < 1)
                    return span.TotalMinutes.ToString("F0") + "分钟前";
                else return span.TotalHours.ToString("F0") + "小时前";
            }
        }


        public static string ConvertNormalTextToHTMLFormat(System.Web.HttpServerUtility serverObj, string orgText)
        {
            return ("<p>" + serverObj.HtmlEncode(orgText).Replace("\n", "</p><p>").Replace("\r", "") + "</p>");
        }

        public static string PurgeHTMLTag(string strHtml)
        {
            if (strHtml.Equals("") || strHtml.Equals(null))
                return "";
            else
            {
                string strOutput = strHtml;
                Regex regEx = new Regex(@"<[^>]+>|</[^>]+>");
                strOutput = regEx.Replace(strOutput, "");
                return strOutput;
            }
        }

        public static bool IsNumeric(string str) //接收一个string类型的参数,保存到str里
        {
            if (str == null || str.Length == 0)    //验证这个参数是否为空
                return false;                           //是，就返回False
            ASCIIEncoding ascii = new ASCIIEncoding();//new ASCIIEncoding 的实例



            byte[] bytestr = ascii.GetBytes(str);         //把string类型的参数保存到数组里


            foreach (byte c in bytestr)                   //遍历这个数组里的内容
            {
                if (c < 48 || c > 57)                          //判断是否为数字
                {
                    return false;                              //不是，就返回False
                }
            }
            return true;                                        //是，就返回True
        }

        public static ClientGridDataWrapper WrapClientGridData(dynamic data, int totalRows = 0)
        {
            ClientGridDataWrapper wrapper = new ClientGridDataWrapper();
            wrapper.sEcho = 1;
            if (totalRows == 0)
                wrapper.iTotalRecords = (data as ICollection).Count;
            else wrapper.iTotalRecords = totalRows;
            wrapper.iTotalDisplayRecords = wrapper.iTotalRecords;
            wrapper.aaData = data;
            return wrapper;
        }


        public static string GetRoleCNNameByType(int roleType)
        {
            return "学生";
        }

        public static string FormatTimeField(DateTime time)
        {
            return "[" + CommFunctions.FormatDateTimeToCompact(time) + "]";
        }

        public static string FormatNameField(string personName)
        {
            return "[" + personName.PadLeft(10, ' ') + "]";
        }

        public static string FormatClassSpan(DateTime beginTime, int lengthInMinutes)
        {
            StringBuilder sb = new StringBuilder(13);
            sb.Append(beginTime.Year);
            sb.Append("-");
            sb.Append(beginTime.Month);
            sb.Append("-");
            sb.Append(beginTime.Day);
            sb.Append("  ");
            sb.Append(beginTime.Hour.ToString("00"));
            sb.Append(":");
            sb.Append(beginTime.Minute.ToString("00"));
            sb.Append(" - ");
            sb.Append(beginTime.AddMinutes(lengthInMinutes).Hour.ToString("00"));
            sb.Append(":");
            sb.Append(beginTime.AddMinutes(lengthInMinutes).Minute.ToString("00"));
            return sb.ToString();
        }

        public static string GetCapitalNumber(char c)
        {
            switch (c)
            {
                case '0': return "零";
                case '1': return "壹";
                case '2': return "贰";
                case '3': return "叁";
                case '4': return "肆";
                case '5': return "伍";
                case '6': return "陆";
                case '7': return "染";
                case '8': return "捌";
                case '9': return "玖";
                default: return string.Empty;
            }
        }

        public static string FormatMoneyToString(decimal money)
        {
            return money.ToString("0.00");
        }
    }
}