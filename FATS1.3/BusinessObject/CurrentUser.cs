using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using FATS.Models;
using FATS.DataDefine;
using FATS.Exceptions;

namespace FATS.BusinessObject
{
    public class CurrentUser
    {
        public const string SessionObj_UserInfo = "UserInfo";
        public const string SessionObj_UserID = "UserID";
        public const string SessionObj_UserName = "UserName";
        public const string SessionObj_UserRole = "SessionObj_UserRole";
        public const string SessionObj_Teaching1Status = "Teaching1Status";
            
        public static void UserLogin(FATUser user)
        {
            using (var dbContainer = new FATContainer())
            {
                HttpContext.Current.Session[SessionObj_UserInfo] = user;
                HttpContext.Current.Session[SessionObj_UserID] = user.Row_ID;
                HttpContext.Current.Session[SessionObj_UserName] = user.UserName;
                if (user.IsAdmin == 1)
                    HttpContext.Current.Session[SessionObj_UserRole] = "管理员";
                else if (user.IsTeacher == 1)
                    HttpContext.Current.Session[SessionObj_UserRole] = "教师";
                else HttpContext.Current.Session[SessionObj_UserRole] = "学生";
            }

        }

        public static void CreateUser(FATUser userInfo)
        {
            if (userInfo.Password.Length < 6)
                throw new BusinessRuleCheckExcpetions("密码长度必须大于6位");
            if (userInfo.UserName == string.Empty)
                throw new BusinessRuleCheckExcpetions("用户名称不能为空");
            using (var dbContainer = new FATContainer())
            {
                var codeExisted = dbContainer.FATUser.Any(user => user.UserName == userInfo.UserName);
                if (!codeExisted)
                {
                    throw new BusinessRuleCheckExcpetions("该用户名已存在");
                }
                userInfo.CreatedDate = DateTime.Now;
                userInfo.CurrStatus = ConstDefine.UserStatus_Valid;
                dbContainer.FATUser.Add(userInfo);
                dbContainer.SaveChanges();
            }
        }

        public static string GetUserRole()
        {
            if (HttpContext.Current.Session[SessionObj_UserRole] == null)
                throw new UserSessionExpiredException("请重新登录系统。");
            return Convert.ToString(HttpContext.Current.Session[SessionObj_UserRole]);
        }

        public static int GetUserID()
        {
            if (HttpContext.Current.Session[SessionObj_UserInfo] == null)
                throw new UserSessionExpiredException("请重新登录系统。");
            return Convert.ToInt32(HttpContext.Current.Session[SessionObj_UserID]);
        }

        public static string GetUserName()
        {
            return HttpContext.Current.Session[SessionObj_UserName].ToString();
        }

        public static FATUser GetUserInfo()
        {
            if (HttpContext.Current.Session[SessionObj_UserInfo] == null)
                throw new UserSessionExpiredException("请重新登录系统。");
            return HttpContext.Current.Session[SessionObj_UserInfo] as FATUser;
        }

        public static bool CheckIsLogIn()
        {
            return (HttpContext.Current.Session[SessionObj_UserInfo] != null);
        }

        public static void SetLastFinishedRoutineID(int tchRoutineID)
        {
            HttpContext.Current.Session[ConstDefine.SessionKey_FinishedRoutineID] = tchRoutineID;
        }
    }

}
