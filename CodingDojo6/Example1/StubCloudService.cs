using System.Collections.Generic;

namespace CodingDojo6
{
    public class StubCloudService : ICloudService
    {
        public enum Status
        {
            Connected,
            Error
        }

        public Dictionary<string, object> DataToReturn { get; set; } = new Dictionary<string, object>();

        private Status currentStatus = Status.Connected;

        public void SetStatus(Status status) => currentStatus = status;

        public Dictionary<string, object> DownloadData()
        {
            if (currentStatus == Status.Error)
            {
                return null;
            }

            return DataToReturn;
        }

        public bool SaveData(Dictionary<string, object> data)
        {
            return IsConnected;
        }

        public bool IsConnected => currentStatus == Status.Connected;
    }
}