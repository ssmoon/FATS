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
    public class DebitTransferCheckController : Controller
    {
        //
        // GET: /Settings/Special/

        public ActionResult Index()
        {
            return View();
        }

        #region transfer check

        public ActionResult Step_Init1()
        {
            using (FATContainer dataContainer = new FATContainer())
            {
                int tchRoutineID = dataContainer.TeachingNode.Find(Convert.ToInt32(RouteData.Values["id"])).RoutineID;
                TeachingRoutine routine = SharedCasePool.GetCasePool().GetRoutine(tchRoutineID);
                TeachingNode node = routine.NodeList[Convert.ToInt32(RouteData.Values["id"])];
                TransferCheck tcInfo = dataContainer.TransferCheck.FirstOrDefault(info => (info.TchRoutineID == node.RoutineID));
                ViewData[ConstDefine.ViewData_CaseText] = SharedCasePool.GetCasePool().GetRoutine(node.RoutineID).CaseText;
                ViewBag.TchNodeID = node.Row_ID;
                ViewBag.ResourceFile = node.RelTmpNode.Row_ID;
                return View(tcInfo);
            }
        }


        #endregion
    }
}
