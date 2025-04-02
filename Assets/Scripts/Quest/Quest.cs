using UnityEngine;

namespace NGPlus.Quests
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Quest")]
    public abstract class Quest : ScriptableObject, IQuest
    {
        [SerializeField] private string _title;
        [SerializeField] private string _description;

        public string Description => _description;

        public string Title => _title;

        public bool IsCompleted { get; protected set; }

        public abstract void CheckProgress();

    }
}