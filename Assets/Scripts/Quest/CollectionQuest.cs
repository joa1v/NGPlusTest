using UnityEngine;
using NGPlus.Inventory;

namespace NGPlus.Quests
{
    [CreateAssetMenu(menuName = "Quests/Collection Quest")]
    public class CollectionQuest : Quest
    {
        [SerializeField] private ItemType requiredItem;
        [SerializeField] private int requiredAmount;

        private int currentAmount = 0;

        public void CollectItem(ItemType itemType)
        {
            if (itemType == requiredItem)
            {
                currentAmount++;
                CheckProgress();
            }
        }

        public override void CheckProgress()
        {
            if (currentAmount >= requiredAmount)
            {
                IsCompleted = true;
                Debug.Log($"Quest '{Title}' completa!");
            }
        }
    }
}