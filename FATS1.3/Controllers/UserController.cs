using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using FATS.Models;
using FATS.BusinessObject;
using FATS.DataDefine;

namespace FATS.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult DoRegister(FATUser user, string valCode)
        {            
            JsonResult result = new JsonResult();
            using (FATContainer dbContainer = new FATContainer())
            {
                valCode = valCode.Trim();
                ActivationCode existedCode = dbContainer.ActivationCode.FirstOrDefault(n => n.ActivateCode == valCode && n.CurrStatus == ConstDefine.ActivationCode_Status_Unused);
                if (existedCode == null)
                {
                    result.Data = "激活码不存在或者已被使用";
                    return result;
                }
                existedCode.CurrStatus = ConstDefine.ActivationCode_Status_Used;

                FATUser existedUser = dbContainer.FATUser.FirstOrDefault(n => n.UserCode == user.UserCode && n.School == user.School);
                if (existedUser != null)
                {
                    result.Data = "用户登录名已存在";
                    return result;
                }
                if ((user.Password.Length < 6) || (user.Password.Length > 15))
                {
                    result.Data = "密码必须在6-15位之间";
                    return result;
                }
                user.UserCode = user.UserCode.Trim();
                if (string.IsNullOrEmpty(user.UserCode))
                {
                    result.Data = "登录名不能为空";
                    return result;
                }
                FATUser newUser = dbContainer.FATUser.Create();
                newUser.UserCode = user.UserCode;
                newUser.School = user.School;
                newUser.UserName = user.UserName;
                newUser.IsStudent = 1;
                newUser.IsAdmin = 0;
                newUser.IsTeacher = 0;
                newUser.Password = user.Password;
                newUser.CurrStatus = ConstDefine.UserStatus_Valid;
                newUser.CreatedDate = DateTime.Now;
                dbContainer.FATUser.Add(newUser);

                dbContainer.SaveChanges();

                CurrentUser.UserLogin(newUser);
                result.Data = string.Empty;
                return result;
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult DoLogin(string userCode, string userPwd)
        {
            JsonResult result = new JsonResult();
            using (FATContainer dbContainer = new FATContainer())
            {
                FATUser existedUser = dbContainer.FATUser.FirstOrDefault(n => n.UserCode == userCode && n.Password == userPwd);
                if (existedUser == null)
                {
                    result.Data = "用户名或密码错误";
                    return result;
                }

                CurrentUser.UserLogin(existedUser);
                result.Data = string.Empty;
                return result;
            }
        }
    }
}
