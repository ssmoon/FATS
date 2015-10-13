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

        public ActionResult DoImport_IndividualSaving()
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

        public ActionResult DoImport_PaySettle()
        {
            var connectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0}; Extended Properties=Excel 12.0;", Server.MapPath("~/App_Data/paysettle.xls"));

            var adapter1 = new OleDbDataAdapter("SELECT * FROM [主流程$]", connectionString);
            var adapter2 = new OleDbDataAdapter("SELECT * FROM [案例分组$]", connectionString);
            var adapter3 = new OleDbDataAdapter("SELECT * FROM [详细流程$]", connectionString);
            var adapter4 = new OleDbDataAdapter("SELECT * FROM [科目$]", connectionString);
            var adapter5 = new OleDbDataAdapter("SELECT * FROM [现金账$]", connectionString);
            var adapter6 = new OleDbDataAdapter("SELECT * FROM [明细账$]", connectionString);
            var adapter7 = new OleDbDataAdapter("SELECT * FROM [分户账$]", connectionString);
            var adapter8 = new OleDbDataAdapter("SELECT * FROM [总账$]", connectionString);
            var adapter9 = new OleDbDataAdapter("SELECT * FROM [表外科目$]", connectionString);

            var adapter12 = new OleDbDataAdapter("SELECT * FROM [银行汇票$]", connectionString);
            var adapter13 = new OleDbDataAdapter("SELECT * FROM [银行承兑汇票$]", connectionString);
            var adapter14 = new OleDbDataAdapter("SELECT * FROM [汇兑$]", connectionString);
            var adapter15 = new OleDbDataAdapter("SELECT * FROM [托收承付$]", connectionString);
            var adapter16 = new OleDbDataAdapter("SELECT * FROM [委托收款$]", connectionString);
            var adapter17 = new OleDbDataAdapter("SELECT * FROM [委托收款-银行$]", connectionString);

         //   var adapter11 = new OleDbDataAdapter("SELECT * FROM [IndividualSaving$]", connectionString);
            var ds = new DataSet();

            adapter1.Fill(ds, "TeachingRoutine");
            adapter2.Fill(ds, "RoutineGroup");
            adapter3.Fill(ds, "TemplateNode");            
            adapter4.Fill(ds, "SubjectItem");
            adapter5.Fill(ds, "CashJournal");
            adapter6.Fill(ds, "DetailedLedger");
            adapter7.Fill(ds, "CustomerLedger");
            adapter8.Fill(ds, "GeneralLedger");
            adapter9.Fill(ds, "OuterSubject");

            adapter12.Fill(ds, "BankDraft");
            adapter13.Fill(ds, "BankAcceptBill");
            adapter14.Fill(ds, "MoneyRemittance");
            adapter15.Fill(ds, "CollectAccept");
            adapter16.Fill(ds, "EntrustCorpPayment");
            adapter17.Fill(ds, "EntrustBankPayment");

            DataTable TeachingRoutine = ds.Tables["TeachingRoutine"];
            DataTable RoutineGroup = ds.Tables["RoutineGroup"];
            DataTable TemplateNode = ds.Tables["TemplateNode"];            
            DataTable SubjectItem = ds.Tables["SubjectItem"];
            DataTable CashJournal = ds.Tables["CashJournal"];
            DataTable DetailedLedger = ds.Tables["DetailedLedger"];
            DataTable CustomerLedger = ds.Tables["CustomerLedger"];
            DataTable GeneralLedger = ds.Tables["GeneralLedger"];
            DataTable OuterSubject = ds.Tables["OuterSubject"];

            DataTable dtBankDraft = ds.Tables["BankDraft"];
            DataTable dtBankAcceptBill = ds.Tables["BankAcceptBill"];
            DataTable dtMoneyRemittance = ds.Tables["MoneyRemittance"];
            DataTable dtCollectAccept = ds.Tables["CollectAccept"];
            DataTable dtEntrustCorpPayment = ds.Tables["EntrustCorpPayment"];
            DataTable dtEntrustBankPayment = ds.Tables["EntrustBankPayment"];


            using (FATContainer dbContainer = new FATContainer())
            {
                dbContainer.Database.ExecuteSqlCommand("exec DelTestRoutine @ids", new SqlParameter("@ids", "('2', '3', '4', '5', '6', '7')"));

                List<TemplateRoutine> tmpRoutineList = new List<TemplateRoutine>();
                foreach (DataRow row in TeachingRoutine.Rows)
                {
                    if (row["编号"] is DBNull)
                        continue;
                    TemplateRoutine routine = dbContainer.TemplateRoutine.Create();
                    routine.Row_ID = Convert.ToString(row["编号"]);
                    routine.RoutineName = Convert.ToString(row["流程名称"]);
                    routine.RoutineDesc = "";
                    routine.RoutineType = 1;
                    routine.RoutineTag = Convert.ToString(row["RoutineTag"]);
                    tmpRoutineList.Add(routine);

                    dbContainer.TemplateRoutine.Add(routine);
                }
                dbContainer.SaveChanges();

                List<TemplateNode> tmpNodeList = new List<TemplateNode>();
                foreach (DataRow row in TemplateNode.Rows)
                {
                    if (row["步骤编号"] is DBNull)
                        continue;
                    TemplateNode node = dbContainer.TemplateNode.Create();
                    node.Row_ID = Convert.ToString(row["步骤编号"]);
                    node.RoutineID = Convert.ToString(row["流程"]);
                    node.NodeIndex = Convert.ToInt32(row["顺序号"]);
                    node.NodeName = Convert.ToString(row["步骤名称"]);
                    node.GroupIdx = Convert.ToInt32(row["分组号"]);
                    node.RequireRecord = Convert.ToInt32(row["分录数量"]);
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
                    if (row["流程"] is DBNull)
                        continue;
                    RoutineGroup obj = dbContainer.RoutineGroup.Create();
                    obj.GroupText = Convert.ToString(row["案例文字"]);
                    obj.GroupIdx = Convert.ToInt32(row["分组号"]);
                    obj.RoutineIntro = Convert.ToString(row["案例介绍"]);
                    obj.TchRoutineID = templateTeachingRoutineMapper[Convert.ToString(row["流程"])].Row_ID;
                    obj.RoutineDesc = obj.GroupIdx + "." + Convert.ToString(row["分组名称"]);
                    groupList.Add(obj);
                    dbContainer.RoutineGroup.Add(obj);
                }
                try
                {
                    dbContainer.SaveChanges();
                }
                catch (Exception e)
                {
                    throw e;
                }

                Dictionary<string, RoutineGroup> groupMapper = groupList.ToDictionary(n => n.TchRoutineID + "-" + n.GroupIdx);

                foreach (DataRow row in SubjectItem.Rows)
                {
                    if (row["流程"] is DBNull)
                        continue;
                    SubjectItem obj = dbContainer.SubjectItem.Create();
                    obj.TchRoutineID = templateTeachingRoutineMapper[Convert.ToString(row["流程"])].Row_ID;
                    TeachingNode refTeachingNode = templateTeachingNodeMapper[Convert.ToString(row["步骤编号"])];
                    obj.TchNodeID = refTeachingNode.Row_ID;
                    obj.RoutineDesc = groupMapper[obj.TchRoutineID + "-" + templateNodeDict[refTeachingNode.TmpNodeID].GroupIdx].RoutineDesc;
                    obj.SubjectName = Convert.ToString(row["科目"]);
                    obj.SubjectOrient = Convert.ToString(row["方向"]);
                    obj.SubjectType = Convert.ToString(row["类型"]);
                    obj.ChangeOrient = Convert.ToString(row["增减"]);
                    obj.SubSubject = Convert.ToString(row["子科目"]);
                    obj.NextLedger = Convert.ToString(row["下一步"]);
                    obj.Amount = row["金额"] is DBNull ? 0 : Convert.ToDecimal(row["金额"]);
                    dbContainer.SubjectItem.Add(obj);
                }
                dbContainer.SaveChanges();

                foreach (DataRow row in OuterSubject.Rows)
                {
                    if (row["流程"] is DBNull)
                        continue;
                    OuterSubject obj = dbContainer.OuterSubject.Create();
                    obj.TchRoutineID = templateTeachingRoutineMapper[Convert.ToString(row["流程"])].Row_ID;
                    TeachingNode refTeachingNode = templateTeachingNodeMapper[Convert.ToString(row["步骤编号"])];
                    obj.TchNodeID = refTeachingNode.Row_ID;
                    obj.RoutineDesc = groupMapper[obj.TchRoutineID + "-" + templateNodeDict[refTeachingNode.TmpNodeID].GroupIdx].RoutineDesc;
                    obj.BankName = Convert.ToString(row["银行名称"]);
                    obj.Abstract = Convert.ToString(row["摘要"]);
                    obj.ClientAcc = Convert.ToString(row["客户账号"]);
                    obj.SubjectName = Convert.ToString(row["科目"]);
                    obj.MoneyAmount = row["金额"] is DBNull ? 0 : Convert.ToDecimal(row["金额"]);
                    obj.TimeMark = Convert.ToDateTime(row["时间"]);

                    dbContainer.OuterSubject.Add(obj);
                }
                dbContainer.SaveChanges();

                foreach (DataRow row in CashJournal.Rows)
                {
                    if (row["流程"] is DBNull)
                        continue;
                    CashJournal obj = dbContainer.CashJournal.Create();
                    obj.TchRoutineID = templateTeachingRoutineMapper[Convert.ToString(row["流程"])].Row_ID;
                    TeachingNode refTeachingNode = templateTeachingNodeMapper[Convert.ToString(row["步骤编号"])];
                    obj.TchNodeID = refTeachingNode.Row_ID;
                    obj.RoutineDesc = groupMapper[obj.TchRoutineID + "-" + templateNodeDict[refTeachingNode.TmpNodeID].GroupIdx].RoutineDesc;
                    obj.BankName = Convert.ToString(row["银行名称"]);
                    obj.CashOrient = Convert.ToString(row["账簿类型"]);
                    obj.ClientAcc = Convert.ToString(row["客户账号"]);
                    obj.CounterSubject = Convert.ToString(row["对方科目"]);
                    obj.MoneyAmount = row["金额"] is DBNull ? 0 : Convert.ToDecimal(row["金额"]);
                    obj.TimeMark = Convert.ToDateTime(row["时间"]);
                    obj.VoucherNo = Convert.ToString(row["凭证号"]);

                    dbContainer.CashJournal.Add(obj);
                }
                dbContainer.SaveChanges();

                foreach (DataRow row in DetailedLedger.Rows)
                {
                    if (row["流程"] is DBNull)
                        continue;
                    DetailedLedger obj = dbContainer.DetailedLedger.Create();
                    obj.TchRoutineID = templateTeachingRoutineMapper[Convert.ToString(row["流程"])].Row_ID;
                    TeachingNode refTeachingNode = templateTeachingNodeMapper[Convert.ToString(row["步骤编号"])];
                    obj.TchNodeID = refTeachingNode.Row_ID;
                    obj.RoutineDesc = groupMapper[obj.TchRoutineID + "-" + templateNodeDict[refTeachingNode.TmpNodeID].GroupIdx].RoutineDesc;
                    obj.BankName = Convert.ToString(row["银行名称"]);
                    obj.BalanceAbstract = Convert.ToString(row["余额摘要"]);
                    obj.Abstract = Convert.ToString(row["摘要"]);
                    obj.SubjectName = Convert.ToString(row["科目"]);
                    obj.DebitSum = row["借方"] is DBNull ? 0 : Convert.ToDecimal(row["借方"]);
                    obj.CreditSum = row["贷方"] is DBNull ? 0 : Convert.ToDecimal(row["贷方"]);
                    obj.BalanceSum = row["余额"] is DBNull ? 0 : Convert.ToDecimal(row["余额"]);
                    obj.FinalSum = row["最终金额"] is DBNull ? 0 : Convert.ToDecimal(row["最终金额"]);
                    obj.TimeMark = Convert.ToDateTime(row["时间"]);
                    obj.BalanceOrient = Convert.ToInt16(row["余额方向"]);

                    dbContainer.DetailedLedger.Add(obj);
                }
                dbContainer.SaveChanges();

                foreach (DataRow row in CustomerLedger.Rows)
                {
                    if (row["流程"] is DBNull)
                        continue;
                    CustomerLedger obj = dbContainer.CustomerLedger.Create();
                    obj.TchRoutineID = templateTeachingRoutineMapper[Convert.ToString(row["流程"])].Row_ID;
                    TeachingNode refTeachingNode = templateTeachingNodeMapper[Convert.ToString(row["步骤编号"])];
                    obj.TchNodeID = refTeachingNode.Row_ID;
                    obj.RoutineDesc = groupMapper[obj.TchRoutineID + "-" + templateNodeDict[refTeachingNode.TmpNodeID].GroupIdx].RoutineDesc;
                    obj.BankName = Convert.ToString(row["银行名称"]);
                    obj.BalanceAbstract = Convert.ToString(row["余额摘要"]);
                    obj.Abstract = Convert.ToString(row["摘要"]);
                    obj.SubjectName = Convert.ToString(row["科目"]);
                    obj.DebitSum = row["借方"] is DBNull ? 0 : Convert.ToDecimal(row["借方"]);
                    obj.CreditSum = row["贷方"] is DBNull ? 0 : Convert.ToDecimal(row["贷方"]);
                    obj.BalanceSum = row["余额"] is DBNull ? 0 : Convert.ToDecimal(row["余额"]);
                    obj.FinalSum = row["最终金额"] is DBNull ? 0 : Convert.ToDecimal(row["最终金额"]);
                    obj.TimeMark = Convert.ToDateTime(row["时间"]);
                    obj.BalanceTime = Convert.ToDateTime(row["余额时间"]);
                    obj.DCChoice = Convert.ToString(row["借或贷"]);
                    obj.CustomerAccNo = Convert.ToString(row["客户账号"]);
                    obj.CustomerName = Convert.ToString(row["客户名称"]);
                    obj.VoucherNo = Convert.ToString(row["凭证号"]);
                    dbContainer.CustomerLedger.Add(obj);
                }
                dbContainer.SaveChanges();

                foreach (DataRow row in GeneralLedger.Rows)
                {
                    if (row["流程"] is DBNull)
                        continue;
                    GeneralLedger obj = dbContainer.GeneralLedger.Create();
                    obj.TchRoutineID = templateTeachingRoutineMapper[Convert.ToString(row["流程"])].Row_ID;
                    TeachingNode refTeachingNode = templateTeachingNodeMapper[Convert.ToString(row["步骤编号"])];
                    obj.TchNodeID = refTeachingNode.Row_ID;
                    obj.RoutineDesc = groupMapper[obj.TchRoutineID + "-" + templateNodeDict[refTeachingNode.TmpNodeID].GroupIdx].RoutineDesc;
                    obj.BankName = Convert.ToString(row["银行名称"]);
                    obj.BalanceAbstract = Convert.ToString(row["余额摘要"]);
                    obj.Abstract = Convert.ToString(row["摘要"]);
                    obj.SubjectName = Convert.ToString(row["科目"]);
                    obj.DebitSum = row["借方"] is DBNull ? 0 : Convert.ToDecimal(row["借方"]);
                    obj.CreditSum = row["贷方"] is DBNull ? 0 : Convert.ToDecimal(row["贷方"]);
                    obj.BalanceSum = row["余额"] is DBNull ? 0 : Convert.ToDecimal(row["余额"]);
                    obj.FinalSum = row["最终金额"] is DBNull ? 0 : Convert.ToDecimal(row["最终金额"]);
                    obj.TimeMark = Convert.ToDateTime(row["时间"]);
                    obj.BalanceOrient = Convert.ToInt16(row["余额方向"]);
                    dbContainer.GeneralLedger.Add(obj);
                }
                dbContainer.SaveChanges();

                foreach (DataRow row in dtBankDraft.Rows)
                {
                    if (row["流程"] is DBNull)
                        continue;
                    BankDraft obj = dbContainer.BankDraft.Create();
                    obj.TchRoutineID = templateTeachingRoutineMapper[Convert.ToString(row["流程"])].Row_ID;
                    obj.TchRoutineTag = string.Empty;
                    obj.RemitterName = Convert.ToString(row["收款人名称"]);
                    obj.RemitterAcc = Convert.ToString(row["收款人账号"]);
                    obj.RemitterBank = Convert.ToString(row["收款方银行"]);
                    obj.PayeeName = Convert.ToString(row["付款人名称"]);
                    obj.PayeeAcc = Convert.ToString(row["付款人账号"]);
                    obj.PayeeBank = Convert.ToString(row["付款方银行"]);
                    obj.MoneyAmount = row["金额"] is DBNull ? 0 : Convert.ToDecimal(row["金额"]);
                    obj.Purpose = Convert.ToString(row["目的"]);

                    obj.CloseAmount = row["实际结算金额"] is DBNull ? 0 : Convert.ToDecimal(row["实际结算金额"]);
                    obj.DraftDate = Convert.ToDateTime(row["汇票日期"]);
                    obj.IncomeBillDate = Convert.ToDateTime(row["进账单日期"]);
                    obj.DraftBillNo = Convert.ToString(row["汇票号"]);

                    dbContainer.BankDraft.Add(obj);
                }
                dbContainer.SaveChanges();

                foreach (DataRow row in dtBankAcceptBill.Rows)
                {
                    if (row["流程"] is DBNull)
                        continue;
                    BankAcceptBill obj = dbContainer.BankAcceptBill.Create();
                    obj.TchRoutineID = templateTeachingRoutineMapper[Convert.ToString(row["流程"])].Row_ID;
                    obj.TchRoutineTag = string.Empty;
                    obj.RemitterName = Convert.ToString(row["收款人名称"]);
                    obj.RemitterAcc = Convert.ToString(row["收款人账号"]);
                    obj.RemitterBank = Convert.ToString(row["收款方银行"]);
                    obj.PayeeName = Convert.ToString(row["付款人名称"]);
                    obj.PayeeAcc = Convert.ToString(row["付款人账号"]);
                    obj.PayeeBank = Convert.ToString(row["付款方银行"]);
                    obj.MoneyAmount = row["金额"] is DBNull ? 0 : Convert.ToDecimal(row["金额"]);
                    obj.Purpose = Convert.ToString(row["目的"]);

                    obj.BillNo = Convert.ToString(row["商业汇票号"]);                    
                    obj.DrawBillDate = Convert.ToDateTime(row["出票日期"]);
                    obj.IncomeBillDate = Convert.ToDateTime(row["进账单日期"]);

                    dbContainer.BankAcceptBill.Add(obj);
                }
                dbContainer.SaveChanges();

                foreach (DataRow row in dtMoneyRemittance.Rows)
                {
                    if (row["流程"] is DBNull)
                        continue;
                    MoneyRemittance obj = dbContainer.MoneyRemittance.Create();
                    obj.TchRoutineID = templateTeachingRoutineMapper[Convert.ToString(row["流程"])].Row_ID;
                    obj.TchRoutineTag = string.Empty;
                    obj.RemitterName = Convert.ToString(row["收款人名称"]);
                    obj.RemitterAcc = Convert.ToString(row["收款人账号"]);
                    obj.RemitterBank = Convert.ToString(row["收款方银行"]);
                    obj.PayeeName = Convert.ToString(row["付款人名称"]);
                    obj.PayeeAcc = Convert.ToString(row["付款人账号"]);
                    obj.PayeeBank = Convert.ToString(row["付款方银行"]);
                    obj.MoneyAmount = row["金额"] is DBNull ? 0 : Convert.ToDecimal(row["金额"]);
                    obj.Purpose = Convert.ToString(row["目的"]);

                    obj.AffluxDate = Convert.ToDateTime(row["汇入日期"]);
                    obj.RemitDate = Convert.ToDateTime(row["汇出日期"]);
                    obj.SettlementNo = Convert.ToString(row["结算号"]);

                    dbContainer.MoneyRemittance.Add(obj);
                }
                dbContainer.SaveChanges();

                foreach (DataRow row in dtCollectAccept.Rows)
                {
                    if (row["流程"] is DBNull)
                        continue;
                    CollectAccept obj = dbContainer.CollectAccept.Create();
                    obj.TchRoutineID = templateTeachingRoutineMapper[Convert.ToString(row["流程"])].Row_ID;
                    obj.TchRoutineTag = string.Empty;
                    obj.RemitterName = Convert.ToString(row["收款人名称"]);
                    obj.RemitterAcc = Convert.ToString(row["收款人账号"]);
                    obj.RemitterBank = Convert.ToString(row["收款方银行"]);
                    obj.PayeeName = Convert.ToString(row["付款人名称"]);
                    obj.PayeeAcc = Convert.ToString(row["付款人账号"]);
                    obj.PayeeBank = Convert.ToString(row["付款方银行"]);
                    obj.MoneyAmount = row["金额"] is DBNull ? 0 : Convert.ToDecimal(row["金额"]);
                    obj.Purpose = Convert.ToString(row["目的"]);
                                        
                    obj.CollectDate = Convert.ToDateTime(row["托收日期"]);
                    obj.AcceptDate = Convert.ToDateTime(row["承付期满日"]);
                    obj.SettlementNo = Convert.ToString(row["结算号"]);

                    dbContainer.CollectAccept.Add(obj);
                }
                dbContainer.SaveChanges();

                foreach (DataRow row in dtEntrustCorpPayment.Rows)
                {
                    if (row["流程"] is DBNull)
                        continue;
                    EntrustCorpPayment obj = dbContainer.EntrustCorpPayment.Create();
                    obj.TchRoutineID = templateTeachingRoutineMapper[Convert.ToString(row["流程"])].Row_ID;
                    obj.TchRoutineTag = string.Empty;
                    obj.RemitterName = Convert.ToString(row["收款人名称"]);
                    obj.RemitterAcc = Convert.ToString(row["收款人账号"]);
                    obj.RemitterBank = Convert.ToString(row["收款方银行"]);
                    obj.PayeeName = Convert.ToString(row["付款人名称"]);
                    obj.PayeeAcc = Convert.ToString(row["付款人账号"]);
                    obj.PayeeBank = Convert.ToString(row["付款方银行"]);
                    obj.MoneyAmount = row["金额"] is DBNull ? 0 : Convert.ToDecimal(row["金额"]);
                    obj.Purpose = Convert.ToString(row["目的"]);

                    obj.EntrustDate = Convert.ToDateTime(row["委托日期"]);
                    obj.PaymentDate = Convert.ToDateTime(row["付款日期"]);
                    obj.SettlementNo = Convert.ToString(row["结算号"]);

                    dbContainer.EntrustCorpPayment.Add(obj);
                }
                dbContainer.SaveChanges();

                foreach (DataRow row in dtEntrustBankPayment.Rows)
                {
                    if (row["流程"] is DBNull)
                        continue;
                    EntrustBankPayment obj = dbContainer.EntrustBankPayment.Create();
                    obj.TchRoutineID = templateTeachingRoutineMapper[Convert.ToString(row["流程"])].Row_ID;
                    obj.TchRoutineTag = string.Empty;
                    obj.RemitterName = Convert.ToString(row["收款人名称"]);
                    obj.RemitterAcc = Convert.ToString(row["收款人账号"]);
                    obj.RemitterBank = Convert.ToString(row["收款方银行"]);
                    obj.PayeeName = Convert.ToString(row["付款人名称"]);
                    obj.PayeeAcc = string.Empty;
                    obj.PayeeBank = Convert.ToString(row["付款方银行"]);
                    obj.MoneyAmount = row["金额"] is DBNull ? 0 : Convert.ToDecimal(row["金额"]);
                    obj.Purpose = Convert.ToString(row["目的"]);

                    obj.EntrustDate = Convert.ToDateTime(row["委托日期"]);
                    obj.PaymentDate = Convert.ToDateTime(row["付款日期"]);
                    obj.SettlementNo = Convert.ToString(row["结算号"]);

                    dbContainer.EntrustBankPayment.Add(obj);
                }
                dbContainer.SaveChanges();
            }

            return new JsonResult() { Data = string.Empty };
        }
    }
}
