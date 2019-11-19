using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Payment.Models;
using Payment.Utilities;

namespace Report.DAL
{
    public class ReportDAL
    {
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(ReportDAL));
        public List<UserTransactModel> ExtractReport()
        {
            try
            {
                using (var paymentEntities = new BillPaymentEntities())
                {
                    return (from txn in paymentEntities.User_Transaction
                            where txn.MobileNumber == RegisterModel.MobileNum
                            select new UserTransactModel
                            {
                                CustomerName = txn.CustomerName,
                                MobileNumber = txn.MobileNumber,
                                Amount = txn.Amount,
                                Operator = txn.Operator,
                                PlanType = txn.PlantType
                            }).ToList();
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return null;
            }
        }
    }
}