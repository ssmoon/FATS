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
    public class RegisterBookController : Controller
    {
        //
        // GET: /Teachings/RegisterBook/

        public ActionResult Index()
        {
            return View();
        }

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

                return View("CollectAccept_" + node.RelTmpNode.NodeIndex, tcInfo);
            }
        }

        #endregion
    }
}
