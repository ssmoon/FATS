using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using FATS.Models;
using FATS.DataDefine;
using FATS.BusinessObject;

namespace FATS.Areas.Settings.Controllers
{
    public class CommonNodeController : Controller
    {
        //
        // GET: /Settings/CommonNode/

        public ActionResult Index()
        {
            return View();
        }

        #region DL

        public ActionResult DetailedLedger_Init()
        {
            using (FATContainer dataContainer = new FATContainer())
            {
                DetailedLedger dlInfo = dataContainer.DetailedLedger.Create();
                dlInfo.TchNodeID = Convert.ToInt32(RouteData.Values["id"]);
                TeachingNode tchNode = dataContainer.TeachingNode.FirstOrDefault(node => node.Row_ID == dlInfo.TchNodeID);
                dlInfo.TchRoutineID = tchNode.RoutineID;
                return View(dlInfo);
            }
        }

        public ActionResult DetailedLedger_List(int tNodeID, int tRoutineID)
        {
            using (FATContainer dataContainer = new FATContainer())
            {
                JsonResult result = new JsonResult();
                result.Data = CommFunctions.WrapClientGridData(dataContainer.DetailedLedger.Where((item => (item.TchNodeID == tNodeID) && (item.TchRoutineID == tRoutineID))).ToList());
                return result;
            }
        }

        public ActionResult DetailedLedger_Insert(DetailedLedger info)
        {
            using (FATContainer dataContainer = new FATContainer())
            {
                dataContainer.DetailedLedger.Add(info);
                dataContainer.SaveChanges();

                JsonResult result = new JsonResult();
                result.Data = info;
                return result;
            }
        }

        public ActionResult DetailedLedger_Delete(int glRowID)
        {
            using (FATContainer dataContainer = new FATContainer())
            {
                DetailedLedger dlInfo = dataContainer.DetailedLedger.FirstOrDefault(item => item.Row_ID == glRowID);
                dataContainer.DetailedLedger.Remove(dlInfo);
                dataContainer.SaveChanges();

                JsonResult result = new JsonResult();
                result.Data = string.Empty;
                return result;
            }
        }

        public ActionResult DetailedLedger_Update(DetailedLedger info)
        {
            using (FATContainer dataContainer = new FATContainer())
            {
                DetailedLedger existedInfo = dataContainer.DetailedLedger.FirstOrDefault(item => item.Row_ID == info.Row_ID);
                dataContainer.Entry<DetailedLedger>(existedInfo).CurrentValues.SetValues(info);
                dataContainer.SaveChanges();

                JsonResult result = new JsonResult();
                result.Data = info;
                return result;
            }
        }

        public ActionResult DetailedLedger_GetTemplate()
        {
            using (FATContainer dataContainer = new FATContainer())
            {
                JsonResult result = new JsonResult();
                DetailedLedger dlInfo = dataContainer.DetailedLedger.Create();
                dlInfo.TimeMark = DateTime.Now;
                result.Data = dlInfo;
                return result;
            }
        }
        #endregion

        #region GL

        public ActionResult GeneralLedger_Init()
        {
            using (FATContainer dataContainer = new FATContainer())
            {
                GeneralLedger glInfo = dataContainer.GeneralLedger.Create();
                glInfo.TchNodeID = Convert.ToInt32(RouteData.Values["id"]);
                TeachingNode tchNode = dataContainer.TeachingNode.FirstOrDefault(node => node.Row_ID == glInfo.TchNodeID);
                glInfo.TchRoutineID = tchNode.RoutineID;
                return View(glInfo);
            }
        }

        public ActionResult GeneralLedger_List(int tNodeID, int tRoutineID)
        {
            using (FATContainer dataContainer = new FATContainer())
            {
                JsonResult result = new JsonResult();
                result.Data = CommFunctions.WrapClientGridData(dataContainer.GeneralLedger.Where((item => (item.TchNodeID == tNodeID) && (item.TchRoutineID == tRoutineID))).ToList());
                return result;
            }
        }

        public ActionResult GeneralLedger_Insert(GeneralLedger info)
        {
            using (FATContainer dataContainer = new FATContainer())
            {
                dataContainer.GeneralLedger.Add(info);
                dataContainer.SaveChanges();

                JsonResult result = new JsonResult();
                result.Data = info;
                return result;
            }
        }

        public ActionResult GeneralLedger_Delete(int glRowID)
        {
            using (FATContainer dataContainer = new FATContainer())
            {
                GeneralLedger glInfo = dataContainer.GeneralLedger.FirstOrDefault(item => item.Row_ID == glRowID);
                dataContainer.GeneralLedger.Remove(glInfo);
                dataContainer.SaveChanges();

                JsonResult result = new JsonResult();
                result.Data = glInfo;
                return result;
            }
        }

        public ActionResult GeneralLedger_Update(GeneralLedger info)
        {
            using (FATContainer dataContainer = new FATContainer())
            {
                GeneralLedger existedInfo = dataContainer.GeneralLedger.FirstOrDefault(item => item.Row_ID == info.Row_ID);
                dataContainer.Entry<GeneralLedger>(existedInfo).CurrentValues.SetValues(info);          
                dataContainer.SaveChanges();

                JsonResult result = new JsonResult();
                result.Data = existedInfo;
                return result;
            }
        }

        public ActionResult GeneralLedger_GetTemplate()
        {
            using (FATContainer dataContainer = new FATContainer())
            {
                JsonResult result = new JsonResult();
                GeneralLedger glInfo = dataContainer.GeneralLedger.Create();
                glInfo.TimeMark = DateTime.Now;
                result.Data = glInfo;
                return result;
            }
        }
        #endregion

        #region Customer Ledger

        public ActionResult CustomerLedger_Init()
        {
            using (FATContainer dataContainer = new FATContainer())
            {
                CustomerLedger clInfo = dataContainer.CustomerLedger.Create();
                clInfo.TchNodeID = Convert.ToInt32(RouteData.Values["id"]);
                TeachingNode tchNode = dataContainer.TeachingNode.FirstOrDefault(node => node.Row_ID == clInfo.TchNodeID);
                clInfo.TchRoutineID = tchNode.RoutineID;
                return View(clInfo);
            }
        }

        public ActionResult CustomerLedger_List(int tNodeID, int tRoutineID)
        {
            using (FATContainer dataContainer = new FATContainer())
            {
                JsonResult result = new JsonResult();
                result.Data = CommFunctions.WrapClientGridData(dataContainer.CustomerLedger.Where((item => (item.TchNodeID == tNodeID) && (item.TchRoutineID == tRoutineID))).ToList());
                return result;
            }
        }

        public ActionResult CustomerLedger_Insert(CustomerLedger info)
        {
            using (FATContainer dataContainer = new FATContainer())
            {
                dataContainer.CustomerLedger.Add(info);
                dataContainer.SaveChanges();

                JsonResult result = new JsonResult();
                result.Data = info;
                return result;
            }
        }

        public ActionResult CustomerLedger_Delete(int glRowID)
        {
            using (FATContainer dataContainer = new FATContainer())
            {
                CustomerLedger clInfo = dataContainer.CustomerLedger.FirstOrDefault(item => item.Row_ID == glRowID);
                dataContainer.CustomerLedger.Remove(clInfo);
                dataContainer.SaveChanges();

                JsonResult result = new JsonResult();
                result.Data = string.Empty;
                return result;
            }
        }

        public ActionResult CustomerLedger_Update(CustomerLedger info)
        {
            using (FATContainer dataContainer = new FATContainer())
            {
                CustomerLedger existedInfo = dataContainer.CustomerLedger.FirstOrDefault(item => item.Row_ID == info.Row_ID);
                dataContainer.Entry<CustomerLedger>(existedInfo).CurrentValues.SetValues(info);
                dataContainer.SaveChanges();

                JsonResult result = new JsonResult();
                result.Data = info;
                return result;
            }
        }

        public ActionResult CustomerLedger_GetTemplate()
        {
            using (FATContainer dataContainer = new FATContainer())
            {
                JsonResult result = new JsonResult();
                CustomerLedger clInfo = dataContainer.CustomerLedger.Create();
                clInfo.TimeMark = DateTime.Now;
                clInfo.BalanceTime = DateTime.Now;
                result.Data = clInfo;
                return result;
            }
        }
        #endregion

    }
}
