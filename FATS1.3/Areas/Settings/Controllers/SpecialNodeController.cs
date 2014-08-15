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
    public class SpecialNodeController : Controller
    {
        //
        // GET: /Settings/Special/

        public ActionResult Index()
        {
            return View();
        }

        #region DebitTransferCheck

        public ActionResult InitDebitTransferCheckData()
        {
            using (FATContainer dataContainer = new FATContainer())
            {
                int tchRoutineID = Convert.ToInt32(RouteData.Values["tchRoutineID"]);
                TransferCheck info = dataContainer.TransferCheck.FirstOrDefault(item => (item.TchRoutineID == tchRoutineID));
                if (info == null)
                {
                    info = dataContainer.TransferCheck.Create();
                    info.TchRoutineID = tchRoutineID;
                    info.IncomeBillDate = DateTime.Now;
                    info.ChequeDate = DateTime.Now;
                    dataContainer.TransferCheck.Add(info);
                    dataContainer.SaveChanges();
                }
                return View("TransferCheck", info);
            }            
        }

        [HttpPost]
        public ActionResult SaveDebitTransferCheckData(TransferCheck info)
        {
            using (FATContainer dataContainer = new FATContainer())
            {
                TransferCheck orgInfo = dataContainer.TransferCheck.Find(info.Row_ID);
                dataContainer.Entry<TransferCheck>(orgInfo).CurrentValues.SetValues(info);
                dataContainer.SaveChanges();

                JsonResult result = new JsonResult();
                result.Data = string.Empty;
                return result;
            }
        }

        #endregion

        #region MoneyRemittance
        public ActionResult InitMoneyRemittanceData()
        {
            using (FATContainer dataContainer = new FATContainer())
            {
                int tchRoutineID = Convert.ToInt32(RouteData.Values["tchRoutineID"]);
                MoneyRemittance info = dataContainer.MoneyRemittance.FirstOrDefault(item => (item.TchRoutineID == tchRoutineID));
                if (info == null)
                {
                    info = dataContainer.MoneyRemittance.Create();
                    info.TchRoutineID = tchRoutineID;
                    info.AffluxDate = DateTime.Now;
                    info.RemitDate = DateTime.Now;
                    dataContainer.MoneyRemittance.Add(info);
                    dataContainer.SaveChanges();
                }
                return View("MoneyRemittance", info);
            }
        }

        [HttpPost]
        public ActionResult SaveMoneyRemittanceData(MoneyRemittance info)
        {
            using (FATContainer dataContainer = new FATContainer())
            {
                MoneyRemittance orgInfo = dataContainer.MoneyRemittance.Find(info.Row_ID);
                dataContainer.Entry<MoneyRemittance>(orgInfo).CurrentValues.SetValues(info);
                dataContainer.SaveChanges();

                JsonResult result = new JsonResult();
                result.Data = string.Empty;
                return result;
            }
        }
        #endregion

        #region EntrustBankPayment
        public ActionResult InitEntrustBankPaymentData()
        {
            using (FATContainer dataContainer = new FATContainer())
            {
                int tchRoutineID = Convert.ToInt32(RouteData.Values["tchRoutineID"]);
                EntrustBankPayment info = dataContainer.EntrustBankPayment.FirstOrDefault(item => (item.TchRoutineID == tchRoutineID));
                if (info == null)
                {
                    info = dataContainer.EntrustBankPayment.Create();
                    info.TchRoutineID = tchRoutineID;
                    info.EntrustDate = DateTime.Now;
                    info.PaymentDate = DateTime.Now;
                    dataContainer.EntrustBankPayment.Add(info);
                    dataContainer.SaveChanges();
                }
                return View("EntrustBankPayment", info);
            }
        }

        [HttpPost]
        public ActionResult SaveEntrustBankPaymentData(EntrustBankPayment info)
        {
            using (FATContainer dataContainer = new FATContainer())
            {
                EntrustBankPayment orgInfo = dataContainer.EntrustBankPayment.Find(info.Row_ID);
                dataContainer.Entry<EntrustBankPayment>(orgInfo).CurrentValues.SetValues(info);
                dataContainer.SaveChanges();

                JsonResult result = new JsonResult();
                result.Data = string.Empty;
                return result;
            }
        }
        #endregion

        #region EntrustCorpPayment
        public ActionResult InitEntrustCorpPaymentData()
        {
            using (FATContainer dataContainer = new FATContainer())
            {
                int tchRoutineID = Convert.ToInt32(RouteData.Values["tchRoutineID"]);
                EntrustCorpPayment info = dataContainer.EntrustCorpPayment.FirstOrDefault(item => (item.TchRoutineID == tchRoutineID));
                if (info == null)
                {
                    info = dataContainer.EntrustCorpPayment.Create();
                    info.TchRoutineID = tchRoutineID;
                    info.EntrustDate = DateTime.Now;
                    info.PaymentDate = DateTime.Now;
                    dataContainer.EntrustCorpPayment.Add(info);
                    dataContainer.SaveChanges();
                }
                return View("EntrustCorpPayment", info);
            }
        }

        [HttpPost]
        public ActionResult SaveEntrustCorpPaymentData(EntrustCorpPayment info)
        {
            using (FATContainer dataContainer = new FATContainer())
            {
                EntrustCorpPayment orgInfo = dataContainer.EntrustCorpPayment.Find(info.Row_ID);
                dataContainer.Entry<EntrustCorpPayment>(orgInfo).CurrentValues.SetValues(info);
                dataContainer.SaveChanges();

                JsonResult result = new JsonResult();
                result.Data = string.Empty;
                return result;
            }
        }
        #endregion

        #region BankAcceptBill
        public ActionResult InitBankAcceptBillData()
        {
            using (FATContainer dataContainer = new FATContainer())
            {
                int tchRoutineID = Convert.ToInt32(RouteData.Values["tchRoutineID"]);
                BankAcceptBill info = dataContainer.BankAcceptBill.FirstOrDefault(item => (item.TchRoutineID == tchRoutineID));
                if (info == null)
                {
                    info = dataContainer.BankAcceptBill.Create();
                    info.TchRoutineID = tchRoutineID;
                    info.DrawBillDate = DateTime.Now;
                    info.IncomeBillDate = DateTime.Now;
                    dataContainer.BankAcceptBill.Add(info);
                    dataContainer.SaveChanges();
                }
                return View("BankAcceptBill", info);
            }
        }

        [HttpPost]
        public ActionResult SaveBankAcceptBillData(BankAcceptBill info)
        {
            using (FATContainer dataContainer = new FATContainer())
            {
                BankAcceptBill orgInfo = dataContainer.BankAcceptBill.Find(info.Row_ID);
                dataContainer.Entry<BankAcceptBill>(orgInfo).CurrentValues.SetValues(info);
                dataContainer.SaveChanges();

                JsonResult result = new JsonResult();
                result.Data = string.Empty;
                return result;
            }
        }
        #endregion

        #region BankDraft
        public ActionResult InitBankDraftData()
        {
            using (FATContainer dataContainer = new FATContainer())
            {
                int tchRoutineID = Convert.ToInt32(RouteData.Values["tchRoutineID"]);
                BankDraft info = dataContainer.BankDraft.FirstOrDefault(item => (item.TchRoutineID == tchRoutineID));
                if (info == null)
                {
                    info = dataContainer.BankDraft.Create();
                    info.TchRoutineID = tchRoutineID;
                    info.DraftDate = DateTime.Now;
                    info.IncomeBillDate = DateTime.Now;
                    dataContainer.BankDraft.Add(info);
                    dataContainer.SaveChanges();
                }
                return View("BankDraft", info);
            }
        }

        [HttpPost]
        public ActionResult SaveBankDraftData(BankDraft info)
        {
            using (FATContainer dataContainer = new FATContainer())
            {
                BankDraft orgInfo = dataContainer.BankDraft.Find(info.Row_ID);
                dataContainer.Entry<BankDraft>(orgInfo).CurrentValues.SetValues(info);
                dataContainer.SaveChanges();

                JsonResult result = new JsonResult();
                result.Data = string.Empty;
                return result;
            }
        }
        #endregion

        #region CollectAccept
        public ActionResult InitCollectAcceptData()
        {
            using (FATContainer dataContainer = new FATContainer())
            {
                int tchRoutineID = Convert.ToInt32(RouteData.Values["tchRoutineID"]);
                CollectAccept info = dataContainer.CollectAccept.FirstOrDefault(item => (item.TchRoutineID == tchRoutineID));
                if (info == null)
                {
                    info = dataContainer.CollectAccept.Create();
                    info.TchRoutineID = tchRoutineID;
                    info.AcceptDate = DateTime.Now;
                    info.CollectDate = DateTime.Now;
                    dataContainer.CollectAccept.Add(info);
                    dataContainer.SaveChanges();
                }
                return View("CollectAccept", info);
            }
        }

        [HttpPost]
        public ActionResult SaveCollectAcceptData(CollectAccept info)
        {
            using (FATContainer dataContainer = new FATContainer())
            {
                CollectAccept orgInfo = dataContainer.CollectAccept.Find(info.Row_ID);
                dataContainer.Entry<CollectAccept>(orgInfo).CurrentValues.SetValues(info);
                dataContainer.SaveChanges();

                JsonResult result = new JsonResult();
                result.Data = string.Empty;
                return result;
            }
        }
        #endregion
    }
}
