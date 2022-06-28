using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace CodingDojo8.Exercise
{
    public class TimeService : ITimeService
    {
        private DateTime currentTime;

        public TimeService()
        {
            UpdateTime();
        }

        public void UpdateTime()
        {
            currentTime = GetCurrentTime();
        }
        
        private DateTime GetCurrentTime()
        {
            var client = WebRequest.Create("http://worldtimeapi.org/api/ip");

            var httpResponse = client.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                string result = streamReader.ReadToEnd();
                Dictionary<string, object> data = JsonConvert.DeserializeObject<Dictionary<string, object>>(result);

                return (DateTime)data["utc_datetime"];
            }
        }

        public DateTime CurrentTime => currentTime;
    }
}