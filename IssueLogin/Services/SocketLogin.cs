using IssueLogin.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssueLogin.Services
{
    public class SocketLogin
    {
        CallAPI service = new CallAPI();

        public bool CallSocketLogin()
        {
            var data1 = Guid.NewGuid() + "|" + "EBMSG00311900300101426112020110355005IB22303216D526AD445771250F5BD06F5A05CED4032D89F7596A27F438EA7058A774C9FF39A00400280169369001003153293001M002TH";
            var data2 = Guid.NewGuid() + "|" + "EBMSG00311900300101426112020110355005IB223032A189CA2CF888DC815A53CB5492D8409D0325AD2C2AFE1A04953A835E7E48F9B1F1300400280169369001003153392001M002TH";

            List<Task<string>> response1 = new List<Task<string>>();
            List<Task<string>> response2 = new List<Task<string>>();

            for (int i = 0; i < 15; i++)
            {
                Console.Write("Post API:" + (i + 1));
                response1.Add(service.PostStringReturnString(data1));
                response2.Add(service.PostStringReturnString(data2));
            }

            var doCon = true;
            List<DataCustModel> cust1 = GetDataList(response1, ref doCon);
            List<DataCustModel> cust2 = GetDataList(response2, ref doCon);

            Console.Write(Environment.NewLine);
            for (int i = 0; i < cust1.Count; i++)
            {
                Console.WriteLine(cust1[i].contract + "|" + cust2[i].contract);
            }

            return doCon;
        }

        public List<DataCustModel> GetDataList(List<Task<string>> response, ref bool doCon)
        {
            int count = 0;
            List<DataCustModel> custInfo = new List<DataCustModel>();

            foreach (var item in response)
            {
                string mark = "";
                try
                {
                    var r1 = JsonConvert.DeserializeObject<ResponseModel>(item.Result);
                    string rr1 = r1.data.ToString().Substring(r1.data.ToString().IndexOf("-001-") - 4, 18);
                    if (count != 0)
                    {
                        if (rr1 != custInfo[count - 1].contract && custInfo[count - 1].contract != "Error")
                        {
                            doCon = false;
                            mark = "XXX";
                        }
                    }
                    custInfo.Add(new DataCustModel
                    {
                        contract = rr1 + mark
                    });
                }
                catch (Exception)
                {
                    custInfo.Add(new DataCustModel
                    {
                        idCard = "Error",
                        contract = "Error",
                        time = "Error",
                        rdsCont = "Error",
                        rdsUser = "Error"
                    });
                }

                count++;
            }

            return custInfo;
        }
    }
}
