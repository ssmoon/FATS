using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using FATS.Models;
using FATS.DataDefine;
using FATS.Exceptions;

namespace FATS.BusinessObject
{
    public class SharedCasePool
    {
        private const string ApplicationObj_SharedCasePool = "SharedCasePool";

        private Dictionary<int, TeachingRoutine> TeachingRoutinePool = new Dictionary<int, TeachingRoutine>();
 
        public TeachingRoutine GetRoutine(int routineID)
        {
            if (TeachingRoutinePool.ContainsKey(routineID))
                return TeachingRoutinePool[routineID];
            using (FATContainer dbContainer = new FATContainer())
            {
                TeachingRoutine resultRoutine = dbContainer.TeachingRoutine.Find(routineID);
                if (TeachingRoutinePool.ContainsKey(routineID))
                    return TeachingRoutinePool[routineID];
                else TeachingRoutinePool.Add(routineID, resultRoutine);

                if (resultRoutine.RelTmpRoutine == null)
                {
                    Console.WriteLine("RelatedTemplateRoutine loaded from db");
                    resultRoutine.RelTmpRoutine = dbContainer.TemplateRoutine.FirstOrDefault(routine => routine.Row_ID == resultRoutine.TmpRoutineID);                    
                    var nodeList = from node in dbContainer.TemplateNode
                                   where node.RoutineID == resultRoutine.RelTmpRoutine.Row_ID
                                   select node;
                    foreach (TemplateNode node in nodeList)
                        resultRoutine.RelTmpRoutine.NodeDict.Add(node.Row_ID, node);
                }

                if ((resultRoutine.RelTmpRoutine.RoutineType == ConstDefine.RoutineType_Teaching1) && (resultRoutine.NodeList == null))
                {
                    resultRoutine.NodeList = new SortedList<int, TeachingNode>();
                    Console.WriteLine("Load sub teaching node from db");
                    var nodeList = from node in dbContainer.TeachingNode                                   
                                   orderby node.Row_ID
                                   where node.RoutineID == resultRoutine.Row_ID 
                                   select node;
                    foreach (TeachingNode node in nodeList)
                    {
                        resultRoutine.NodeList.Add(node.Row_ID, node);
                        node.RelTmpNode = resultRoutine.RelTmpRoutine.NodeDict[node.TmpNodeID]; 
                    }                    
                }    
                if (resultRoutine.GroupList == null)
                {
                    resultRoutine.GroupList = new SortedList<int, RoutineGroup>();
                    var groupList = from groupVar in dbContainer.RoutineGroup
                                    orderby groupVar.GroupIdx
                                    where groupVar.TchRoutineID == resultRoutine.Row_ID
                                    select groupVar;
                    foreach (RoutineGroup group in groupList)
                    {
                        resultRoutine.GroupList.Add(group.GroupIdx, group);
                    }
                }
                return resultRoutine;                
            }            
        }

        public void ReloadRoutine(int routineID)
        {
            if (TeachingRoutinePool.ContainsKey(routineID))
                TeachingRoutinePool.Remove(routineID);
            GetRoutine(routineID);
        }

        public static SharedCasePool GetCasePool()
        {
            if (HttpContext.Current.Application[ApplicationObj_SharedCasePool] == null)
            {
                HttpContext.Current.Application[ApplicationObj_SharedCasePool] = new SharedCasePool();

            }
            return HttpContext.Current.Application[ApplicationObj_SharedCasePool] as SharedCasePool;
        }

        public TeachingNode NavigateToNextNode(int currTchRoutineID, int currTchNodeID)
        {
            TeachingRoutine tchRoutine = GetRoutine(currTchRoutineID);
            TeachingNode currNode = tchRoutine.NodeList[currTchNodeID];
            int nodeIndex = tchRoutine.NodeList.Keys.IndexOf(currNode.Row_ID);
            if (nodeIndex == tchRoutine.NodeList.Count - 1)
                return null;
            else return tchRoutine.NodeList[nodeIndex + 1];
        }
    }
}