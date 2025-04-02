using UnityEngine;
using NGPlus.Singleton;
using NUnit.Framework.Interfaces;
using System.Collections.Generic;
using System;

namespace NGPlus.Quests
{
    public class QuestManager : Singleton<QuestManager>
    {
        [SerializeField] private QuestDisplayer _displayer;
        private List<QuestData> activeQuests = new List<QuestData>();

        public void AddQuest(Quest questTemplate)
        {
            QuestData newQuest = new QuestData(questTemplate);
            activeQuests.Add(newQuest);
        }

        public void WatchQuestCompleted(Quest quest, Action action)
        {
            QuestData questData = activeQuests.Find(q => q.QuestTemplate == quest);
            if (questData != null)
            {
                questData.OnQuestCompleted += action;
            }
        }

        public void UnwatchQuestCompleted(Quest quest, Action action)
        {
            QuestData questData = activeQuests.Find(q => q.QuestTemplate == quest);
            if (questData != null)
            {
                questData.OnQuestCompleted -= action;
            }
        }

        public bool CheckQuestIsActive(Quest quest)
        {
            QuestData questData = activeQuests.Find(q => q.QuestTemplate == quest);
            if (questData != null)
            {
                return questData.IsActive;
            }

            return false;
        }

        public void ActiveQuest(Quest quest)
        {
            QuestData questData = activeQuests.Find(q => q.QuestTemplate == quest);
            if (questData != null)
            {
                questData.IsActive = true;
            }

            _displayer.ShowQuest(quest);
        }

        public void UpdateQuestProgress(Quest quest, int amount)
        {
            QuestData questData = activeQuests.Find(q => q.QuestTemplate == quest);
            if (questData != null)
            {
                questData.UpdateProgress(amount);
            }
        }

    }
}
