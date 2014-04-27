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

        public ActionResult Intro()
        {
            using (FATContainer dataContainer = new FATContainer())
            {
                TeachingNode node = dataContainer.TeachingNode.Find(Convert.ToInt32(RouteData.Values["id"]));                
                TeachingRoutine tchRoutine = SharedCasePool.GetCasePool().GetRoutine(node.RoutineID);
                ViewBag.CurrGroup = tchRoutine.NodeList[node.Row_ID].GroupIdx;
                ViewBag.TchNodeID = node.Row_ID;
                ViewBag.CaseName = tchRoutine.CaseName;
                return View("RoutineStepProgress", tchRoutine);
            }    
        }

        #endregion

        #region general ledger

        [HttpGet]
        public ActionResult GeneralLedger_Init()
        {
            using (FATContainer dataContainer = new FATContainer())
            {
                TeachingNode node = dataContainer.TeachingNode.Find(Convert.ToInt32(RouteData.Values["id"]));
                List<GeneralLedger> glList = dataContainer.GeneralLedger.Where(info => (info.TchNodeID == node.Row_ID) && (info.TchRoutineID == node.RoutineID)).ToList();
                ViewData[ConstDefine.ViewData_CaseText] = SharedCasePool.GetCasePool().GetRoutine(node.RoutineID).CaseText;
                return View(glList);
            }            
        }
        
        #endregion

        #region detailed ledger

        [HttpGet]
        public ActionResult DetailedLedger_Init()
        {
            using (FATContainer dataContainer = new FATContainer())
            {
                TeachingNode node = dataContainer.TeachingNode.Find(Convert.ToInt32(RouteData.Values["id"]));
                List<DetailedLedger> dlList = dataContainer.DetailedLedger.Where(info => (info.TchNodeID == node.Row_ID) && (info.TchRoutineID == node.RoutineID)).ToList();
                ViewData[ConstDefine.ViewData_CaseText] = SharedCasePool.GetCasePool().GetRoutine(node.RoutineID).CaseText;
                return View(dlList);
            }
        }

        #endregion

        #region Client ledger

        [HttpGet]
        public ActionResult CustomerLedger_Init()
        {
            using (FATContainer dataContainer = new FATContainer())
            {
                TeachingNode node = dataContainer.TeachingNode.Find(Convert.ToInt32(RouteData.Values["id"]));
                ViewData[ConstDefine.ViewData_CaseText] = SharedCasePool.GetCasePool().GetRoutine(node.RoutineID).CaseText;
                List<CustomerLedger> clList = dataContainer.CustomerLedger.Where(info => (info.TchNodeID == node.Row_ID) && (info.TchRoutineID == node.RoutineID)).ToList();
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
