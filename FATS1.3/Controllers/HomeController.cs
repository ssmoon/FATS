using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using FATS.BusinessObject;
using FATS.Models;

using System.Data.OleDb;
using System.Data;
using System.Data.SqlClient;

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

        public ActionResult Import()
        {
            return View();
        }

        public ActionResult DoImport()
        {
            var connectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0}; Extended Properties=Excel 12.0;", Server.MapPath("~/App_Data/deposit.xls"));

            var adapter1 = new OleDbDataAdapter("SELECT * FROM [TeachingRoutine$]", connectionString);
            var adapter2 = new OleDbDataAdapter("SELECT * FROM [RoutineGroup$]", connectionString);
            var adapter3 = new OleDbDataAdapter("SELECT * FROM [TemplateNode$]", connectionString);
            var adapter4 = new OleDbDataAdapter("SELECT * FROM [IndividualSaving$]", connectionString);
            var adapter5 = new OleDbDataAdapter("SELECT * FROM [SubjectItem$]", connectionString);
            var adapter6 = new OleDbDataAdapter("SELECT * FROM [CashJournal$]", connectionString);
            var adapter7 = new OleDbDataAdapter("SELECT * FROM [DetailedLedger$]", connectionString);
            var adapter8 = new OleDbDataAdapter("SELECT * FROM [CustomerLedger$]", connectionString);
            var adapter9 = new OleDbDataAdapter("SELECT * FROM [GeneralLedger$]", connectionString);
            var adapter10 = new OleDbDataAdapter("SELECT * FROM [OuterSubject$]", connectionString);
            var ds = new DataSet();

            adapter1.Fill(ds, "TeachingRoutine");
            adapter2.Fill(ds, "RoutineGroup");
            adapter3.Fill(ds, "TemplateNode");
            adapter4.Fill(ds, "IndividualSaving");
            adapter5.Fill(ds, "SubjectItem");
            adapter6.Fill(ds, "CashJournal");
            adapter7.Fill(ds, "DetailedLedger");
            adapter8.Fill(ds, "CustomerLedger");
            adapter9.Fill(ds, "GeneralLedger");
            adapter10.Fill(ds, "OuterSubject");

            DataTable TeachingRoutine = ds.Tables["TeachingRoutine"];
            DataTable RoutineGroup = ds.Tables["RoutineGroup"];
            DataTable TemplateNode = ds.Tables["TemplateNode"];
            DataTable IndividualSaving = ds.Tables["IndividualSaving"];
            DataTable SubjectItem = ds.Tables["SubjectItem"];
            DataTable CashJournal = ds.Tables["CashJournal"];
            DataTable DetailedLedger = ds.Tables["DetailedLedger"];
            DataTable CustomerLedger = ds.Tables["CustomerLedger"];
            DataTable GeneralLedger = ds.Tables["GeneralLedger"];
            DataTable OuterSubject = ds.Tables["OuterSubject"];
            using (FATContainer dbContainer = new FATContainer())
            {
                dbContainer.Database.ExecuteSqlCommand("exec DelTestRoutine @ids", new SqlParameter("@ids", "('9-1', '9-2', '9-3', '9-4', '10-1', '10-2', '11-1', '11-2', '12-1', '12-2', '12-3', '13-1', '13-2', '13-3')"));

                List<TemplateRoutine> tmpRoutineList = new List<TemplateRoutine>();
                foreach (DataRow row in TeachingRoutine.Rows)
                {
                    if (row["Row_ID"] is DBNull)
                        continue;
                    TemplateRoutine routine = dbContainer.TemplateRoutine.Create();
                    routine.Row_ID = Convert.ToString(row["Row_ID"]);
                    routine.RoutineName = Convert.ToString(row["RoutineName"]);
                    routine.RoutineDesc = Convert.ToString(row["RoutineDesc"]);
                    routine.RoutineType = Convert.ToInt32(row["RoutineType"]);
                    routine.RoutineTag = Convert.ToString(row["RoutineTag"]);
                    tmpRoutineList.Add(routine);

                    dbContainer.TemplateRoutine.Add(routine);
                }
                dbContainer.SaveChanges();

                List<TemplateNode> tmpNodeList = new List<TemplateNode>();
                foreach (DataRow row in TemplateNode.Rows)
                {
                    if (row["Row_ID"] is DBNull)
                        continue;
                    TemplateNode node = dbContainer.TemplateNode.Create();
                    node.Row_ID = Convert.ToString(row["Row_ID"]);
                    node.RoutineID = Convert.ToString(row["TchRoutineID"]);
                    node.NodeIndex = Convert.ToInt32(row["NodeIndex"]);
                    node.NodeName = Convert.ToString(row["NodeName"]);
                    node.GroupIdx = Convert.ToInt32(row["GroupIdx"]);
                    node.RequireRecord = Convert.ToInt32(row["RequireRecord"]);
                    node.Tag = Convert.ToString(row["Tag"]);
                    node.NodeType = Convert.ToString(row["NodeType"]);
                    tmpNodeList.Add(node);

                    dbContainer.TemplateNode.Add(node);
                }
                dbContainer.SaveChanges();

                List<TeachingRoutine> teachingRList = tmpRoutineList.Select(n => new TeachingRoutine() { CurrStatus = 0, CaseName = n.RoutineName, TmpRoutineID = n.Row_ID }).ToList();
                dbContainer.TeachingRoutine.AddRange(teachingRList);
                dbContainer.SaveChanges();

                Dictionary<string, TeachingRoutine> templateTeachingRoutineMapper = teachingRList.ToDictionary(n => n.TmpRoutineID);

                List<TeachingNode> teachingNList = new List<TeachingNode>();
                foreach (TemplateNode tmpNode in tmpNodeList)
                {
                    TeachingNode teachingNode = dbContainer.TeachingNode.Create();
                    teachingNode.CurrStatus = 0;
                    teachingNode.TmpNodeID = tmpNode.Row_ID;
                    teachingNode.RoutineID = templateTeachingRoutineMapper[tmpNode.RoutineID].Row_ID;
                    dbContainer.TeachingNode.Add(teachingNode);
                    teachingNList.Add(teachingNode);
                }
                dbContainer.SaveChanges();

                Dictionary<string, TeachingNode> templateTeachingNodeMapper = teachingNList.ToDictionary(n => n.TmpNodeID);

                Dictionary<string, TemplateNode> templateNodeDict = tmpNodeList.ToDictionary(n => n.Row_ID);

                List<RoutineGroup> groupList = new List<RoutineGroup>();
                foreach (DataRow row in RoutineGroup.Rows)
                {
                    if (row["TchRoutineID"] is DBNull)
                        continue;
                    RoutineGroup obj = dbContainer.RoutineGroup.Create();
                    obj.GroupText = Convert.ToString(row["GroupText"]);
                    obj.GroupIdx = Convert.ToInt32(row["GroupIdx"]);
                    obj.RoutineIntro = Convert.ToString(row["RoutineIntro"]);
                    obj.TchRoutineID = templateTeachingRoutineMapper[Convert.ToString(row["TchRoutineID"])].Row_ID;
                    obj.RoutineDesc = obj.GroupIdx + "." + Convert.ToString(row["RoutineDesc"]);
                    groupList.Add(obj);
                    dbContainer.RoutineGroup.Add(obj);
                }
                dbContainer.SaveChanges();

                Dictionary<string, RoutineGroup> groupMapper = groupList.ToDictionary(n => n.TchRoutineID + "-" + n.GroupIdx);

                foreach (DataRow row in IndividualSaving.Rows)
                {
                    if (row["TchRoutineID"] is DBNull)
                        continue;
                    IndividualSaving obj = dbContainer.IndividualSaving.Create();
                    obj.TchRoutineID = templateTeachingRoutineMapper[Convert.ToString(row["TchRoutineID"])].Row_ID;
                    obj.TchRoutineTag = string.Empty;
                    obj.InterestTime = Convert.ToDateTime(row["InterestTime"]);
                    obj.AccountCreateTime = Convert.ToDateTime(row["AccountCreateTime"]);
                    obj.DepositTime = Convert.ToDateTime(row["DepositTime"]);
                    obj.WithdrawTime = Convert.ToDateTime(row["WithdrawTime"]);
                    obj.InterestAmount = row["InterestAmount"] is DBNull ? 0 : Convert.ToDecimal(row["InterestAmount"]);
                    obj.EntryAmount = row["EntryAmount"] is DBNull ? 0 : Convert.ToDecimal(row["EntryAmount"]);                    
                    obj.ClientAcc = Convert.ToString(row["ClientAcc"]);
                    obj.DepositClient = Convert.ToString(row["DepositClient"]);
                    obj.WithdrawClient = Convert.ToString(row["WithdrawClient"]);
                    obj.BankName = Convert.ToString(row["BankName"]);
                    obj.InterestClient = Convert.ToString(row["InterestClient"]);
                    obj.VoucherNo = Convert.ToString(row["VoucherNo"]);
                    obj.DepositPeriod = Convert.ToString(row["DepositPeriod"]);
                    dbContainer.IndividualSaving.Add(obj);
                }
                dbContainer.SaveChanges();

                foreach (DataRow row in SubjectItem.Rows)
                {
                    if (row["TchRoutineID"] is DBNull)
                        continue;
                    SubjectItem obj = dbContainer.SubjectItem.Create();      
                    obj.TchRoutineID = templateTeachingRoutineMapper[Convert.ToString(row["TchRoutineID"])].Row_ID;
                    TeachingNode refTeachingNode = templateTeachingNodeMapper[Convert.ToString(row["TchNodeID"])];
                    obj.TchNodeID = refTeachingNode.Row_ID;
                    obj.RoutineDesc = groupMapper[obj.TchRoutineID + "-" + templateNodeDict[refTeachingNode.TmpNodeID].GroupIdx].RoutineDesc;
                    obj.SubjectName = Convert.ToString(row["SubjectName"]);
                    obj.SubjectOrient = Convert.ToString(row["SubjectOrient"]);
                    obj.SubjectType = Convert.ToString(row["SubjectType"]);
                    obj.ChangeOrient = Convert.ToString(row["ChangeOrient"]);
                    obj.SubSubject = Convert.ToString(row["SubSubject"]);
                    obj.NextLedger = Convert.ToString(row["NextLedger"]);                    
                    obj.SubjectOrient = Convert.ToString(row["SubjectOrient"]);
                    obj.SubjectName = Convert.ToString(row["SubjectName"]);
                    obj.SubjectOrient = Convert.ToString(row["SubjectOrient"]);
                    obj.Amount = row["Amount"] is DBNull ? 0 : Convert.ToDecimal(row["Amount"]);
                    dbContainer.SubjectItem.Add(obj);
                }
                dbContainer.SaveChanges();

                foreach (DataRow row in OuterSubject.Rows)
                {
                    if (row["TchRoutineID"] is DBNull)
                        continue;
                    OuterSubject obj = dbContainer.OuterSubject.Create();
                    obj.TchRoutineID = templateTeachingRoutineMapper[Convert.ToString(row["TchRoutineID"])].Row_ID;
                    TeachingNode refTeachingNode = templateTeachingNodeMapper[Convert.ToString(row["TchNodeID"])];
                    obj.TchNodeID = refTeachingNode.Row_ID;
                    obj.RoutineDesc = groupMapper[obj.TchRoutineID + "-" + templateNodeDict[refTeachingNode.TmpNodeID].GroupIdx].RoutineDesc;
                    obj.BankName = Convert.ToString(row["BankName"]);
                    obj.Abstract = Convert.ToString(row["Abstract"]);
                    obj.ClientAcc = Convert.ToString(row["ClientAcc"]);
                    obj.SubjectName = Convert.ToString(row["SubjectName"]);
                    obj.MoneyAmount = row["MoneyAmount"] is DBNull ? 0 : Convert.ToDecimal(row["MoneyAmount"]);
                    obj.TimeMark = Convert.ToDateTime(row["TimeMark"]);
                    
                    dbContainer.OuterSubject.Add(obj);
                }
                dbContainer.SaveChanges();

                foreach (DataRow row in CashJournal.Rows)
                {
                    if (row["TchRoutineID"] is DBNull)
                        continue;
                    CashJournal obj = dbContainer.CashJournal.Create();
                    obj.TchRoutineID = templateTeachingRoutineMapper[Convert.ToString(row["TchRoutineID"])].Row_ID;
                    TeachingNode refTeachingNode = templateTeachingNodeMapper[Convert.ToString(row["TchNodeID"])];                   
                    obj.TchNodeID = refTeachingNode.Row_ID;
                    obj.RoutineDesc = groupMapper[obj.TchRoutineID + "-" + templateNodeDict[refTeachingNode.TmpNodeID].GroupIdx].RoutineDesc;
                    obj.BankName = Convert.ToString(row["BankName"]);
                    obj.CashOrient = Convert.ToString(row["CashOrient"]);
                    obj.ClientAcc = Convert.ToString(row["ClientAcc"]);
                    obj.CounterSubject = Convert.ToString(row["CounterSubject"]);
                    obj.MoneyAmount = row["MoneyAmount"] is DBNull ? 0 : Convert.ToDecimal(row["MoneyAmount"]);
                    obj.TimeMark = Convert.ToDateTime(row["TimeMark"]);
                    obj.VoucherNo = Convert.ToString(row["VoucherNo"]);

                    dbContainer.CashJournal.Add(obj);
                }
                dbContainer.SaveChanges();

                foreach (DataRow row in DetailedLedger.Rows)
                {
                    if (row["TchRoutineID"] is DBNull)
                        continue;
                    DetailedLedger obj = dbContainer.DetailedLedger.Create();
                    obj.TchRoutineID = templateTeachingRoutineMapper[Convert.ToString(row["TchRoutineID"])].Row_ID;
                    TeachingNode refTeachingNode = templateTeachingNodeMapper[Convert.ToString(row["TchNodeID"])];
                    obj.TchNodeID = refTeachingNode.Row_ID;
                    obj.RoutineDesc = groupMapper[obj.TchRoutineID + "-" + templateNodeDict[refTeachingNode.TmpNodeID].GroupIdx].RoutineDesc;
                    obj.BankName = Convert.ToString(row["BankName"]);
                    obj.BalanceAbstract = Convert.ToString(row["BalanceAbstract"]);
                    obj.Abstract = Convert.ToString(row["Abstract"]);
                    obj.SubjectName = Convert.ToString(row["SubjectName"]);
                    obj.DebitSum = row["DebitSum"] is DBNull ? 0 : Convert.ToDecimal(row["DebitSum"]);
                    obj.CreditSum = row["CreditSum"] is DBNull ? 0 : Convert.ToDecimal(row["CreditSum"]);
                    obj.BalanceSum = row["BalanceSum"] is DBNull ? 0 : Convert.ToDecimal(row["BalanceSum"]);
                    obj.FinalSum = row["FinalSum"] is DBNull ? 0 : Convert.ToDecimal(row["FinalSum"]);
                    obj.TimeMark = Convert.ToDateTime(row["TimeMark"]);
                    obj.BalanceOrient = Convert.ToInt16(row["BalanceOrient"]);

                    dbContainer.DetailedLedger.Add(obj);
                }
                dbContainer.SaveChanges();

                foreach (DataRow row in CustomerLedger.Rows)
                {
                    if (row["TchRoutineID"] is DBNull)
                        continue;
                    CustomerLedger obj = dbContainer.CustomerLedger.Create();
                    obj.TchRoutineID = templateTeachingRoutineMapper[Convert.ToString(row["TchRoutineID"])].Row_ID;
                    TeachingNode refTeachingNode = templateTeachingNodeMapper[Convert.ToString(row["TchNodeID"])];
                    obj.TchNodeID = refTeachingNode.Row_ID;
                    obj.RoutineDesc = groupMapper[obj.TchRoutineID + "-" + templateNodeDict[refTeachingNode.TmpNodeID].GroupIdx].RoutineDesc;
                    obj.BankName = Convert.ToString(row["BankName"]);
                    obj.BalanceAbstract = Convert.ToString(row["BalanceAbstract"]);
                    obj.Abstract = Convert.ToString(row["Abstract"]);
                    obj.SubjectName = Convert.ToString(row["SubjectName"]);
                    obj.DebitSum = row["DebitSum"] is DBNull ? 0 : Convert.ToDecimal(row["DebitSum"]);
                    obj.CreditSum = row["CreditSum"] is DBNull ? 0 : Convert.ToDecimal(row["CreditSum"]);
                    obj.BalanceSum = row["BalanceSum"] is DBNull ? 0 : Convert.ToDecimal(row["BalanceSum"]);
                    obj.FinalSum = row["FinalSum"] is DBNull ? 0 : Convert.ToDecimal(row["FinalSum"]);
                    obj.TimeMark = Convert.ToDateTime(row["TimeMark"]);
                    obj.BalanceTime = Convert.ToDateTime(row["BalanceTime"]);
                    obj.DCChoice = Convert.ToString(row["DCChoice"]);
                    obj.TargetSubject = Convert.ToString(row["TargetSubject"]);
                    obj.CustomerAccNo = Convert.ToString(row["CustomerAccNo"]);
                    obj.CustomerName = Convert.ToString(row["CustomerName"]);
                    obj.VoucherNo = Convert.ToString(row["VoucherNo"]);
                    dbContainer.CustomerLedger.Add(obj);
                }
                dbContainer.SaveChanges();

                foreach (DataRow row in GeneralLedger.Rows)
                {
                    if (row["TchRoutineID"] is DBNull)
                        continue;
                    GeneralLedger obj = dbContainer.GeneralLedger.Create();
                    obj.TchRoutineID = templateTeachingRoutineMapper[Convert.ToString(row["TchRoutineID"])].Row_ID;
                    TeachingNode refTeachingNode = templateTeachingNodeMapper[Convert.ToString(row["TchNodeID"])];
                    obj.TchNodeID = refTeachingNode.Row_ID;
                    obj.RoutineDesc = groupMapper[obj.TchRoutineID + "-" + templateNodeDict[refTeachingNode.TmpNodeID].GroupIdx].RoutineDesc;
                    obj.BankName = Convert.ToString(row["BankName"]);
                    obj.BalanceAbstract = Convert.ToString(row["BalanceAbstract"]);
                    obj.Abstract = Convert.ToString(row["Abstract"]);
                    obj.SubjectName = Convert.ToString(row["SubjectName"]);
                    obj.DebitSum = row["DebitSum"] is DBNull ? 0 : Convert.ToDecimal(row["DebitSum"]);
                    obj.CreditSum = row["CreditSum"] is DBNull ? 0 : Convert.ToDecimal(row["CreditSum"]);
                    obj.BalanceSum = row["BalanceSum"] is DBNull ? 0 : Convert.ToDecimal(row["BalanceSum"]);
                    obj.FinalSum = row["FinalSum"] is DBNull ? 0 : Convert.ToDecimal(row["FinalSum"]);
                    obj.TimeMark = Convert.ToDateTime(row["TimeMark"]);
                    obj.BalanceOrient = Convert.ToInt16(row["BalanceOrient"]);
                    dbContainer.GeneralLedger.Add(obj);
                }
                dbContainer.SaveChanges();
            }

            return new JsonResult() { Data = string.Empty };
        }
    }
}
