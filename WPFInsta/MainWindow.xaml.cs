using DotNetOpenAuth.AspNet.Clients;
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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static WPFInsta.GetDetails;

namespace WPFInsta
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private int id = 0;
        public MainWindow()
        {

            InitializeComponent();
           // ApiHelper.InitializeClient();
        }

       
        private async void btn1_Click(object sender, RoutedEventArgs e)
        {
            //Console.WriteLine(id);
            //await ID();
            Processor pobj = new Processor();
            var id = await pobj.UploadImage();


            MessageBox.Show("Image Uploaded");
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GetDetails gd = new GetDetails();
            gd.getDataId();
        }

        private async void btn2_Click(object sender, RoutedEventArgs e)
        {

            Property newpert1 = new Property();
            var newToken1 = ConfigurationManager.AppSettings["fb_token"];

            var client = new HttpClient();
            HttpResponseMessage response = client.GetAsync($"https://graph.facebook.com/v14.0/17841453651427542?fields=id,username,media,followers_count,follows_count,biography&access_token={newToken1}").Result;

            string result = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(result);

            var jsonRes = JsonConvert.DeserializeObject<dynamic>(result).media.data;

            for (int i = 0; i < 3; i++)
            {

                MyId jsonr = JsonConvert.DeserializeObject<MyId>(JsonConvert.SerializeObject(jsonRes[i]));
                Console.WriteLine(jsonr.id);
                string str1 = $"https://graph.facebook.com/v14.0/{jsonr.id}?fields=media_url&access_token={newToken1}";

                HttpResponseMessage response1 = client.GetAsync(str1).Result;
                string result1 = response1.Content.ReadAsStringAsync().Result;

                Console.WriteLine(result1);

                ImageUrl url1 = JsonConvert.DeserializeObject<ImageUrl>(result1);

                Console.WriteLine(url1.media_url);

                // Console.WriteLine(url1.url);
                var image = new BitmapImage();
                int BytesToRead = 100;

                var url2 = url1.media_url;
                WebRequest rq = WebRequest.Create(new Uri(url2, UriKind.Absolute));
                rq.Timeout = -1;
                // rq.ContentLength = BytesToRead;
                WebResponse wr = rq.GetResponse();

                Stream rs = wr.GetResponseStream();
                BinaryReader br = new BinaryReader(rs);
                MemoryStream ms = new MemoryStream();
                byte[] buffer = new byte[BytesToRead];
                int bytesRead = br.Read(buffer, 0, BytesToRead);
                //ms.Write(buffer, 0, bytesRead);
                while (bytesRead > 0)
                {
                    ms.Write(buffer, 0, bytesRead);
                    bytesRead = br.Read(buffer, 0, BytesToRead);
                }
                image.BeginInit();
                ms.Seek(0, SeekOrigin.Begin);
                image.StreamSource = ms;
                image.EndInit();

                //imgData.Source = image;
                Image Image1 = new Image();
                Image1.Source = image;
                Image1.Stretch = Stretch.Uniform;
                Image1.Height = 200;
                Image1.Width = 200;

                panel_Images.Children.Add(Image1);
                //image1.VerticalAlignment = VerticalAlignment.Center;

                //MainWindow md = new MainWindow();
               
               //md.ImageViewer1.Source = image;

            }



            //GetDetails gd = new GetDetails();
            //var jsondata = await gd.getDetails();


            //gd.getDataId();


            //MessageBox.Show("Data Showed");
        }
    }


}
