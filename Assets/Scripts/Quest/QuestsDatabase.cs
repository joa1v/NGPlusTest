using UnityEngine;
using NGPlus.Singleton;
using NGPlus.Inventory;
using System.Linq;

namespace NGPlus.Quests
{
    public class QuestsDatabase : Singleton<QuestsDatabase>
    {
        [SerializeField] private string _questsPath;
        [SerializeField] private Quest[] _quests;

        public Quest GetQuestByID(string id)
        {
            return _quests.Where(x => x.Title == id).FirstOrDefault();
        }

        private void OnValidate()
        {
            _quests = Resources.LoadAll<Quest>(_questsPath).ToArray();
        }
    }
}
