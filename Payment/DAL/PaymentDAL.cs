using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Payment.Models;
using Payment.Utilities;

namespace Payment.DAL
{
    public class PaymentDAL
    {
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(PaymentDAL));
        Dictionary<PaymentMethods, Func<PaymentModel, int?>> PaymentMethod;
        public PaymentDAL()
        {
            PaymentMethod = new Dictionary<PaymentMethods, Func<PaymentModel, int?>>();
            PopulatePymentMethods();
        }

        private void PopulatePymentMethods()
        {
            PaymentMethod.Add(PaymentMethods.NETBANKING, (paymentModel) => NetBanking(paymentModel));
            PaymentMethod.Add(PaymentMethods.CREDITCARD, (paymentModel) => PaymentCreditCard(paymentModel));
        }

        public int? MakePayment(PaymentModel paymentModel)
        {
            return PaymentMethod[paymentModel.PaymentMethod](paymentModel);
        }

        public int? PaymentCreditCard(PaymentModel modelobj)
        {
            try
            {
                using (var paymentEntities = new BillPaymentEntities())
                {
                    var debitandcredit = paymentEntities.debit_creditcard_table.FirstOrDefault(obj => obj.CardNumber == modelobj.CardNumber
                                                            && obj.CVVNumber == modelobj.CVVNumber && obj.ExpiryDate == modelobj.ExpiryDate &&
                                                            obj.Balance > (decimal?)modelobj.Balance);
                    debitandcredit.Balance -= (decimal)modelobj.Amount;
                    var UsrDet = paymentEntities.table_Registration.Where(x => x.MobileNumber == RegisterModel.MobileNum);
                    if (UsrDet.Any())
                    {
                        var userTxn = new User_Transaction();
                        userTxn.CustomerName = UsrDet.First().CustomerName;
                        userTxn.MobileNumber = UsrDet.First().MobileNumber;
                        userTxn.Amount = (decimal)modelobj.Amount;
                        userTxn.Operator = UsrDet.First().Operator;
                        userTxn.PlantType = UsrDet.First().Plantype;
                        paymentEntities.User_Transaction.Add(userTxn);
                    }
                    paymentEntities.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return null;
            }
            return 1;
        }

        public int? NetBanking(PaymentModel modelobj)
        {
            try
            {
                using (var paymentEntities = new BillPaymentEntities())
                {
                    var debitandcredit = paymentEntities.debit_creditcard_table.FirstOrDefault(obj => obj.UserID == modelobj.UserID
                                                            && obj.UserPassword == modelobj.UserPassword && obj.BankName == modelobj.BankName
                                                            && obj.Balance > (decimal)modelobj.Balance);
                    debitandcredit.Balance -= (decimal)modelobj.Amount;
                    var UsrDet = paymentEntities.table_Registration.Where(x => x.MobileNumber == RegisterModel.MobileNum);
                    if (UsrDet.Any())
                    {
                        var userTxn = new User_Transaction();
                        userTxn.CustomerName = UsrDet.First().CustomerName;
                        userTxn.MobileNumber = UsrDet.First().MobileNumber;
                        userTxn.Amount = (decimal)modelobj.Amount;
                        userTxn.Operator = UsrDet.First().Operator;
                        userTxn.PlantType = UsrDet.First().Plantype;
                        paymentEntities.User_Transaction.Add(userTxn);
                    }
                    paymentEntities.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return null;
            }
            return 1;
        }

        public int? RegisterCustomerData(RegisterModel registerObj)
        {
            try
            {
                using (var paymentEntities = new BillPaymentEntities())
                {
                    var tabReg = new table_Registration();
                    tabReg.CustomerName = registerObj.CustomerName;
                    tabReg.MobileNumber = registerObj.MobileNumber;
                    tabReg.EmailID = registerObj.EmailId;
                    tabReg.Plantype = registerObj.Plantype;
                    tabReg.SecurityQuestion = registerObj.SecurityQuestion;
                    tabReg.SecurityAnswer = registerObj.SecurityAnswer;
                    tabReg.NewPassword = registerObj.NewPassword;
                    tabReg.ConfirmPassword = registerObj.ConfirmPassword;
                    tabReg.Operator = registerObj.Operator;
                    paymentEntities.table_Registration.Add(tabReg);

                    var tabLogin = new table_Login();
                    tabLogin.MobileNumber = registerObj.MobileNumber;
                    tabLogin.ConfirmPassword = registerObj.ConfirmPassword;
                    paymentEntities.table_Login.Add(tabLogin);

                    if (registerObj.Plantype == "Prepaid")
                    {
                        var prePaid = new PrePaid();
                        prePaid.MobileNumber = registerObj.MobileNumber;
                        prePaid.Operator = registerObj.Operator;
                        paymentEntities.PrePaids.Add(prePaid);
                    }
                    else if (registerObj.Plantype == "Postpaid")
                    {
                        var postPaid = new PostPaid();
                        postPaid.MobileNumber = registerObj.MobileNumber;
                        postPaid.Operator = registerObj.Operator;
                        paymentEntities.PostPaids.Add(postPaid);
                    }

                    paymentEntities.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return null;
            }
            return 1;
        }


        public int? LoginCustomer(LoginModel loginobj)
        {
            try
            {
                using (var paymentEntities = new BillPaymentEntities())
                {
                    return (from cust in paymentEntities.table_Login
                            where cust.MobileNumber == loginobj.MobileNumber && cust.ConfirmPassword == loginobj.ConfirmPassword
                            select cust).ToList().Count() > 0 ? 1 : 0;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return null;
            }
        }

        public List<PrePaidModel> Display(string MobileOperator)
        {
            try
            {
                using (var paymentEntities = new BillPaymentEntities())
                {
                    return (from prepaid in paymentEntities.Operator_Table1
                            where prepaid.Operator == MobileOperator
                            select new PrePaidModel
                            {
                                Operator = prepaid.Operator,
                                MRP = (double)prepaid.MRP,
                                ValidateDays = prepaid.ValidateDays,
                                Descriptions = prepaid.Descriptions,
                                Roaming = prepaid.Roaming,
                                SMS = prepaid.SMS,
                                DataSpeed = prepaid.DataSpeed
                            }).ToList();
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return null;
            }
        }


        public int? PostPaid(PostPaidModel postobj)
        {
            try
            {
                using (var paymentEntities = new BillPaymentEntities())
                {
                    return (from postPaid in paymentEntities.PostPaids
                            where postPaid.MobileNumber == postobj.MobileNumber
                            && postPaid.Operator == postobj.Operator
                            select postPaid).ToList().Count() > 0 ? 1 : 0;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return null;
            }
        }

        public int? CheckNumber(long MobileNumber, string Operator)
        {
            try
            {
                using (var paymentEntities = new BillPaymentEntities())
                {
                    return (from prePaid in paymentEntities.PrePaids
                            where prePaid.MobileNumber == MobileNumber
                            && prePaid.Operator == Operator
                            select prePaid).ToList().Count() > 0 ? 1 : 0;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return null;
            }
        }

        public int? ForgotPasswordRegister(RegisterModel modelobj)
        {
            try
            {
                using (var paymentEntities = new BillPaymentEntities())
                {
                    var forgotPassword = paymentEntities.table_Registration.FirstOrDefault(obj => obj.MobileNumber == modelobj.MobileNumber
                                            && obj.SecurityAnswer == modelobj.SecurityAnswer
                                            && obj.SecurityQuestion == modelobj.SecurityQuestion);
                    if (forgotPassword != null)
                    {
                        forgotPassword.NewPassword = modelobj.NewPassword;
                        forgotPassword.ConfirmPassword = modelobj.ConfirmPassword;
                        var login = paymentEntities.table_Login.FirstOrDefault(obj => obj.MobileNumber == modelobj.MobileNumber);
                        login.ConfirmPassword = modelobj.ConfirmPassword;
                        paymentEntities.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return null;
            }
            return 1;
        }

        public int? LoginVerify(long MobileNumber)
        {
            try
            {
                using (var paymentEntities = new BillPaymentEntities())
                {
                    return (from postPaid in paymentEntities.PostPaids
                            where postPaid.MobileNumber == MobileNumber
                            select postPaid).ToList().Count() > 0 ? 1 : 0;
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