using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using FATS.DataDefine;
using FATS.Models;
using FATS.BusinessObject;

namespace FATS.Areas.Teachings.Controllers
{
    public class TeachingInitController : Controller
    {
        //
        // GET: /Teaching1/Teaching1Init/
        #region T1
        public ActionResult T1Init()
        {
            
            using (FATContainer dataContainer = new FATContainer())
            {
                return View("SelectT1Case", dataContainer.TemplateRoutine.Where(routine => routine.RoutineType == ConstDefine.RoutineType_Teaching1).ToList());
            }          
        }

        public ActionResult SelectNode()
        {
            TeachingRoutine routine = SharedCasePool.GetCasePool().GetRoutine(Convert.ToInt32(RouteData.Values["id"]));
            return View(routine);    
        }

        public ActionResult GetNextNode(int teachingRoutineID, int teachingNodeID)
        {
            using (FATContainer dataContainer = new FATContainer())
            {
                TeachingNode nextNode = SharedCasePool.GetCasePool().NavigateToNextNode(teachingRoutineID, teachingNodeID);
                StudentActivity activity = dataContainer.StudentActivity.FirstOrDefault(act => act.UserID == CurrentUser.GetUserID() && act.TimeMark == DateTime.Now.Date && act.TchRoutineID == teachingRoutineID);
                if (activity == null)
                    activity = dataContainer.StudentActivity.Create();
                JsonResult result = new JsonResult();
                if (nextNode == null)
                {
                    CurrentUser.SetLastFinishedRoutineID(teachingRoutineID);                    
                    result.Data = "/Teachings/TeachingInit/SelectT1Case";                    
                    if (activity.Row_ID == 0)
                    {
                        activity.TchNodeID = -1;
                        activity.IsFinished = 1;
                        activity.TchRoutineID = teachingRoutineID;
                        activity.UserID = CurrentUser.GetUserID();
                        activity.TimeMark = DateTime.Now.Date;
                        dataContainer.StudentActivity.Add(activity);
                        dataContainer.SaveChanges();
                    }
                    else
                    {
                        activity.TchNodeID = -1;
                        activity.IsFinished = 1;
                        dataContainer.Entry<StudentActivity>(activity).CurrentValues.SetValues(activity);
                        dataContainer.SaveChanges();
                    }
                }
                else 
                {
                    TeachingRoutine routine = SharedCasePool.GetCasePool().GetRoutine(teachingNodeID);
                    if (routine.NodeList.Keys.IndexOf(activity.TchNodeID) < routine.NodeList.Keys.IndexOf(nextNode.Row_ID))
                    {
                        activity.TchNodeID = nextNode.Row_ID;
                        activity.IsFinished = 0;
                        //dataContainer.Entry<StudentActivity>(activity).CurrentValues.SetValues(activity);
                        dataContainer.SaveChanges();
                    }
                    result.Data = string.Format("{0}/{1}/{2}", nextNode.NodeType, nextNode.NodeTag, nextNode.Row_ID);
                }
                return result;
            }   
        }

        public ActionResult GetNavigationContext(int teachingRoutineID, int teachingNodeID)
        {
            using (FATContainer dataContainer = new FATContainer())
            {
                TeachingRoutine routine = SharedCasePool.GetCasePool().GetRoutine(teachingRoutineID);
                int currNodeIdx = routine.NodeList.Keys.IndexOf(teachingNodeID);
                int maxNodeCount = routine.NodeList.Count;
                DateTime currDate = DateTime.Now.Date;
                int currUserID = CurrentUser.GetUserID();
                StudentActivity activity = dataContainer.StudentActivity.FirstOrDefault(act => act.UserID == currUserID && act.TimeMark >= currDate && act.TchRoutineID == teachingRoutineID);
                ClientContext context = new ClientContext();
                context.IsTeacher = CurrentUser.GetUserInfo().IsTeacher;
                if (currNodeIdx == 0)
                {
                    context.PrevTchNodeID = -1;
                    context.PrevTchNodeTag = string.Empty;
                    context.PrevTchNodeType = string.Empty;
                }
                else
                {
                    TeachingNode prevNode = routine.NodeList[routine.NodeList.Keys[currNodeIdx - 1]];
                    context.PrevTchNodeID = prevNode.Row_ID;
                    context.PrevTchNodeTag = prevNode.NodeTag;
                    context.PrevTchNodeTag = prevNode.NodeType;
                }
                if (currNodeIdx == maxNodeCount - 1)
                {
                    context.NextTchNodeID = -1;
                    context.NextTchNodeTag = string.Empty;
                    context.NextTchNodeType = string.Empty;
                }
                else
                {
                    TeachingNode nextNode = routine.NodeList[routine.NodeList.Keys[currNodeIdx + 1]];
                    context.NextTchNodeID = nextNode.Row_ID;
                    context.NextTchNodeTag = nextNode.NodeTag;
                    context.NextTchNodeType = nextNode.NodeType;
                }
                context.TchRoutineID = routine.Row_ID;

                //normally it won't occur
                //i wonder if the code is necessary, just the protection for the unexpected bug?
                if (activity == null)
                {
                    context.IsFinished = 0;
                    activity = dataContainer.StudentActivity.Create();
                    activity.TchNodeID = teachingNodeID;
                    activity.IsFinished = 0;
                    activity.TchRoutineID = teachingRoutineID;
                    activity.UserID = CurrentUser.GetUserID();
                    activity.TimeMark = DateTime.Now.Date;
                    dataContainer.StudentActivity.Add(activity);
                    dataContainer.SaveChanges();
                }
                else
                {
                    if (activity.IsFinished == 1)
                    {
                        context.IsFinished = 1;
                    }
                    else
                    {
                        int currActivityIdx = routine.NodeList.Keys.IndexOf(activity.TchNodeID);
                        context.IsFinished = (currNodeIdx < currActivityIdx) ? 1 : 0;
                        if (currNodeIdx > currActivityIdx)
                        {
                            activity.TchNodeID = routine.NodeList[teachingNodeID].Row_ID;
                            dataContainer.SaveChanges();
                        }
                    }
                }

                JsonResult result = new JsonResult();
                result.Data = context;
                return result;
            }
        }
                
        public ActionResult ListStudiedRoutine()
        {
            using (FATContainer dataContainer = new FATContainer())
            {
                JsonResult result = new JsonResult();
                DateTime currDate = DateTime.Now.Date;
                List<StudentActivity> activityList = dataContainer.StudentActivity.Where(act => act.TimeMark >= currDate).OrderBy(act => act.IsFinished).ToList();
                SharedCasePool casePool = SharedCasePool.GetCasePool();
                foreach (StudentActivity activity in activityList)
                {
                    TeachingRoutine routine = casePool.GetRoutine(activity.TchRoutineID);
                    if (routine == null)
                    {
                        result.Data = CommFunctions.WrapClientGridData(new List<StudentActivity>());
                        return result;
                    }
                    activity.CaseName = routine.CaseName;
                    activity.TmpRoutineName = routine.RelTmpRoutine.RoutineName;

                    if (activity.TchNodeID == -1)
                        activity.TmpNodeName = "(已完成)";
                    else
                    {
                        activity.TmpNodeName = routine.NodeList[activity.TchNodeID].RelTmpNode.NodeName;
                        activity.NodeType = routine.NodeList[activity.TchNodeID].RelTmpNode.NodeType;
                        activity.NodeTag = routine.NodeList[activity.TchNodeID].RelTmpNode.Tag;
                    }
                }
                activityList.Clear();
                result.Data = CommFunctions.WrapClientGridData(activityList);
                return result;
            }          
        }

        public ActionResult ResetRoutine(int activityID)
        {
            using (FATContainer dataContainer = new FATContainer())
            {
                StudentActivity activity = dataContainer.StudentActivity.First(act => act.Row_ID == activityID);
                TeachingRoutine tchRoutine = SharedCasePool.GetCasePool().GetRoutine(activity.TchRoutineID);
                activity.IsFinished = 0;
                activity.TchNodeID = tchRoutine.NodeList[tchRoutine.NodeList.Keys[0]].Row_ID;
                dataContainer.SaveChanges();
                JsonResult result = new JsonResult();
                TeachingNode firstNode = tchRoutine.NodeList[tchRoutine.NodeList.Keys[0]];
                result.Data = string.Format("{0}/{1}/{2}", firstNode.NodeType, firstNode.NodeTag, firstNode.Row_ID);
                return result;
            }
        }

        public ActionResult StartRoutine(int teachingRoutineID)
        {
            DateTime currDate = DateTime.Now.Date;
            int currUserID = CurrentUser.GetUserID();
            using (FATContainer dataContainer = new FATContainer())
            {
                TeachingRoutine tchRoutine = SharedCasePool.GetCasePool().GetRoutine(teachingRoutineID);
                TeachingNode firstNode = tchRoutine.NodeList[tchRoutine.NodeList.Keys[0]];
                StudentActivity activity = dataContainer.StudentActivity.FirstOrDefault(act => (act.UserID == currUserID) && (act.TimeMark >= currDate) && (act.TchRoutineID == teachingRoutineID));
                if (activity == null)
                    activity = dataContainer.StudentActivity.Create();
                activity.TchNodeID = firstNode.Row_ID;
                activity.IsFinished = 0;
                activity.TchRoutineID = teachingRoutineID;
                activity.UserID = CurrentUser.GetUserID();
                activity.TimeMark = DateTime.Now.Date;
                if (activity.Row_ID == 0)
                {
                    dataContainer.StudentActivity.Add(activity);
                    dataContainer.SaveChanges();
                }
                else
                {
                    dataContainer.Entry<StudentActivity>(activity).CurrentValues.SetValues(activity);
                    dataContainer.SaveChanges();
                }
             
                JsonResult result = new JsonResult();
                result.Data = string.Format("{0}/{1}/{2}", firstNode.NodeType, firstNode.NodeTag, firstNode.Row_ID);
                return result;
            }
        }

        #endregion


        #region T2

        #endregion
    }
}
