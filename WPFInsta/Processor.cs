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
    public class Processor
    {
        public async Task<string> UploadImage()
        {
            Property newpert = new Property();
            var newToken = ConfigurationManager.AppSettings["fb_token"]; //await newpert.GetToken();

            using (var client = new HttpClient())
            {
                var endPoint = new Uri("https://graph.facebook.com/v14.0/17841453651427542/media");
                var newPost = new Test()
                {

                    image_url = "https://thumbs.dreamstime.com/b/yellow-orange-starburst-flower-nature-jpg-192959431.jpg",
                    caption = "",
                    access_token = newToken,
                    //access_token = "EAAGJoiz111wBAEgVRwWarY5zpVgZCcABzxQB3jbl3ez2KwNmK1As2a0TZAvZCMuMJtDY2yS8OiqgqT13PHHk7Ky8VoGrkxNELrU5n4UDFpZCZBypruQGmpzjSs4n2tSAFmBodjGxXb8yNi8moTtYO1Mdvp3GIZBvGEHGW0IBpQnxkRAdMSIjrfQwJlPIOOhYYTFyOSBRvPzsqZCnw02ZCaZCsTZBJ8r7ZAgE4FbHYUqnyTDZCbSWJycsgMyENFw79IClG90ZD"
                };


                var newPostJson = JsonConvert.SerializeObject(newPost);
                var payload = new StringContent(newPostJson, Encoding.UTF8, "application/json");
                var result = client.PostAsync(endPoint, payload).Result.Content.ReadAsStringAsync().Result;
                Console.WriteLine(result); //get creation id
                //return result;

                Container container = JsonConvert.DeserializeObject<Container>(result);
                Console.WriteLine(container.id);
                

                var endPoint2 = new Uri("https://graph.facebook.com/v14.0/17841453651427542/media_publish");
                var newPost2 = new Post()
                {
                    creation_id = container.id,
                    access_token = newToken
                };

                var newPostJson2 = JsonConvert.SerializeObject(newPost2);
                var payload2 = new StringContent(newPostJson2, Encoding.UTF8, "application/json");
                var result2 = client.PostAsync(endPoint2, payload2).Result.Content.ReadAsStringAsync().Result;
                Console.WriteLine(result2);
                return result2; //publish image on instagram 
            }
        }
    }

}


/*
2nd endPoint = https://graph.facebook.com/v14.0/17841400008460056/media_publish
parameter = creation id (result)
*/
