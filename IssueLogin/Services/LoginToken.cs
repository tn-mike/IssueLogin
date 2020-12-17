using IssueLogin.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssueLogin.Services
{
    public class LoginToken
    {
        CallAPI service = new CallAPI();

        public bool CallLoginToken(string user01, string user02)
        {
            var doCon = true;
            List<Task<ResponseModel>> response1 = new List<Task<ResponseModel>>();
            List<Task<ResponseModel>> response2 = new List<Task<ResponseModel>>();
            for (int i = 0; i < 15; i++)
            {
                Console.Write("Post API:" + (i + 1));
                response1.Add(service.RequestLoginToken(user01));
                response2.Add(service.RequestLoginToken(user02));
            }

            List<DataCustModel> cust1 = GetDataList(response1, ref doCon);
            List<DataCustModel> cust2 = GetDataList(response2, ref doCon);

            Console.Write(Environment.NewLine);
            Console.WriteLine("                        User01                            User02                   ResponseTime01                      ResponseTime01      ContNoRDS01         ContNoRDS02   UserN01      UserN02     ContNo400-01        ContNo400-02");
            for (int i = 0; i < cust1.Count; i++)
            {
                Console.WriteLine(cust1[i].idCard + "|" + cust1[i].contract + "====" + cust2[i].idCard + "|" + cust2[i].contract + " (" + cust1[i].time + "====" + cust2[i].time + ")" + " " + cust1[i].rdsCont + "====" + cust2[i].rdsCont + " " + cust1[i].rdsUser + "====" + cust2[i].rdsUser + " " + cust1[i].contract400 + "====" + cust2[i].contract400 + " " + cust1[i].transactionId + "====" + cust2[i].transactionId);
            }
            Console.WriteLine("                        User01                            User02                   ResponseTime01                      ResponseTime01      ContNoRDS01         ContNoRDS02   UserN01      UserN02     ContNo400-01        ContNo400-02");

            return doCon;
        }

        public static List<DataCustModel> GetDataList(List<Task<ResponseModel>> response, ref bool doCon)
        {
            int count = 0;
            List<DataCustModel> custInfo = new List<DataCustModel>();

            foreach (var res in response)
            {
                string mark = "";
                try
                {
                    if (res.Result.success)
                    {
                        var data = JsonConvert.DeserializeObject<ResAS400Model>(JsonConvert.SerializeObject(res.Result.data));
                        data.contractNumber = data.contractNumber.Replace("-", "");
                        if (count != 0)
                        {
                            if (data.contractNumber != custInfo[count - 1].contract && custInfo[count - 1].contract != "Error")
                            {
                                doCon = false;
                                mark = "XXX";
                            }
                        }

                        custInfo.Add(new DataCustModel
                        {
                            idCard = data.idCardNumber,
                            contract = data.contractNumber + mark,
                            time = res.Result.responseTime,
                            rdsCont = res.Result.message.Split('|')[0],
                            rdsUser = res.Result.message.Split('|')[1],
                            contract400 = res.Result.message.Split('|')[2].Replace("-", ""),
                            transactionId = res.Result.message.Split('|')[3]
                        });
                    }
                    else
                    {
                        custInfo.Add(new DataCustModel
                        {
                            idCard = "Error",
                            contract = "Error",
                            time = res.Result.responseTime,
                            rdsCont = res.Result.message.Split('|')[0],
                            rdsUser = res.Result.message.Split('|')[1],
                            contract400 = res.Result.message.Split('|')[2].Replace("-", ""),
                            transactionId = res.Result.message.Split('|')[3]
                        });
                    }
                }
                catch (Exception)
                {
                    custInfo.Add(new DataCustModel
                    {
                        idCard = "Error",
                        contract = "Error",
                        time = "Error",
                        rdsCont = "Error",
                        rdsUser = "Error",
                        contract400 = "Error",
                        transactionId = "Error"
                    });
                }

                count++;
            }

            return custInfo;
        }
    }
}
