using UnityEngine;
using NGPlus.Singleton;
using System.Collections.Generic;
using System;
using System.Linq;

namespace NGPlus.Quests
{
    public class QuestManager : Singleton<QuestManager>
    {
        [SerializeField] private QuestDisplayer _displayer;
        private List<QuestData> _activeQuests = new List<QuestData>();

        public void AddQuest(Quest quest, QuestData questData = null)
        {
            if (questData == null)
            {
                questData = new QuestData(quest);
            }

            _activeQuests.Add(questData);
        }

        public bool CheckHasQuest(Quest quest)
        {
            var questData = _activeQuests.FirstOrDefault(q => q.QuestTemplate == quest);
            return questData != null;
        }

        public void WatchQuestCompleted(Quest quest, Action action)
        {
            QuestData questData = _activeQuests.Find(q => q.QuestTemplate == quest);
            if (questData != null)
            {
                questData.OnQuestCompleted += action;
            }
        }

        public void UnwatchQuestCompleted(Quest quest, Action action)
        {
            QuestData questData = _activeQuests.Find(q => q.QuestTemplate == quest);
            if (questData != null)
            {
                questData.OnQuestCompleted -= action;
            }
        }

        public bool CheckQuestIsActive(Quest quest)
        {
            QuestData questData = _activeQuests.Find(q => q.QuestTemplate == quest);
            if (questData != null)
            {
                return questData.IsActive;
            }

            return false;
        }

        public void ActiveQuest(Quest quest)
        {
            QuestData questData = _activeQuests.Find(q => q.QuestTemplate == quest);
            if (questData != null)
            {
                questData.IsActive = true;
            }

            _displayer.ShowQuest(quest);
        }

        public void UpdateQuestProgress(Quest quest, int amount)
        {
            QuestData questData = _activeQuests.Find(q => q.QuestTemplate == quest);
            if (questData != null)
            {
                questData.UpdateProgress(amount);
            }
        }

        public List<QuestData> GetActiveQuests()
        {
            return _activeQuests;
        }

        public void ClearQuests()
        {
            _activeQuests.Clear();
        }

    }
}
