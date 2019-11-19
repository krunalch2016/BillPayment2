using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Payment.Models;
using Report.BLL;

namespace Payment.Controllers
{
    public class ReportApiController : ApiController
    {
        [HttpGet]
        public List<UserTransactModel> GetReport()
        {
            ReportBLL repObj = new ReportBLL();
            return repObj.Display();
        }
    }
}