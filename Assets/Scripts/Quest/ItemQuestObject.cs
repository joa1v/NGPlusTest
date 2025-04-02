using NGPlus.Inventory;
using NGPlus.Item;
using UnityEngine;

namespace NGPlus.Quests
{
    public class ItemQuestObject : QuestObject
    {
        [SerializeField] private Quest _quest;
        [SerializeField] private ItemInteraction _itemInteraction;
        [SerializeField] private ItemType _type;

        private void OnEnable()
        {
            _itemInteraction.OnInteracted += UpdateQuest;
        }

        private void OnDisable()
        {
            _itemInteraction.OnInteracted -= UpdateQuest;
        }

        protected override void UpdateQuest()
        {
            if (!QuestManager.Instance.CheckQuestIsActive(_quest))
                return;

            QuestManager.Instance.UpdateQuestProgress(_quest, 1);
        }
    }
}
