using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssueLogin.Models
{
    public class ResponseModel
    {
        public int status { get; set; }
        public bool success { get; set; }
        public object data { get; set; }
        public object error { get; set; }
        public string message { get; set; }
        public string responseTime { get; set; }
    }

    public class ReqLoginModel
    {
        public string username { get; set; }
        public string password { get; set; }
        public string deviceID { get; set; }
    }

    public class ResAS400Model
    {
        public string resultMessage { get; set; }
        public string customerNameTH { get; set; }
        public string customerNameEN { get; set; }
        public string totalCreditLimit { get; set; }
        public string rlCreditLimit { get; set; }
        public string totalCreditAvailable { get; set; }
        public string rlCreditAvailable { get; set; }
        public string nextDueRL1 { get; set; }
        public string contractNumber { get; set; }
        public string cardNumber { get; set; }
        public string cardActivate { get; set; }
        public string internetCashingFunction { get; set; }
        public string idCardNumber { get; set; }
        public string csnNumber { get; set; }
        public string lastLogin { get; set; }
        public string cardType { get; set; }
        public string linkImage { get; set; }
    }

    public class DataCustModel
    {
        public string idCard { get; set; }
        public string contract { get; set; }
        public string time { get; set; }
        public string rdsCont { get; set; }
        public string rdsUser { get; set; }
        public string contract400 { get; set; }
        public string transactionId { get; set; }
    }

    public class CustomerInfoModel
    {
        public string idCardNumber { get; set; }
        public string csnNumber { get; set; }
        public string umayCardNumber { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string birthDate { get; set; }
        public string mobileNumber { get; set; }
        public string email { get; set; }
    }
}
