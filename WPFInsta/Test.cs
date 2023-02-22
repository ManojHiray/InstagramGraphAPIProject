using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFInsta
{
    public class Test
    {
       
        public string image_url { get; set; }
        public string caption { get; set; }
        public string access_token { get; set; }
        
    }

    public class Post
    {
        public string creation_id { get; set; }
        public string access_token { get; set; }
    }

    public class Container
    {
        public string id { get; set; }
    }
}
