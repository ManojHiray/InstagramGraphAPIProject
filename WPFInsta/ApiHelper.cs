using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace WPFInsta
{
    public static class ApiHelper
    {
        public static HttpClient ApiClient { get; set; } = new HttpClient();

        public static void InitializeClient()
        {
            ApiClient = new HttpClient();
           // ApiClient.BaseAddress = new Uri("https://graph.facebook.com/me?fields=id,name&access_token=EAAGJoiz111wBABTcaowRwoKGTMEwHjAJcZAMSrHGUaOc23EyEZB5tUCCWR49y66CTGMx9iuwL6DUdZAvbkuxZCVcCTSIjDZC5r7ewjkCOGjKnAGHqCQ60nsKXZBbLnLot40kiIIAgJVCfyCvi8bfiZCsye2A1mtHjysF5l6Pk9344v7MNUKaZA785naamzNbcHwupyjO5Urgmw7fpWQr6S4ZCQeASSTAdjvoVoRyIncF1EqlZBZBfmsm57k3Mn1ksPZA3CoZD");
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
