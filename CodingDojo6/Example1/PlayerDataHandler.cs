using System;
using System.Collections.Generic;

namespace CodingDojo6
{
    public class PlayerDataHandler
    {
        protected ICloudService cloudService;

        public PlayerDataHandler()
        {
            cloudService = new CloudService();
        }
        
        public Player CreateNewPlayer(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new Exception("New player name can't be empty.");
            }

            return new Player() { name = name };
        }

        public Player LoadPlayerDataFromCloud()
        {
            if (!cloudService.IsConnected)
            {
                throw new Exception("The cloud service has no internet connection, player data can't be loaded.");
            }
            
            Dictionary<string, object> rawData = cloudService.DownloadData();

            return new Player(rawData);
        }

        public bool SavePlayerDataOnCloud(Player toSave)
        {
            if (!cloudService.IsConnected)
            {
                return false;
            }

            return cloudService.SaveData(toSave.GetRawData());
        }
    }
}