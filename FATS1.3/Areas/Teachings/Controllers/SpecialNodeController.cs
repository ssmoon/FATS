﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
                ViewBag.ResourceFile = node.RelTmpNode.Row_ID;
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
                ViewBag.ResourceFile = "T1_DebitTransferCheck_S12";
                return View("BankDraft_" + node.Index, tcInfo);
            }
        }

        #endregion

        #region bank draft

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
                ViewBag.ResourceFile = node.RelTmpNode.Row_ID;
                return View(tcInfo);
            }
        }

        #endregion

        #region bank draft

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
                ViewBag.ResourceFile = node.RelTmpNode.Row_ID;
                return View(tcInfo);
            }
        }

        #endregion

        #region bank draft

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
                ViewBag.ResourceFile = node.RelTmpNode.Row_ID;
                return View(tcInfo);
            }
        }

        #endregion

        #region bank draft

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
                ViewBag.ResourceFile = node.RelTmpNode.Row_ID;
                return View(tcInfo);
            }
        }

        #endregion

        #region bank draft

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
                ViewBag.ResourceFile = node.RelTmpNode.Row_ID;
                return View(tcInfo);
            }
        }

        #endregion

    }
}
