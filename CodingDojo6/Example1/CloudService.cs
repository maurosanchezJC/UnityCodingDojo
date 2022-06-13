using System.Collections.Generic;

namespace CodingDojo6
{
    public class CloudService : ICloudService
    {
        public Dictionary<string, object> DownloadData()
        {
            //This service will have internet connection and will point the server to download the data.
            return new Dictionary<string, object>();
        }

        public bool SaveData(Dictionary<string, object> data)
        {
            //This service will have internet connection and will point the server to save the data.
            return true;
        }

        //This property will check if the service has internet connection
        public bool IsConnected => true;
    }
}