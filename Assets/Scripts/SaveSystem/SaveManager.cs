using System.Collections.Generic;
using System;
using UnityEngine;
using NGPlus.Quests;
using NGPlus.Inventory;
using NGPlus.Singleton;
using NUnit.Framework.Interfaces;

namespace NGPlus.SaveSystem
{
    [Serializable]
    public class GameData
    {
        public List<InventoryItemData> InventoryItems = new List<InventoryItemData>();
        public List<QuestSaveData> ActiveQuests = new List<QuestSaveData>();
    }

    [Serializable]
    public class InventoryItemData
    {
        public string ItemID;
        public int Quantity;
    }

    [Serializable]
    public class QuestSaveData
    {
        public string QuestId;
        public bool IsActive;
        public bool IsCompleted;
        public int CurrentProgress;
    }

    public class SaveManager
    {
        private const string SaveKey = "GameData";

        public static Action OnSave { get; set; }
        public static Action OnLoad { get; set; }

        public static void SaveGame()
        {
            GameData data = new GameData();

            foreach (var item in InventoryManager.Instance.Items)
            {
                data.InventoryItems.Add(new InventoryItemData { ItemID = item.Key.ItemName, Quantity = item.Value });
            }

            foreach (var quest in QuestManager.Instance.GetActiveQuests())
            {
                data.ActiveQuests.Add(new QuestSaveData { QuestId = quest.Id, IsActive = quest.IsActive, IsCompleted = quest.IsCompleted, CurrentProgress = quest.CurrentProgress });
            }

            string json = JsonUtility.ToJson(data);
            PlayerPrefs.SetString(SaveKey, json);
            PlayerPrefs.Save();

            OnSave?.Invoke();
        }

        public static void LoadGame()
        {
            if (!PlayerPrefs.HasKey(SaveKey))
                return;

            string json = PlayerPrefs.GetString(SaveKey);
            GameData data = JsonUtility.FromJson<GameData>(json);

            InventoryManager.Instance.ClearInventory();
            foreach (var itemData in data.InventoryItems)
            {
                var item = ItemsDatabase.Instance.GetItemByID(itemData.ItemID);
                if (item != null)
                {
                    for (int i = 0; i < itemData.Quantity; i++)
                    {
                        InventoryManager.Instance.AddItem(item);
                    }
                }
            }

            QuestManager.Instance.ClearQuests();
            foreach (var questSaveData in data.ActiveQuests)
            {
                var quest = QuestsDatabase.Instance.GetQuestByID(questSaveData.QuestId);

                var questData = new QuestData(quest);
                questData.IsActive = questSaveData.IsActive;
                questData.CurrentProgress = questSaveData.CurrentProgress;
                questData.IsCompleted = questSaveData.IsCompleted;

                QuestManager.Instance.AddQuest(quest, questData);
            }

            OnLoad?.Invoke();
        }
    }
}
