using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using static WPFInsta.GetDetails;

namespace WPFInsta
{
    public class GetDetails
    {
       

        public async Task<string> getDetails()
        {
            Property newpert1 = new Property();
            var newToken1 = ConfigurationManager.AppSettings["fb_token"];

            using (var client = ApiHelper.ApiClient)
            {
                var endPoint4 = new Uri("https://graph.facebook.com/v14.0/17841453651427542/media");
                HttpResponseMessage response = client.GetAsync($"https://graph.facebook.com/v14.0/17841453651427542?fields=id,username,media,followers_count,follows_count,biography&access_token={newToken1}").Result;

                var result = response.Content.ReadAsStringAsync().Result;

                var json = JsonConvert.DeserializeObject<dynamic>(result);

                Console.WriteLine(json);

                return Convert.ToString(json);


            }
        }

        public class Demo
        {
            public string Data { get; set; }
        }

        public class MyId
        {
            public string id { get; set; }
        }

        public class ImageUrl
        {
            public string media_url { get; set; }
        }

        public async void getDataId()
        {
        //    Property newpert1 = new Property();
        //    var newToken1 = ConfigurationManager.AppSettings["fb_token"];

        //    var client = new HttpClient();
        //    HttpResponseMessage response = client.GetAsync($"https://graph.facebook.com/v14.0/17841453651427542?fields=id,username,media,followers_count,follows_count,biography&access_token={newToken1}").Result;

        //    string result = response.Content.ReadAsStringAsync().Result;
        //    Console.WriteLine(result);

        //    var jsonRes = JsonConvert.DeserializeObject<dynamic>(result).media.data;

        //    for (int i = 0; i < 4; i++)
        //    {

        //        MyId jsonr = JsonConvert.DeserializeObject<MyId>(JsonConvert.SerializeObject(jsonRes[i]));
        //        Console.WriteLine(jsonr.id);
        //        string str1 = $"https://graph.facebook.com/v14.0/{jsonr.id}?fields=media_url&access_token={newToken1}";

        //        HttpResponseMessage response1 = client.GetAsync(str1).Result;
        //        string result1 = response1.Content.ReadAsStringAsync().Result;

        //        Console.WriteLine(result1);

        //        ImageUrl url1 = JsonConvert.DeserializeObject<ImageUrl>(result1);

        //        Console.WriteLine(url1.media_url);

        //        // Console.WriteLine(url1.url);
        //        var image = new BitmapImage();
        //        int BytesToRead = 100;

        //        var url2 = url1.media_url;
        //        WebRequest rq = WebRequest.Create(new Uri(url2, UriKind.Absolute));
        //        rq.Timeout = -1;
        //        // rq.ContentLength = BytesToRead;
        //        WebResponse wr = rq.GetResponse();

        //        Stream rs = wr.GetResponseStream();
        //        BinaryReader br = new BinaryReader(rs);
        //        MemoryStream ms = new MemoryStream();
        //        byte[] buffer = new byte[BytesToRead];
        //        int bytesRead = br.Read(buffer, 0, BytesToRead);
        //        //ms.Write(buffer, 0, bytesRead);
        //        while (bytesRead > 0)
        //        {
        //            ms.Write(buffer, 0, bytesRead);
        //            bytesRead = br.Read(buffer, 0, BytesToRead);
        //        }
        //        image.BeginInit();
        //        ms.Seek(0, SeekOrigin.Begin);
        //        image.StreamSource = ms;
        //        image.EndInit();
        //        MainWindow md = new MainWindow();
        //        md.imgData.Source = image;
        //        System.Windows.Controls.Image ImageViewer1 = new System.Windows.Controls.Image();
        //        ImageViewer1.Source = image;
        //        ImageViewer1.Stretch = Stretch.Uniform;
        //        ImageViewer1.Height = 200;
        //        ImageViewer1.Width = 200;
        //        //image1.VerticalAlignment = VerticalAlignment.Center;

        //        //MainWindow md = new MainWindow();
        //        //md.panel_Images.Children.Add(ImageViewer1);
        //        //md.ImageViewer1.Source = image;

        //    }

        }

        //public class Demo
        //{
        //    public string Data { get; set; }
        //}

       
    }
}
