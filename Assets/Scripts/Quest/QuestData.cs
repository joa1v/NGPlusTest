using System;
using UnityEngine;

namespace NGPlus.Quests
{
    [Serializable]
    public class QuestData
    {
        public Quest QuestTemplate { get; private set; }
        public bool IsActive { get; set; }
        public bool IsCompleted { get; set; }
        public int CurrentProgress { get; set; }
        public string Id { get; set; }

        public Action OnQuestCompleted { get; set; }

        public QuestData(Quest questTemplate)
        {
            QuestTemplate = questTemplate;
            Id = questTemplate.Title;
            IsCompleted = false;
            CurrentProgress = 0;
        }

        public void UpdateProgress(int amount)
        {
            if (IsCompleted || !IsActive)
                return;

            CurrentProgress += amount;
            if (CurrentProgress >= QuestTemplate.RequiredAmount)
            {
                IsCompleted = true;
                Debug.Log($"Quest '{QuestTemplate.Title}' completa!");
                OnQuestCompleted?.Invoke();
                IsActive = false;
            }
        }
    }
}
