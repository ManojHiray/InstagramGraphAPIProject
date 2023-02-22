using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WPFInsta
{
    public class Property
    {
        public string client_id { get; set; }// = "432804608726876";
        public string client_secret { get; set; } //= "238353733e4793c0fc043a2df7318f2f";
        public string fb_exchange_token { get; set; } //= "EAAGJoiz111wBAFnsTqNoJRs0JrEayCZC0CEB6R90kV6e1Ikg1nSyCwZC6Dbnp08EeyTRanDA9gNhIDd9jcfznkd68cTokhJ20FbTf0LoRM1cbb6po4YYjKxz0TOTWOzBHqp0ZAlD9n83dE0LaRWOu0rfp7rQ0CHqDXVJMqmcFdjyhy0mZAZCZAfpwhXQApVGJ1wnYPNsYRavokIdkAYFSB8EkY9EpEemBzEJRTF2CNOQoL6Q3mVlrOBSe5rZCOPERsZD";
        public string grant_type { get; set; } // = "fb_exchange_token";


        public async Task<string> GetToken()
        {
            using (var client = ApiHelper.ApiClient)
            {
               var endPoint3 = new Uri("https://graph.facebook.com/oauth/access_token");

                var newPost3 = new Property()
                {
                    client_id = ConfigurationManager.AppSettings["client_id"],//"432804608726876",
                    client_secret = ConfigurationManager.AppSettings["client_secret"],//"238353733e4793c0fc043a2df7318f2f",
                    fb_exchange_token = ConfigurationManager.AppSettings["fb_token"],//fb_exchange_token,
                    grant_type = ConfigurationManager.AppSettings["grant_type"]
               };

               var newPostJson3 = JsonConvert.SerializeObject(newPost3);
               var payload3 = new StringContent(newPostJson3, Encoding.UTF8, "application/json");
               var result3 = client.PostAsync(endPoint3, payload3).Result.Content.ReadAsStringAsync().Result;
               Token_Access token = JsonConvert.DeserializeObject<Token_Access>(result3);
               this.fb_exchange_token = token.access_token;
                //return result3;
                

                Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                configuration.AppSettings.Settings["fb_token"].Value = token.access_token;
                configuration.Save(ConfigurationSaveMode.Full, true);
                ConfigurationManager.RefreshSection("appSettings");

                Console.WriteLine(result3);
                return token.access_token;

            
            }
        }
        
        public class Token_Access
        {
            public string access_token { get; set; }    
        }
    }
}
