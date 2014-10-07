using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using FATS.Models;
using FATS.DataDefine;
using FATS.BusinessObject;

namespace FATS.Areas.Teachings.Controllers
{
    public class CommonNodeController : Controller
    {
        //
        // GET: /Settings/Special/

        public ActionResult Index()
        {
            return View();
        }

        #region routine step progress

        public ActionResult Guide()
        {
            using (FATContainer dataContainer = new FATContainer())
            {
                TeachingNode node = dataContainer.TeachingNode.Find(Convert.ToInt32(RouteData.Values["id"]));                
                TeachingRoutine tchRoutine = SharedCasePool.GetCasePool().GetRoutine(node.RoutineID);
                ViewBag.CurrGroup = tchRoutine.NodeList[node.Row_ID].GroupIdx;
                ViewBag.TchNodeID = node.Row_ID;
                ViewBag.CaseName = tchRoutine.CaseName;
                ViewBag.RoutineIntro = tchRoutine.GroupList[tchRoutine.NodeList[node.Row_ID].GroupIdx].RoutineIntro;
                return View("RoutineStepProgress", tchRoutine);
            }    
        }

        #endregion

        #region general ledger

        [HttpGet]
        public ActionResult GeneralLedger()
        {
            using (FATContainer dataContainer = new FATContainer())
            {
                TeachingNode node = dataContainer.TeachingNode.Find(Convert.ToInt32(RouteData.Values["id"]));
                List<GeneralLedger> glList = dataContainer.GeneralLedger.Where(info => (info.TchNodeID == node.Row_ID) && (info.TchRoutineID == node.RoutineID)).ToList();                
                TeachingRoutine routine = SharedCasePool.GetCasePool().GetRoutine(node.RoutineID);
                ViewBag.RoutineName = routine.RelTmpRoutine.RoutineName;
                node = routine.FindNode(node.Row_ID);
                ViewBag.NodeName = node.NodeName;
                ViewData[ConstDefine.ViewData_CaseText] = SharedCasePool.GetCasePool().GetRoutine(node.RoutineID).GroupList[node.GroupIdx].GroupText;
                return View(glList);
            }            
        }
        
        #endregion

        #region detailed ledger

        [HttpGet]
        public ActionResult DetailedLedger()
        {
            using (FATContainer dataContainer = new FATContainer())
            {
                TeachingNode node = dataContainer.TeachingNode.Find(Convert.ToInt32(RouteData.Values["id"]));
                
                List<DetailedLedger> dlList = dataContainer.DetailedLedger.Where(info => (info.TchNodeID == node.Row_ID) && (info.TchRoutineID == node.RoutineID)).ToList();
                TeachingRoutine routine = SharedCasePool.GetCasePool().GetRoutine(node.RoutineID);
                ViewBag.RoutineName = routine.RelTmpRoutine.RoutineName;
                node = routine.FindNode(node.Row_ID);
                ViewBag.NodeName = node.NodeName;
                ViewData[ConstDefine.ViewData_CaseText] = SharedCasePool.GetCasePool().GetRoutine(node.RoutineID).GroupList[node.GroupIdx].GroupText;    
                return View(dlList);
            }
        }

        #endregion

        #region Client ledger

        [HttpGet]
        public ActionResult CustomerLedger()
        {
            using (FATContainer dataContainer = new FATContainer())
            {
                TeachingNode node = dataContainer.TeachingNode.Find(Convert.ToInt32(RouteData.Values["id"]));
               
                List<CustomerLedger> clList = dataContainer.CustomerLedger.Where(info => (info.TchNodeID == node.Row_ID) && (info.TchRoutineID == node.RoutineID)).ToList();
                TeachingRoutine routine = SharedCasePool.GetCasePool().GetRoutine(node.RoutineID);
                ViewBag.RoutineName = routine.RelTmpRoutine.RoutineName;
                node = routine.FindNode(node.Row_ID);
                ViewBag.NodeName = node.NodeName;
                ViewData[ConstDefine.ViewData_CaseText] = SharedCasePool.GetCasePool().GetRoutine(node.RoutineID).GroupList[node.GroupIdx].GroupText;
                return View(clList);
            }
        }

        #endregion

        #region subject filler 
        public ActionResult SubjectFiller()
        {
            int tchRoutineID = Convert.ToInt32(RouteData.Values["rid"]);
            int tchNodeID = Convert.ToInt32(RouteData.Values["nid"]);
            TeachingRoutine routine = SharedCasePool.GetCasePool().GetRoutine(tchRoutineID);
            using (FATContainer dataContainer = new FATContainer())
            {
                List<SubjectItem> subjectList = dataContainer.SubjectItem.Where(s => s.TchNodeID == tchNodeID && s.TchRoutineID == tchRoutineID).OrderBy(s => s.SubjectOrient).ToList();
                ViewBag.ResourceFile = routine.NodeList[tchNodeID].RelTmpNode.Row_ID;
                return View(subjectList);
            }            
        }

        #endregion
    }
}
