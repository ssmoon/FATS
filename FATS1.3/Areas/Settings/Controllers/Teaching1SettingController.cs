﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

using FATS.DataDefine;
using FATS.Models;
using FATS.BusinessObject;

namespace FATS.Areas.Settings.Controllers
{
    public class Teaching1SettingController : Controller
    {
        //
        // GET: /Settings/CaseSetting/

        public ActionResult Index()
        {
            using (FATContainer dataContainer = new FATContainer())
            {
                return View("T1RoutineList", dataContainer.TemplateRoutine.Where(routine => routine.RoutineType == ConstDefine.RoutineType_Teaching1).ToList());
            }
        }


        public ActionResult Edit()
        {
            TeachingRoutine routine = SharedCasePool.GetCasePool().GetRoutine(Convert.ToInt32(RouteData.Values["id"]));
            return View("T1RoutineDetail", routine);
        }

        [HttpPost]
        public ActionResult LoadSubNode(int teachingRoutineID)
        {
            TeachingRoutine routine = SharedCasePool.GetCasePool().GetRoutine(teachingRoutineID);
            JsonResult result = new JsonResult();
            result.Data = CommFunctions.WrapClientGridData(routine.NodeList.Values.OrderBy(node => node.Index).ToList());
            return result;
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
                cachedRoutine.CaseText = caseText;

                TeachingRoutine dbRoutine = dataContainer.TeachingRoutine.Find(tchRoutineID);
                dataContainer.Entry<TeachingRoutine>(dbRoutine).CurrentValues.SetValues(cachedRoutine);

                dataContainer.SaveChanges();
            }
            JsonResult result = new JsonResult();
            result.Data = string.Empty;
            return result;
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

                var tempateNodeList = from node in dataContainer.TemplateNode
                                      where node.RoutineID == routine.TmpRoutineID
                                      orderby node.NodeIndex
                                      select node;
                List<TeachingNode> tchNodeList = new List<TeachingNode>();
                foreach (TemplateNode tmpNode in tempateNodeList)
                {
                    TeachingNode newNode = new TeachingNode() { CurrStatus = 0, RelTmpNode = tmpNode, RoutineID = routine.Row_ID, TmpNodeID = tmpNode.Row_ID };
                    tchNodeList.Add(newNode);
                    dataContainer.TeachingNode.Add(newNode);
                }
                dataContainer.SaveChanges();

                string currPhaseName = string.Empty;
                foreach (TeachingNode tchNode in tchNodeList)
                {
                   
                    switch (tchNode.NodeTag)
                    {
                        case "Guide":
                            {
                                currPhaseName = tchNode.NodeName;
                                break;
                            }
                        #region common node
                        case "DetailedLedger":
                            {
                                for (int i = 0; i <= tchNode.RelTmpNode.RequireRecord - 1; i++)
                                {
                                    DetailedLedger info = dataContainer.DetailedLedger.Create();
                                    info.TchNodeID = tchNode.Row_ID;
                                    info.TchRoutineID = routine.Row_ID;
                                    info.RoutineDesc = tchNode.GroupIdx + "." + currPhaseName;
                                    info.TimeMark = DateTime.Now;
                                    dataContainer.DetailedLedger.Add(info);
                                }
                                break;
                            }
                        case "CustomerLedger":
                            {
                                for (int i = 0; i <= tchNode.RelTmpNode.RequireRecord - 1; i++)
                                {
                                    CustomerLedger info = dataContainer.CustomerLedger.Create();
                                    info.TchNodeID = tchNode.Row_ID;
                                    info.TchRoutineID = routine.Row_ID;
                                    info.RoutineDesc = tchNode.GroupIdx + "." + currPhaseName;
                                    info.TimeMark = DateTime.Now;
                                    info.BalanceTime = DateTime.Now;
                                    dataContainer.CustomerLedger.Add(info);
                                }
                                break;
                            }
                        case "GeneralLedger":
                            {
                                for (int i = 0; i <= tchNode.RelTmpNode.RequireRecord - 1; i++)
                                {
                                    GeneralLedger info = dataContainer.GeneralLedger.Create();
                                    info.TchNodeID = tchNode.Row_ID;
                                    info.TchRoutineID = routine.Row_ID;
                                    info.RoutineDesc = tchNode.GroupIdx + "." + currPhaseName;
                                    info.TimeMark = DateTime.Now;                                    
                                    dataContainer.GeneralLedger.Add(info);
                                }
                                break;
                            }
                        default:
                            {
                                for (int i = 0; i <= tchNode.RelTmpNode.RequireRecord - 1; i++)
                                {
                                    SubjectItem info = dataContainer.SubjectItem.Create();
                                    info.TchNodeID = tchNode.Row_ID;
                                    info.TchRoutineID = routine.Row_ID;
                                    info.RoutineDesc = tchNode.GroupIdx + "." + currPhaseName;                                    
                                    dataContainer.SubjectItem.Add(info);
                                }
                                break;
                            }
                        #endregion
                        #region special node
                      

                        #endregion
                    }                    
                }
                dataContainer.SaveChanges();
            }
            JsonResult result = new JsonResult();
            result.Data = routine;
            return result;
        }

        #region subject item

        public ActionResult EditSubjectItem()
        {
            using (FATContainer dataContainer = new FATContainer())
            {
                TeachingNode tchNode = dataContainer.TeachingNode.Find(Convert.ToInt32(RouteData.Values["id"]));
                ViewBag.TchRoutineID = tchNode.RoutineID;
                ViewBag.TchNodeID = tchNode.Row_ID;
                TemplateNode tmpNode = dataContainer.TemplateNode.FirstOrDefault(n => n.Row_ID == tchNode.TmpNodeID);
                TemplateRoutine tmpRoutine = dataContainer.TemplateRoutine.FirstOrDefault(n => n.Row_ID == tmpNode.RoutineID);
                ViewBag.NodeTitle = tmpRoutine.RoutineName + " " + tmpNode.NodeName + "记账科目设置";
            }
            return View("EditSubjectItem1", new SubjectItem());
        }

        public ActionResult ListSubjectItem(int tchRoutineID, int tchNodeID)
        {
            using (FATContainer dbContainer = new FATContainer())
            {
                JsonResult result = new JsonResult();
                result.Data = CommFunctions.WrapClientGridData(dbContainer.SubjectItem.Where(subject => subject.TchNodeID == tchNodeID && subject.TchRoutineID == tchRoutineID).OrderBy(subject => subject.SubjectOrient).ToList());
                return result;
            }
        }

        public ActionResult GetTemplateSubjectItem()
        {
            using (FATContainer dbContainer = new FATContainer())
            {
                JsonResult result = new JsonResult();
                SubjectItem subject = dbContainer.SubjectItem.Create();
                subject.NextLedger = "客户分户账";
                subject.SubjectOrient = "借";
                subject.SubjectType = "资产";
                subject.ChangeOrient = "增加";
                result.Data = subject;
                return result;
            }
        }

        public ActionResult AppendSubjectItem(SubjectItem subject)
        {
            using (FATContainer dbContainer = new FATContainer())
            {
                dbContainer.SubjectItem.Add(subject);
                dbContainer.SaveChanges();

                JsonResult result = new JsonResult();
                result.Data = subject;
                return result;
            }
        }

        public ActionResult UpdateSubjectItem(SubjectItem subject)
        {
            using (FATContainer dbContainer = new FATContainer())
            {
                SubjectItem existedItem = dbContainer.SubjectItem.FirstOrDefault(item => item.Row_ID == subject.Row_ID);
                if (existedItem == null)
                    return null;
                dbContainer.Entry<SubjectItem>(existedItem).CurrentValues.SetValues(subject);
                dbContainer.SaveChanges();

                JsonResult result = new JsonResult();
                result.Data = "SUCC";
                return result;
            }
        }

        public ActionResult DeleteSubjectItem(int dbRowID)
        {
            using (FATContainer dbContainer = new FATContainer())
            {
                SubjectItem existedItem = dbContainer.SubjectItem.FirstOrDefault(item => item.Row_ID == dbRowID);
                if (existedItem == null)
                    return null;
                dbContainer.SubjectItem.Remove(existedItem);
                dbContainer.SaveChanges();

                JsonResult result = new JsonResult();
                result.Data = "SUCC";
                return result;
            }
        }
        #endregion
    }
}
