using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace DinhXuanGiang_5951071019
{
    public partial class UTC2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var request = WebRequest.Create("https://graph.facebook.com/utc2hcmc/posts?access_token=EAAAAZAw4FxQIBAP3ZAw9ZCtHidm9HPsToDxszZBXHDxZBnvA0WIUw1ZBlvbfPOdXxnWZBG9Lawg5gH9plZATZCA8Uw0x2nhZB5nRIyWswZCZBmrcdPBOIbzobBBJzgdvqGfVxsTFBBBEWnfN7Gnhl3ZBVtc6stBQZBmEPVR1qkuLQUBcZCucwZDZD");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseString = reader.ReadToEnd();
            dynamic jsonData = JsonConvert.DeserializeObject(responseString);
            var results = new List<InfoPost>();
            foreach (var item in jsonData.data)
            {

                results.Add(new InfoPost
                {
                    Time = item.created_time,
                    Content = item.message,
                    Link = item.actions[0].link,
                });
            }
            string s = "";
            for (int i = 0; i < 3; i++)
            {
                s += "<b>Post " + (i + 1) + ": </b>" + "</br>";
                s += "<b>Time: </b>" + results[i].Time + "</br>";
                s += "<b>Content: </b>" + results[i].Content + "</br>";
                s += "<b>Link post: </b>" + results[i].Link + "</br>";
            }

            lbResult.Text = s;

        }
    }
}