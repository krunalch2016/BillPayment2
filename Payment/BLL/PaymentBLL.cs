using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Payment.DAL;
using Payment.Models;

namespace Payment.BLL
{
    public class PaymentBLL
    {
        PaymentDAL dalObj;

        public PaymentBLL()
        {
            dalObj = new PaymentDAL();
        }

        public int? MakePayment(PaymentModel paymentModel)
        {
            return dalObj.MakePayment(paymentModel);
        }       

        public int? RegisterCustomerData(RegisterModel Registerobj)
        {
            return dalObj.RegisterCustomerData(Registerobj); 
        }
        public int? LoginCustomer(LoginModel loginobj)
        {
            return dalObj.LoginCustomer(loginobj); ;
        }

        public List<PrePaidModel> Display(string MobileOperator)
        {
            return dalObj.Display(MobileOperator);
        }

        public int? PostPaid(PostPaidModel postobj)
        {
            return dalObj.PostPaid(postobj);
        }
        public int? CheckNumber(long MobileNumber,string Operator)
        {
            return dalObj.CheckNumber(MobileNumber, Operator);
        }

        public int? ForgotPasswordRegister(RegisterModel modelObj)
        {
            return dalObj.ForgotPasswordRegister(modelObj);
        }
        public int? LoginVerify(long MobileNumber)
        {
            return dalObj.LoginVerify(MobileNumber);
        }
    }
}