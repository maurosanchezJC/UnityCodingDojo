using System.Collections.Generic;

namespace CodingDojo6.Exercise
{
    public class SpawnManager
    {
        private TimeService timeService;
        private List<ISpawnable> registries;

        public SpawnManager()
        {
            timeService = new TimeService();
        }
        
        public void Register(ISpawnable spawnable)
        {
            if (!registries.Contains(spawnable))
            {
                return;
            }
            
            registries.Add(spawnable);
        }

        public void Unregister(ISpawnable spawnable)
        {
            if (!registries.Contains(spawnable))
            {
                return;
            }

            registries.Remove(spawnable);
        }

        public List<ISpawnable> GetSpawnables()
        {
            List<ISpawnable> toReturn = new List<ISpawnable>();
            int currentHour = timeService.CurrentTime.Hour;
            
            foreach (ISpawnable spawnable in registries)
            {
                if (spawnable.CanSpawn(currentHour))
                {
                    toReturn.Add(spawnable);
                }
            }

            return toReturn;
        }
        
    }
}