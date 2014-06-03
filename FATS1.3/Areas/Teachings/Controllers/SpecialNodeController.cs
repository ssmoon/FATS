using System;
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
    }
}
