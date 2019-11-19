using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Payment.Models;

namespace Payment.BLL
{
    interface IBLL
    {
        int? PaymentCreditCard(PaymentModel modelobj);
        int? NetBanking(PaymentModel modelobj);
        int? RegisterCustomerData(RegisterModel Registerobj);
        int? LoginCustomer(LoginModel loginobj);
        List<PrePaidModel> Display(string MobileOperator);
        int? PostPaid(PostPaidModel postobj);
        int? CheckNumber(long MobileNumber, string Operator);
        int? ForgotPasswordRegister(RegisterModel modelObj);
        int? LoginVerify(long MobileNumber);

        
    }
}
