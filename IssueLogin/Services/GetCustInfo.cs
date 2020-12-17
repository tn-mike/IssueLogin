using IssueLogin.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssueLogin.Services
{
    public class GetCustInfo
    {
        CallAPI service = new CallAPI();

        public bool CallCustInfo(string user01, string user02)
        {
            var doCon = true;
            List<Task<ResponseModel>> response1 = new List<Task<ResponseModel>>();
            List<Task<ResponseModel>> response2 = new List<Task<ResponseModel>>();
            for (int i = 0; i < 15; i++)
            {
                Console.Write("Post API:" + (i + 1));
                response1.Add(service.RequestCustInfo(user01));
                response2.Add(service.RequestCustInfo(user02));
            }

            List<DataCustModel> cust1 = GetDataListCustInfo(response1, ref doCon);
            List<DataCustModel> cust2 = GetDataListCustInfo(response2, ref doCon);

            Console.Write(Environment.NewLine);
            for (int i = 0; i < cust1.Count; i++)
            {
                Console.WriteLine(cust1[i].idCard + "====" + cust2[i].idCard);
            }

            return doCon;
        }

        public List<DataCustModel> GetDataListCustInfo(List<Task<ResponseModel>> response, ref bool doCon)
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
                        var data = JsonConvert.DeserializeObject<CustomerInfoModel>(JsonConvert.SerializeObject(res.Result.data));
                        if (count != 0)
                        {
                            if (data.idCardNumber != custInfo[count - 1].idCard && custInfo[count - 1].idCard != "Error")
                            {
                                doCon = false;
                                mark = "XXX";
                            }
                        }

                        custInfo.Add(new DataCustModel
                        {
                            idCard = data.idCardNumber + mark
                        });
                    }
                    else
                    {
                        custInfo.Add(new DataCustModel
                        {
                            idCard = "Error"
                        });
                    }
                }
                catch (Exception)
                {
                    custInfo.Add(new DataCustModel
                    {
                        idCard = "Error"
                    });
                }

                count++;
            }

            return custInfo;
        }
    }
}
