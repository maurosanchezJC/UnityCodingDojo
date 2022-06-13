using System.Collections.Generic;

namespace CodingDojo6
{
    public interface ICloudService
    {
        Dictionary<string, object> DownloadData();

        bool SaveData(Dictionary<string, object> data);
        
        bool IsConnected { get; }
    }
}