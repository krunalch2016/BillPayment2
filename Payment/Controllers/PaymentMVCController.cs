using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Payment.Models;
using Payment.BLL;
using log4net;

namespace Payment.Controllers
{
    public class PaymentMVCController : Controller
    {
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(PaymentMVCController));
        // GET: PaymentMVC
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult IndexView()
        {
            return View();
        }

        public ActionResult AboutUs()
        {
            return View();
        }

        public ActionResult ContactUs()
        {
            return View();
        }

        public ActionResult Payment(PaymentModel modelobj)

        {
            try
            {


                PaymentBLL bllobj = new PaymentBLL();
                int? Result = bllobj.MakePayment(modelobj);
                if (Result > 0)
                {
                    ViewBag.Result = "Success";
                }
                else
                {
                    ViewBag.Result = "Failed";

                }
            }
            catch (Exception ex)

            {
                logger.Info(ex.Message);
                logger.Debug(ex.Message);
            }
            return View();
        }

        public ActionResult NetBanking(PaymentModel modelobj)

        {
            try
            {
                PaymentBLL bllobj = new PaymentBLL();
                int? Result = bllobj.MakePayment(modelobj);
                if (Result > 0)
                {
                    ViewBag.Result = "Success";
                }
                else
                {
                    ViewBag.Result = "Failed";

                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
                logger.Debug(ex.Message);
            }
            return View();
        }

        public ActionResult Register()

        {
            return View();
        }

        public ActionResult Login(LoginModel loginObj)
        {
            try
            {
                Session["txtMobileNumber"] = loginObj.MobileNumber;
                RegisterModel.MobileNum = loginObj.MobileNumber;
                PaymentBLL bllObj = new PaymentBLL();
                int? Result = bllObj.LoginCustomer(loginObj);
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
                logger.Debug(ex.Message);
            }
            return View();
        }

        public ActionResult PrePaidView(FormCollection forms)
        {
            try
            {
                //var Data_Session = new LoginModel();
                //if ((Object)Session["txtMobileNumber"] != null)
                //{
                //    Data_Session.Session_Val = "Welcome" + Convert.ToInt64(Session["MobileNumber"]).ToString();
                //}
                //else
                //{
                //    Data_Session.Session_Val = "Session Expired";
                //}
                PrePaidModel preobj = new PrePaidModel();
                PaymentBLL bllobj = new PaymentBLL();
                int? result = bllobj.CheckNumber(Convert.ToInt64(forms["txtMobileNumber"]), forms["dllOperator"]);
                if (result > 0)
                {
                    preobj.PrepaidList = bllobj.Display(forms["dllOperator"]);
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
                logger.Debug(ex.Message);
            }
            return View();
        }

        public ActionResult PostPaid(PostPaidModel postObj)
        {
            try
            {
                PaymentBLL bllObj = new PaymentBLL();
                int? Result = bllObj.PostPaid(postObj);
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
                logger.Debug(ex.Message);
            }
            return View();
        }
        public ActionResult Pay()
        {
            return View();
        }
        public ActionResult Pre_Post()
        {
            return View();
        }


        public ActionResult ForgotPasswordView()
        {

            return View();
        }
        public ActionResult ErrorView()
        {
            ViewBag.Error = "Error";
            return View();
        }

        public ActionResult LPGPayment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MakeLPGPayment(Payment.Models.PaytmModel data)
        {
            String merchantKey = Utilities.PaytmKeys.machinekey;
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            Random random = new Random();
            parameters.Add("MID", Utilities.PaytmKeys.machineId);
            parameters.Add("CHANNEL_ID", Utilities.PaytmKeys.channelId);
            parameters.Add("INDUSTRY_TYPE_ID", Utilities.PaytmKeys.indstrytype);
            parameters.Add("WEBSITE", Utilities.PaytmKeys.website);
            parameters.Add("EMAIL", data.email);
            parameters.Add("MOBILE_NO", data.mobileNumber);
            parameters.Add("CUST_ID", "1");
            parameters.Add("ORDER_ID", random.Next().ToString());
            parameters.Add("TXN_AMOUNT", data.amount);
            parameters.Add("CALLBACK_URL", "http://localhost:52960/PaymentMVC/PaytmResponse"); //This parameter is not mandatory. Use this to pass the callback url dynamically.

            string checksum = paytm.CheckSum.generateCheckSum(merchantKey, parameters);

            string paytmURL = "https://securegw-stage.paytm.in/theia/processTransaction?orderid=" + parameters.FirstOrDefault(x => x.Key == "ORDER_ID").Value;

            PaytmOutput(parameters, paytmURL, checksum);

            return View("PaytmPayment");
        }

        public void PaytmOutput(Dictionary<string, string> parameters, string paytmURL, string checksum)
        {
            string outputHTML = "<html>";
            outputHTML += "<head>";
            outputHTML += "<title>Merchant Check Out Page</title>";
            outputHTML += "</head>";
            outputHTML += "<body>";
            outputHTML += "<center><h1>Please do not refresh this page...</h1></center>";
            outputHTML += "<form method='post' action='" + paytmURL + "' name='f1'>";
            outputHTML += "<table border='1'>";
            outputHTML += "<tbody>";
            foreach (string key in parameters.Keys)
            {
                outputHTML += "<input type='hidden' name='" + key + "' value='" + parameters[key] + "'>";
            }
            outputHTML += "<input type='hidden' name='CHECKSUMHASH' value='" + checksum + "'>";
            outputHTML += "</tbody>";
            outputHTML += "</table>";
            outputHTML += "<script type='text/javascript'>";
            outputHTML += "document.f1.submit();";
            outputHTML += "</script>";
            outputHTML += "</form>";
            outputHTML += "</body>";
            outputHTML += "</html>";

            ViewBag.htmlData = outputHTML;
        }

        [HttpPost]
        public ActionResult PaytmResponse(Payment.Models.PaytmResponse data)
        {
            PaymentBLL bllobj = new PaymentBLL();
            if (data.STATUS.Equals("TXN_SUCCESS"))
                bllobj.SavePaytmRecord(RegisterModel.MobileNum, Convert.ToInt32(data.ORDERID), Convert.ToDecimal(data.TXNAMOUNT), "LPG [Success]", data.PAYMENTMODE);
            else
                bllobj.SavePaytmRecord(RegisterModel.MobileNum, Convert.ToInt32(data.ORDERID), Convert.ToDecimal(data.TXNAMOUNT) * -1, "LPG [Fail]", data.PAYMENTMODE);
            return View("PaytmResponse", data);
        }
    }
}