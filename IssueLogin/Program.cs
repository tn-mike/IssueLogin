using IssueLogin.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IssueLogin
{
    class Program
    {
        private static string user01 = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3NlcmlhbG51bWJlciI6InBtLW5iLW1pa2UiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3VzZXJkYXRhIjoicHJlcHJvZDAxIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvbmFtZWlkZW50aWZpZXIiOiI2MjczNzc5MjAwMDUxNDUwIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9wcmltYXJ5c2lkIjoiNjM1MDAzMDciLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy91cmkiOiJodHRwOi8vYXV0aGVudGljYXRpb25zZXJ2aWNlLnVhdC1hdXRoZW50aWNhdGlvbjo1MDAxL2FwaSIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL2hhc2giOiI3NDBhZWU2OS1jMDIxLTRlZTAtOTdlMC03NzZhOTQ2NzIxOWYiLCJleHAiOjE2MDU2MjE5NzMsIm5iZiI6MTYwNTYwMDM3MywiaXNzIjoiaHR0cDovL3VhdC1jdXN0YXV0aGVuYXBpLm5wcm9kLmNsb3VkLyIsImF1ZCI6Imh0dHA6Ly91YXQtY3VzdGF1dGhlbmFwaS5ucHJvZC5jbG91ZC8ifQ.VhAL-HHOdbhWgzfcv3z0gtdMh-x4PqRi71iV4Njy9Xk";
        private static string user02 = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3NlcmlhbG51bWJlciI6InBtLW5iLW1pa2UiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3VzZXJkYXRhIjoicHJlcHJvZDAyIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvbmFtZWlkZW50aWZpZXIiOiI2MjczNzc5NjAwMDEyMTYwIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9wcmltYXJ5c2lkIjoiNjM1MDAzMjgiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy91cmkiOiJodHRwOi8vYXV0aGVudGljYXRpb25zZXJ2aWNlLnVhdC1hdXRoZW50aWNhdGlvbjo1MDAxL2FwaSIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL2hhc2giOiI1NjNjOGUwMy05ZjdlLTRiMWItOGY0ZS1mYzNjNzUwNzJmNmIiLCJleHAiOjE2MDU2MjE5NDksIm5iZiI6MTYwNTYwMDM0OSwiaXNzIjoiaHR0cDovL3VhdC1jdXN0YXV0aGVuYXBpLm5wcm9kLmNsb3VkLyIsImF1ZCI6Imh0dHA6Ly91YXQtY3VzdGF1dGhlbmFwaS5ucHJvZC5jbG91ZC8ifQ.vueed6L5npjFJQcEVDn5gAfFCLhmqvpMzt-Po2SCGjI";

        static void Main(string[] args)
        {
            string menu = Console.ReadLine();
            Flow(menu);
        }

        public static void Flow(string menu)
        {
            WriteText("Start Menu : " + menu);
            int time = 0;
            bool x_result = true;
            while (x_result)
            {
                time++;
                Console.WriteLine("Time:" + time);
                x_result = SelectMenu(menu);
                Console.WriteLine("###############################################################################################################################################################################");
                Console.WriteLine("Sleep 5s");
                Thread.Sleep(5000);
            };

            Console.WriteLine("Found Error !!!!");
            Console.ReadKey();
        }

        public static bool SelectMenu(string menu)
        {
            bool result;

            if (menu == "1")
            {
                LoginToken _ser = new LoginToken();
                result = _ser.CallLoginToken(user01, user02);
            }
            else if (menu == "2")
            {
                GetCustInfo _ser = new GetCustInfo();
                result = _ser.CallCustInfo(user01, user02);
            }
            else if (menu == "3")
            {
                GetCSN _ser = new GetCSN();
                result = _ser.CallGetCSN(user01, user02);
            }
            else if (menu == "4")
            {
                SocketLogin _ser = new SocketLogin();
                result = _ser.CallSocketLogin();
            }
            else
            {
                WriteText("Menu is not exist");
                result = false;
            }

            return result;
        }

        public static void WriteText(string txt)
        {
            Console.WriteLine(txt + Environment.NewLine);
        }
    }
}
