using System.Collections.Generic;

namespace CodingDojo7.Exercise
{
    public interface IMemoryCard
    {
        void Save(Dictionary<string, object> obj);

        Dictionary<string, object> Load();

        bool ContainsState();
    }
}