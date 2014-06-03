using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using FATS.DataDefine;
using FATS.Models;
using FATS.BusinessObject;

namespace FATS.Areas.Settings.Controllers
{
    public class Teaching2SettingController : Controller
    {
        //
        // GET: /Settings/Teaching2Setting/

        public ActionResult Index()
        {
            using (FATContainer dataContainer = new FATContainer())
            {
                return View("T2RoutineList", dataContainer.TemplateRoutine.Where(routine => routine.RoutineType == ConstDefine.RoutineType_Teaching2).ToList());
            }
        }

        public ActionResult Edit()
        {
            TeachingRoutine routine = SharedCasePool.GetCasePool().GetRoutine(Convert.ToInt32(RouteData.Values["id"]));
            return View("T2RoutineDetail", routine);
        }

        [HttpPost]
        public ActionResult LoadCase(string tmpRoutineID)
        {
            JsonResult result = new JsonResult();
            if (tmpRoutineID == string.Empty)
            {
                result.Data = CommFunctions.WrapClientGridData(new List<TeachingRoutine>());
                return result;
            }
            using (FATContainer dataContainer = new FATContainer())
            {
                var routineList = dataContainer.TeachingRoutine.AsNoTracking().Where(routine => routine.TmpRoutineID == tmpRoutineID).ToList();
                result.Data = CommFunctions.WrapClientGridData(routineList);
                return result;
            }
        }

        [HttpPost]
        public ActionResult UpdateCase(int tchRoutineID, string caseName, string caseText)
        {
            using (FATContainer dataContainer = new FATContainer())
            {
                TeachingRoutine cachedRoutine = SharedCasePool.GetCasePool().GetRoutine(tchRoutineID);
                cachedRoutine.CaseName = caseName;              

                TeachingRoutine dbRoutine = dataContainer.TeachingRoutine.Find(tchRoutineID);
                dataContainer.Entry<TeachingRoutine>(dbRoutine).CurrentValues.SetValues(cachedRoutine);

                dataContainer.SaveChanges();
            }
            return null;
        }

        [HttpPost]
        public ActionResult ChangeCaseStatus(bool isEnabled, int tchRoutineID)
        {
            using (FATContainer dataContainer = new FATContainer())
            {
                TeachingRoutine cachedRoutine = SharedCasePool.GetCasePool().GetRoutine(tchRoutineID);
                cachedRoutine.CurrStatus = Convert.ToInt16(isEnabled ? 1 : 0);

                TeachingRoutine dbRoutine = dataContainer.TeachingRoutine.Find(tchRoutineID);
                dbRoutine.CurrStatus = cachedRoutine.CurrStatus;

                dataContainer.SaveChanges();
            }
            return null;
        }


        [HttpPost]
        public ActionResult DeleteCase(int teachingRoutineID)
        {
            using (FATContainer dataContainer = new FATContainer())
            {
                dataContainer.TeachingRoutine.Remove(dataContainer.TeachingRoutine.Find(teachingRoutineID));
                IEnumerable<TeachingNode> nodeList = from node in dataContainer.TeachingNode
                                                     where node.RoutineID == teachingRoutineID
                                                     select node;
                foreach (TeachingNode node in nodeList)
                {
                    dataContainer.TeachingNode.Remove(node);
                }
                dataContainer.SaveChanges();
            }
            JsonResult result = new JsonResult();
            return result;
        }

        [HttpPost]
        public ActionResult AppendCase(TeachingRoutine routine)
        {
            using (FATContainer dataContainer = new FATContainer())
            {                
                dataContainer.TeachingRoutine.Add(routine);
                dataContainer.SaveChanges();
            }
            JsonResult result = new JsonResult();
            result.Data = routine;
            return result;
        }


    }
}
