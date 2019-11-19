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
            catch(Exception ex)

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
            catch(Exception ex)
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
            catch(Exception ex)
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
            catch(Exception ex)
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
            catch(Exception ex)
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
    }
}