using IssueLogin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssueLogin.Services
{
    public class GetCSN
    {
        CallAPI service = new CallAPI();

        public bool CallGetCSN(string user01, string user02)
        {
            var doCon = true;
            List<Task<ResponseModel>> response1 = new List<Task<ResponseModel>>();
            List<Task<ResponseModel>> response2 = new List<Task<ResponseModel>>();
            for (int i = 0; i < 15; i++)
            {
                Console.Write("Post API:" + (i + 1));
                response1.Add(service.RequestCSN(user01));
                response2.Add(service.RequestCSN(user02));
            }

            GetCustInfo s = new GetCustInfo();
            List<DataCustModel> cust1 = s.GetDataListCustInfo(response1, ref doCon);
            List<DataCustModel> cust2 = s.GetDataListCustInfo(response2, ref doCon);

            Console.Write(Environment.NewLine);
            for (int i = 0; i < cust1.Count; i++)
            {
                Console.WriteLine(cust1[i].idCard + "====" + cust2[i].idCard);
            }

            return doCon;
        }
    }
}
