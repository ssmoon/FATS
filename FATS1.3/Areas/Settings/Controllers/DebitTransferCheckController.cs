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
    public class DebitTransferCheckController : Controller
    {
        //
        // GET: /Settings/Special/

        public ActionResult Index()
        {
            return View();
        }

        #region routine setting 

        public ActionResult InitT1RoutineData()
        {
            using (FATContainer dataContainer = new FATContainer())
            {
                TeachingNode node = dataContainer.TeachingNode.Find(Convert.ToInt32(RouteData.Values["id"]));
                TransferCheck tcInfo = dataContainer.TransferCheck.FirstOrDefault(info => (info.TchRoutineID == node.RoutineID));
                if (tcInfo == null)
                {
                    tcInfo = dataContainer.TransferCheck.Create();
                    tcInfo.TchRoutineID = node.RoutineID;
                    dataContainer.TransferCheck.Add(tcInfo);
                    dataContainer.SaveChanges();
                }
                return View(tcInfo);
            }            
        }

        [HttpPost]
        public ActionResult SaveT1RoutineData(TransferCheck info)
        {
            using (FATContainer dataContainer = new FATContainer())
            {
                TransferCheck orgInfo = dataContainer.TransferCheck.Find(info.Row_ID);
                dataContainer.Entry<TransferCheck>(orgInfo).CurrentValues.SetValues(info);
                dataContainer.SaveChanges();

                JsonResult result = new JsonResult();
                return result;
            }
        }


        public ActionResult InitT2RoutineData()
        {
            using (FATContainer dataContainer = new FATContainer())
            {
                TeachingNode node = dataContainer.TeachingNode.Find(Convert.ToInt32(RouteData.Values["id"]));
                List<TransferCheck> tcList = dataContainer.TransferCheck.Where(info => (info.TchRoutineID == node.RoutineID)).ToList();
                if (tcList.Count == 0)
                {
                    TransferCheck tcInfo1 = dataContainer.TransferCheck.Create();
                    tcInfo1.TchRoutineID = node.RoutineID;
                    tcInfo1.TchRoutineTag = RoutineConstDefine.T2_DebitTransferCheck_TransferCheck;
                    dataContainer.TransferCheck.Add(tcInfo1);
                    tcList.Add(tcInfo1);
                    TransferCheck tcInfo2 = dataContainer.TransferCheck.Create();
                    tcInfo2.TchRoutineID = node.RoutineID;
                    tcInfo2.TchRoutineTag = RoutineConstDefine.T2_DebitTransferCheck_TransferCheck;
                    dataContainer.TransferCheck.Add(tcInfo2);
                    tcList.Add(tcInfo2);
                    dataContainer.SaveChanges();
                }
                return View(tcList);
            }
        }

        [HttpPost]
        public ActionResult SaveT2RoutineData(List<TransferCheck> tcList)
        {
            using (FATContainer dataContainer = new FATContainer())
            {
                foreach (TransferCheck tc in tcList)
                {
                    TransferCheck orgInfo = dataContainer.TransferCheck.Find(tc.Row_ID);
                    dataContainer.Entry<TransferCheck>(orgInfo).CurrentValues.SetValues(tc);
                }
                dataContainer.SaveChanges();

                JsonResult result = new JsonResult();
                return result;
            }
        }


        #endregion

        #region input phase  Step 1



        #endregion
    }
}
