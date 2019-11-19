using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Report.DAL;
using Payment.Models;

namespace Report.BLL
{
    public class ReportBLL
    {
        ReportDAL dalObj;
        public ReportBLL()
        {
            dalObj = new ReportDAL();
        }
        public List<UserTransactModel> Display()
        {
            return dalObj.ExtractReport();
        }
    }
}