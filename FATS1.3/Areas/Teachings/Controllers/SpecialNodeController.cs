﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Reflection;

using FATS.Models;
using FATS.DataDefine;
using FATS.BusinessObject;
using FATS.Areas.Teachings.Models;


namespace FATS.Areas.Teachings.Controllers
{
    public class SpecialNodeController : Controller
    {
        //
        // GET: /Settings/Special/

        public ActionResult Index()
        {
            return View();
        }

        #region transfer check

        public ActionResult DebitTransferCheck()
        {
            using (FATContainer dataContainer = new FATContainer())
            {
                int tchRoutineID = dataContainer.TeachingNode.Find(Convert.ToInt32(RouteData.Values["id"])).RoutineID;
                TeachingRoutine routine = SharedCasePool.GetCasePool().GetRoutine(tchRoutineID);
                TeachingNode node = routine.NodeList[Convert.ToInt32(RouteData.Values["id"])];
                TransferCheck tcInfo = dataContainer.TransferCheck.FirstOrDefault(info => (info.TchRoutineID == node.RoutineID));
                ViewData[ConstDefine.ViewData_CaseText] = SharedCasePool.GetCasePool().GetRoutine(node.RoutineID).GroupList[node.GroupIdx].GroupText;
                ViewBag.RoutineName = routine.RelTmpRoutine.RoutineName;
                ViewBag.NodeName = node.RelTmpNode.NodeName;
                ViewBag.TchNodeID = node.Row_ID;
                
                return View(tcInfo);
            }
        }

        #endregion

        #region bank draft

        public ActionResult BankDraft()
        {
            using (FATContainer dataContainer = new FATContainer())
            {
                int tchRoutineID = dataContainer.TeachingNode.Find(Convert.ToInt32(RouteData.Values["id"])).RoutineID;
                TeachingRoutine routine = SharedCasePool.GetCasePool().GetRoutine(tchRoutineID);
                TeachingNode node = routine.NodeList[Convert.ToInt32(RouteData.Values["id"])];
                BankDraft tcInfo = dataContainer.BankDraft.FirstOrDefault(info => (info.TchRoutineID == node.RoutineID));
                ViewData[ConstDefine.ViewData_CaseText] = SharedCasePool.GetCasePool().GetRoutine(node.RoutineID).GroupList[node.GroupIdx].GroupText;
                ViewBag.RoutineName = routine.RelTmpRoutine.RoutineName;
                ViewBag.NodeName = node.RelTmpNode.NodeName;
                ViewBag.TchNodeID = node.Row_ID;
                return View("BankDraft_" + node.Index, tcInfo);
            }
        }

        #endregion

        #region BankAcceptBill

        public ActionResult BankAcceptBill()
        {
            using (FATContainer dataContainer = new FATContainer())
            {
                int tchRoutineID = dataContainer.TeachingNode.Find(Convert.ToInt32(RouteData.Values["id"])).RoutineID;
                TeachingRoutine routine = SharedCasePool.GetCasePool().GetRoutine(tchRoutineID);
                TeachingNode node = routine.NodeList[Convert.ToInt32(RouteData.Values["id"])];
                BankAcceptBill tcInfo = dataContainer.BankAcceptBill.FirstOrDefault(info => (info.TchRoutineID == node.RoutineID));
                ViewData[ConstDefine.ViewData_CaseText] = SharedCasePool.GetCasePool().GetRoutine(node.RoutineID).GroupList[node.GroupIdx].GroupText;
                ViewBag.RoutineName = routine.RelTmpRoutine.RoutineName;
                ViewBag.NodeName = node.RelTmpNode.NodeName;
                ViewBag.TchNodeID = node.Row_ID;

                return View("BankAcceptBill_" + node.Index, tcInfo);
            }
        }

        #endregion

        #region MoneyRemittance

        public ActionResult MoneyRemittance()
        {
            using (FATContainer dataContainer = new FATContainer())
            {
                int tchRoutineID = dataContainer.TeachingNode.Find(Convert.ToInt32(RouteData.Values["id"])).RoutineID;
                TeachingRoutine routine = SharedCasePool.GetCasePool().GetRoutine(tchRoutineID);
                TeachingNode node = routine.NodeList[Convert.ToInt32(RouteData.Values["id"])];
                MoneyRemittance tcInfo = dataContainer.MoneyRemittance.FirstOrDefault(info => (info.TchRoutineID == node.RoutineID));
                ViewData[ConstDefine.ViewData_CaseText] = SharedCasePool.GetCasePool().GetRoutine(node.RoutineID).GroupList[node.GroupIdx].GroupText;
                ViewBag.RoutineName = routine.RelTmpRoutine.RoutineName;
                ViewBag.NodeName = node.RelTmpNode.NodeName;
                ViewBag.TchNodeID = node.Row_ID;

                return View("MoneyRemittance_" + node.Index, tcInfo);
            }
        }

        #endregion

        #region CollectAccept

        public ActionResult CollectAccept()
        {
            using (FATContainer dataContainer = new FATContainer())
            {
                int tchRoutineID = dataContainer.TeachingNode.Find(Convert.ToInt32(RouteData.Values["id"])).RoutineID;
                TeachingRoutine routine = SharedCasePool.GetCasePool().GetRoutine(tchRoutineID);
                TeachingNode node = routine.NodeList[Convert.ToInt32(RouteData.Values["id"])];
                CollectAccept tcInfo = dataContainer.CollectAccept.FirstOrDefault(info => (info.TchRoutineID == node.RoutineID));
                ViewData[ConstDefine.ViewData_CaseText] = SharedCasePool.GetCasePool().GetRoutine(node.RoutineID).GroupList[node.GroupIdx].GroupText;
                ViewBag.RoutineName = routine.RelTmpRoutine.RoutineName;
                ViewBag.NodeName = node.RelTmpNode.NodeName;
                ViewBag.TchNodeID = node.Row_ID;

                return View("CollectAccept_" + node.Index, tcInfo);
            }
        }

        #endregion

        #region EntrustCorpPayment

        public ActionResult EntrustCorpPayment()
        {
            using (FATContainer dataContainer = new FATContainer())
            {
                int tchRoutineID = dataContainer.TeachingNode.Find(Convert.ToInt32(RouteData.Values["id"])).RoutineID;
                TeachingRoutine routine = SharedCasePool.GetCasePool().GetRoutine(tchRoutineID);
                TeachingNode node = routine.NodeList[Convert.ToInt32(RouteData.Values["id"])];
                EntrustCorpPayment tcInfo = dataContainer.EntrustCorpPayment.FirstOrDefault(info => (info.TchRoutineID == node.RoutineID));
                ViewData[ConstDefine.ViewData_CaseText] = SharedCasePool.GetCasePool().GetRoutine(node.RoutineID).GroupList[node.GroupIdx].GroupText;
                ViewBag.RoutineName = routine.RelTmpRoutine.RoutineName;
                ViewBag.NodeName = node.RelTmpNode.NodeName;
                ViewBag.TchNodeID = node.Row_ID;

                return View("EntrustCorpPayment_" + node.Index, tcInfo);
            }
        }

        #endregion

        #region EntrustBankPayment

        public ActionResult EntrustBankPayment()
        {
            using (FATContainer dataContainer = new FATContainer())
            {
                int tchRoutineID = dataContainer.TeachingNode.Find(Convert.ToInt32(RouteData.Values["id"])).RoutineID;
                TeachingRoutine routine = SharedCasePool.GetCasePool().GetRoutine(tchRoutineID);
                TeachingNode node = routine.NodeList[Convert.ToInt32(RouteData.Values["id"])];
                EntrustBankPayment tcInfo = dataContainer.EntrustBankPayment.FirstOrDefault(info => (info.TchRoutineID == node.RoutineID));
                ViewData[ConstDefine.ViewData_CaseText] = SharedCasePool.GetCasePool().GetRoutine(node.RoutineID).GroupList[node.GroupIdx].GroupText;
                ViewBag.RoutineName = routine.RelTmpRoutine.RoutineName;
                ViewBag.NodeName = node.RelTmpNode.NodeName;
                ViewBag.TchNodeID = node.Row_ID;

                return View("EntrustBankPayment_" + node.Index, tcInfo);
            }
        }

        #endregion

        #region Individual Saving

        public ActionResult IndividualDeposit()
        {
            using (FATContainer dataContainer = new FATContainer())
            {
                int tchRoutineID = dataContainer.TeachingNode.Find(Convert.ToInt32(RouteData.Values["id"])).RoutineID;
                TeachingRoutine routine = SharedCasePool.GetCasePool().GetRoutine(tchRoutineID);
                TeachingNode node = routine.NodeList[Convert.ToInt32(RouteData.Values["id"])];
                IndividualSaving targetObj = dataContainer.IndividualSaving.FirstOrDefault(info => (info.TchRoutineID == node.RoutineID));
                ViewData[ConstDefine.ViewData_CaseText] = SharedCasePool.GetCasePool().GetRoutine(node.RoutineID).GroupList[node.GroupIdx].GroupText;
                ViewBag.RoutineName = routine.RelTmpRoutine.RoutineName;
                ViewBag.NodeName = node.RelTmpNode.NodeName;
                ViewBag.TchNodeID = node.Row_ID;
                ViewBag.TchRoutineID = routine.Row_ID;
                                
                Type type = Type.GetType("FATS.BusinessObject.Converters.IndividualDepositConverter");
                MethodInfo method = type.GetMethod(routine.RelTmpRoutine.RoutineTag, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);

                V_IndividualDeposit modalInfo = (V_IndividualDeposit)method.Invoke(null, new Object[] { targetObj });
    
                return View("IndividualSaving_Deposit", modalInfo);
            }
        }

        public ActionResult IndividualWithdraw()
        {
            using (FATContainer dataContainer = new FATContainer())
            {
                int tchRoutineID = dataContainer.TeachingNode.Find(Convert.ToInt32(RouteData.Values["id"])).RoutineID;
                TeachingRoutine routine = SharedCasePool.GetCasePool().GetRoutine(tchRoutineID);
                TeachingNode node = routine.NodeList[Convert.ToInt32(RouteData.Values["id"])];
                IndividualSaving targetObj = dataContainer.IndividualSaving.FirstOrDefault(info => (info.TchRoutineID == node.RoutineID));
                ViewData[ConstDefine.ViewData_CaseText] = SharedCasePool.GetCasePool().GetRoutine(node.RoutineID).GroupList[node.GroupIdx].GroupText;
                ViewBag.RoutineName = routine.RelTmpRoutine.RoutineName;
                ViewBag.NodeName = node.RelTmpNode.NodeName;
                ViewBag.TchNodeID = node.Row_ID;
                ViewBag.TchRoutineID = routine.Row_ID;

                Type type = Type.GetType("FATS.BusinessObject.Converters.IndividualWithdrawConverter");
                MethodInfo method = type.GetMethod(routine.RelTmpRoutine.RoutineTag, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);

                V_IndividualWithdraw modalInfo = (V_IndividualWithdraw)method.Invoke(null, new Object[] { targetObj });
               
                return View("IndividualSaving_Withdraw", modalInfo);
            }
        }

        public ActionResult InterestVoucher()
        {
            using (FATContainer dataContainer = new FATContainer())
            {
                int tchRoutineID = dataContainer.TeachingNode.Find(Convert.ToInt32(RouteData.Values["id"])).RoutineID;
                TeachingRoutine routine = SharedCasePool.GetCasePool().GetRoutine(tchRoutineID);
                TeachingNode node = routine.NodeList[Convert.ToInt32(RouteData.Values["id"])];
                IndividualSaving targetObj = dataContainer.IndividualSaving.FirstOrDefault(info => (info.TchRoutineID == node.RoutineID));
                ViewData[ConstDefine.ViewData_CaseText] = SharedCasePool.GetCasePool().GetRoutine(node.RoutineID).GroupList[node.GroupIdx].GroupText;
                ViewBag.RoutineName = routine.RelTmpRoutine.RoutineName;
                ViewBag.NodeName = node.RelTmpNode.NodeName;
                ViewBag.TchNodeID = node.Row_ID;
                ViewBag.TchRoutineID = routine.Row_ID;

                Type type = Type.GetType("FATS.BusinessObject.Converters.InterestVoucherConverter");
                MethodInfo method = type.GetMethod(routine.RelTmpRoutine.RoutineTag, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);

                V_InterestVoucher modalInfo = (V_InterestVoucher)method.Invoke(null, new Object[] { targetObj });

                return View("IndividualSaving_Interest", modalInfo);
            }
        }

        #endregion

        #region Unit Saving
        public ActionResult UnitDynDeposit()
        {
            return UnitSaving();
        }

        public ActionResult UnitDynWithdraw()
        {
            return UnitSaving();
        }

        public ActionResult UnitDynInterest()
        {
            return UnitSaving();
        }

        public ActionResult UnitFixedDeposit()
        {
            return UnitSaving();
        }

        public ActionResult UnitFixedInterest()
        {
            return UnitSaving();
        }

        public ActionResult UnitFixedWithdraw()
        {
            return UnitSaving();
        }

        private ActionResult UnitSaving()
        {            
            using (FATContainer dataContainer = new FATContainer())
            {
                int tchRoutineID = dataContainer.TeachingNode.Find(Convert.ToInt32(RouteData.Values["id"])).RoutineID;
                TeachingRoutine routine = SharedCasePool.GetCasePool().GetRoutine(tchRoutineID);
                TeachingNode node = routine.NodeList[Convert.ToInt32(RouteData.Values["id"])];
                UnitSaving tcInfo = dataContainer.UnitSaving.FirstOrDefault(info => (info.TchRoutineID == node.RoutineID));
                ViewData[ConstDefine.ViewData_CaseText] = SharedCasePool.GetCasePool().GetRoutine(node.RoutineID).GroupList[node.GroupIdx].GroupText;
                ViewBag.RoutineName = routine.RelTmpRoutine.RoutineName;
                ViewBag.NodeName = node.RelTmpNode.NodeName;
                ViewBag.TchNodeID = node.Row_ID;

                return View(node.RelTmpNode.Tag, tcInfo);
            }
        }

        #endregion

        #region Loan
        public ActionResult MortgageLoanGrant()
        {
            using (FATContainer dataContainer = new FATContainer())
            {
                int tchRoutineID = dataContainer.TeachingNode.Find(Convert.ToInt32(RouteData.Values["id"])).RoutineID;
                TeachingRoutine routine = SharedCasePool.GetCasePool().GetRoutine(tchRoutineID);
                TeachingNode node = routine.NodeList[Convert.ToInt32(RouteData.Values["id"])];
                Loan tcInfo = dataContainer.Loan.FirstOrDefault(info => (info.TchRoutineID == node.RoutineID));
                ViewData[ConstDefine.ViewData_CaseText] = SharedCasePool.GetCasePool().GetRoutine(node.RoutineID).GroupList[node.GroupIdx].GroupText;
                ViewBag.RoutineName = routine.RelTmpRoutine.RoutineName;
                ViewBag.NodeName = node.RelTmpNode.NodeName;
                ViewBag.TchNodeID = node.Row_ID;

                return View(node.RelTmpNode.Tag + "_" + node.RelTmpNode.NodeIndex, tcInfo);
            }
        }

        public ActionResult MortgageLoanRevoke()
        {
            using (FATContainer dataContainer = new FATContainer())
            {
                int tchRoutineID = dataContainer.TeachingNode.Find(Convert.ToInt32(RouteData.Values["id"])).RoutineID;
                TeachingRoutine routine = SharedCasePool.GetCasePool().GetRoutine(tchRoutineID);
                TeachingNode node = routine.NodeList[Convert.ToInt32(RouteData.Values["id"])];
                Loan tcInfo = dataContainer.Loan.FirstOrDefault(info => (info.TchRoutineID == node.RoutineID));
                ViewData[ConstDefine.ViewData_CaseText] = SharedCasePool.GetCasePool().GetRoutine(node.RoutineID).GroupList[node.GroupIdx].GroupText;
                ViewBag.RoutineName = routine.RelTmpRoutine.RoutineName;
                ViewBag.NodeName = node.RelTmpNode.NodeName;
                ViewBag.TchNodeID = node.Row_ID;

                return View(node.RelTmpNode.Tag + "_" + node.RelTmpNode.NodeIndex, tcInfo);
            }
        }

        public ActionResult CreditLoanGrant()
        {
            using (FATContainer dataContainer = new FATContainer())
            {
                int tchRoutineID = dataContainer.TeachingNode.Find(Convert.ToInt32(RouteData.Values["id"])).RoutineID;
                TeachingRoutine routine = SharedCasePool.GetCasePool().GetRoutine(tchRoutineID);
                TeachingNode node = routine.NodeList[Convert.ToInt32(RouteData.Values["id"])];
                Loan tcInfo = dataContainer.Loan.FirstOrDefault(info => (info.TchRoutineID == node.RoutineID));
                ViewData[ConstDefine.ViewData_CaseText] = SharedCasePool.GetCasePool().GetRoutine(node.RoutineID).GroupList[node.GroupIdx].GroupText;
                ViewBag.RoutineName = routine.RelTmpRoutine.RoutineName;
                ViewBag.NodeName = node.RelTmpNode.NodeName;
                ViewBag.TchNodeID = node.Row_ID;

                return View(node.RelTmpNode.Tag, tcInfo);
            }
        }

        public ActionResult CreditLoanRevoke()
        {
            using (FATContainer dataContainer = new FATContainer())
            {
                int tchRoutineID = dataContainer.TeachingNode.Find(Convert.ToInt32(RouteData.Values["id"])).RoutineID;
                TeachingRoutine routine = SharedCasePool.GetCasePool().GetRoutine(tchRoutineID);
                TeachingNode node = routine.NodeList[Convert.ToInt32(RouteData.Values["id"])];
                Loan tcInfo = dataContainer.Loan.FirstOrDefault(info => (info.TchRoutineID == node.RoutineID));
                ViewData[ConstDefine.ViewData_CaseText] = SharedCasePool.GetCasePool().GetRoutine(node.RoutineID).GroupList[node.GroupIdx].GroupText;
                ViewBag.RoutineName = routine.RelTmpRoutine.RoutineName;
                ViewBag.NodeName = node.RelTmpNode.NodeName;
                ViewBag.TchNodeID = node.Row_ID;

                return View(node.RelTmpNode.Tag, tcInfo);
            }
        }

        #endregion


        #region Discounting
        public ActionResult DiscountingGrant()
        {
            using (FATContainer dataContainer = new FATContainer())
            {
                int tchRoutineID = dataContainer.TeachingNode.Find(Convert.ToInt32(RouteData.Values["id"])).RoutineID;
                TeachingRoutine routine = SharedCasePool.GetCasePool().GetRoutine(tchRoutineID);
                TeachingNode node = routine.NodeList[Convert.ToInt32(RouteData.Values["id"])];
                Discounting tcInfo = dataContainer.Discounting.FirstOrDefault(info => (info.TchRoutineID == node.RoutineID));
                ViewData[ConstDefine.ViewData_CaseText] = SharedCasePool.GetCasePool().GetRoutine(node.RoutineID).GroupList[node.GroupIdx].GroupText;
                ViewBag.RoutineName = routine.RelTmpRoutine.RoutineName;
                ViewBag.NodeName = node.RelTmpNode.NodeName;
                ViewBag.TchNodeID = node.Row_ID;

                return View(node.RelTmpNode.Tag, tcInfo);
            }
        }

        public ActionResult DiscountingRevoke()
        {
            using (FATContainer dataContainer = new FATContainer())
            {
                int tchRoutineID = dataContainer.TeachingNode.Find(Convert.ToInt32(RouteData.Values["id"])).RoutineID;
                TeachingRoutine routine = SharedCasePool.GetCasePool().GetRoutine(tchRoutineID);
                TeachingNode node = routine.NodeList[Convert.ToInt32(RouteData.Values["id"])];
                Discounting tcInfo = dataContainer.Discounting.FirstOrDefault(info => (info.TchRoutineID == node.RoutineID));
                ViewData[ConstDefine.ViewData_CaseText] = SharedCasePool.GetCasePool().GetRoutine(node.RoutineID).GroupList[node.GroupIdx].GroupText;
                ViewBag.RoutineName = routine.RelTmpRoutine.RoutineName;
                ViewBag.NodeName = node.RelTmpNode.NodeName;
                ViewBag.TchNodeID = node.Row_ID;

                return View(node.RelTmpNode.Tag, tcInfo);
            }
        }

        #endregion

    }
}
