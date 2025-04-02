using UnityEngine;

namespace NGPlus.Quests
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Quest")]
    public abstract class Quest : ScriptableObject, IQuest
    {
        [SerializeField] private string _title;
        [SerializeField] private string _description;
        [SerializeField] private int _requiredAmount;

        public string Description => _description;

        public string Title => _title;

        public bool IsCompleted { get; protected set; }
        public int RequiredAmount => _requiredAmount;

    }
}