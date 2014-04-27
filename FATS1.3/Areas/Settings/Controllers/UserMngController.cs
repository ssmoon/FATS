using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using System.IO;

using FATS.Models;

namespace FATS.Areas.Settings.Controllers
{
    public class UserMngController : Controller
    {
        //
        // GET: /Settings/UserMng/

        public ActionResult Index()
        {            
            return View("UserImport");
        }
        
        public ActionResult ImportUserList(string inputStr)
        {
            JsonResult importResult = new JsonResult();
            importResult.Data = string.Empty;
            using (FATContainer dbContainer = new FATContainer())
            {
                bool isAllProcessed = true;
                using (StreamReader textReader = new StreamReader(new MemoryStream(Encoding.UTF8.GetBytes(inputStr ?? ""))))
                {
                    string newLine = string.Empty;
                    int lineCount = 0;
                    while ((newLine = textReader.ReadLine()) != null)
                    {
                        lineCount++;
                        string[] splitArr = newLine.Split('\t');
                        if (splitArr.Length != 3)
                        {
                            isAllProcessed = false;
                            importResult.Data = "第" + lineCount + "行数据读取失败";
                            break;
                        }
                        string importUName = splitArr[0];
                        FATUser existedUser = dbContainer.FATUser.FirstOrDefault(n => n.UserName == importUName);
                        if (existedUser != null)
                        {
                            isAllProcessed = false;
                            importResult.Data = "第" + lineCount + "行数据中的登录名已存在";
                            break;
                        }
                        existedUser = dbContainer.FATUser.Create();
                        existedUser.UserName = splitArr[0];
                        existedUser.IsStudent = Convert.ToInt16(splitArr[1]);
                        existedUser.IsTeacher = Convert.ToInt16(splitArr[2]);
                        existedUser.IsAdmin = 0;
                        existedUser.CreatedDate = DateTime.Now;
                        existedUser.CurrStatus = 1;
                        existedUser.Password = "123456";
                        dbContainer.FATUser.Add(existedUser);
                    }
                }
                if (isAllProcessed)
                    dbContainer.SaveChanges();
            }
            return importResult;
        }

    }
}
