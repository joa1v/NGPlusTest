using UnityEngine;

namespace NGPlus.SaveSystem
{
    public interface ISaveable
    {
        void SubscribeToSaveManager();
        void Save();
        void Load();
        string Key { get; set; }
    }
}
