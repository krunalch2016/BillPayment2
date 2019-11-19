using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Payment.Models;
using Payment.BLL;

namespace Payment.Controllers
{
    public class PaymentWebController : ApiController
    {
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(PaymentWebController));
        [HttpPost]
        public int? MakePayment(PaymentModel model)
        {

            HttpResponseMessage response = new HttpResponseMessage();
            PaymentBLL bllobj = new PaymentBLL();
            int? Result = bllobj.MakePayment(model);
            if (Result > 0)
            {
                response.Content = new StringContent("Payment Success");
            }
            else
            {
                response.Content = new StringContent("Payment FAIL");
            }
            return Result;
        }        

        [HttpPost]
        public int? Register(RegisterModel registerobj)
        {
            HttpResponseMessage message = new HttpResponseMessage();
            PaymentBLL bllobj = new PaymentBLL();
            int? Result = bllobj.RegisterCustomerData(registerobj);

            if (Result > 0)
            {
                message.Content = new StringContent("SUCCESS");
            }
            else
            {
                message.Content = new StringContent("FAIL");
            }

            return Result;
        }
        int? Result1;
        [HttpPost]
        public int? Login(LoginModel loginobj)
        {
            HttpResponseMessage message = new HttpResponseMessage();
            PaymentBLL bllobj = new PaymentBLL();
            int? Result = bllobj.LoginCustomer(loginobj);

            if (Result>0)
            {
                Result1 = bllobj.LoginVerify(loginobj.MobileNumber);
                RegisterModel.MobileNum = loginobj.MobileNumber;
                if (Result1 > 0)
                {
                    message.Content = new StringContent("LOGIN SUCCESS");
                }
                else
                {
                    message.Content = new StringContent("LOGIN PrePaid");

                }
            }
            else
            {
                message.Content = new StringContent("LOGIN FAIL");
                Result1 = -1;
            }
            return Result1;
        }

        [HttpGet]
        public List<PrePaidModel> GetDetails(string MobileOperator,long MobileNumber)
        {
            PrePaidModel modelObj = new PrePaidModel();
            PaymentBLL bllObj = new PaymentBLL();
            int? result = bllObj.CheckNumber(MobileNumber, MobileOperator);
            if(result>0)
            {
                modelObj.PrepaidList = bllObj.Display(MobileOperator);
            }
           
            return modelObj.PrepaidList;
        }
        [HttpPost]
        public int? PostPaid(PostPaidModel postobj)
        {
            HttpResponseMessage message = new HttpResponseMessage();
            PaymentBLL bllobj = new PaymentBLL();
            int? Result = bllobj.PostPaid(postobj);

            if (Result > 0)
            {

                message.Content = new StringContent("LOGIN SUCCESS");
            }
            else
            {
                message.Content = new StringContent("LOGIN FAIL");
            }
            return Result;
        }
       
        [HttpPost]
        public int? ForgotPassword(RegisterModel model)
        {
           
            HttpResponseMessage message = new HttpResponseMessage();
            PaymentBLL bllobj = new PaymentBLL();
            int? Result = bllobj.ForgotPasswordRegister(model);
            
            return Result;
        }
    }
}
