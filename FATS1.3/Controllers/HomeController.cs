using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using FATS.BusinessObject;
using FATS.Models;

namespace FATS.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            using (FATContainer dbContainer = new FATContainer())
            {
                JsonResult result = new JsonResult();
                FATUser user = dbContainer.FATUser.FirstOrDefault(n => ((n.UserName == "admin") && (n.Password == "888888")));

                if (user == null)
                    result.Data = "登录失败";
                else
                {
                    CurrentUser.UserLogin(user);                 
                }                
            }
            return View("mainpage");
        }

        public ActionResult UserLogin(string name, string pwd)
        {
            using (FATContainer dbContainer = new FATContainer())
            {
                JsonResult result = new JsonResult();
                FATUser user = dbContainer.FATUser.FirstOrDefault(n => ((n.UserName == name.ToLower()) && (n.Password == pwd)));

                if (user == null)
                    result.Data = "登录失败";
                else
                {
                    CurrentUser.UserLogin(user);     
                    result.Data = "";
                }
                return result;
            }
        }

        public ActionResult ChangePwd(string orgPwd, string newPwd)
        {
            //using (FATContainer dbContainer = new FATContainer())
            //{
            //    JsonResult result = new JsonResult();
            //    int currUID = UnitedLoginMng.GetUserID();
            //    U_User user = dbContainer.U_User.FirstOrDefault(n => ((n.Row_ID == currUID) && (n.UserPwd == orgPwd)));
            //    if (user == null)
            //    {
            //        result.Data = "未找到用户或者原密码不正确";
            //        return result;
            //    }
            //    user.UserPwd = newPwd;
            //    dbContainer.SaveChanges();
            //    result.Data = string.Empty;

            //    return result;
            //}
            return null;
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            Session.Clear();
            return View("Login");
        }


        public ActionResult MainPage()
        {
            return View("Mainpage");
        }

        public ActionResult SysMenu()
        {
            return PartialView(null);
        }
    }
}
