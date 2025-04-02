using UnityEngine;
namespace NGPlus.Quests
{
    public interface IQuest
    {
        string Title { get; }
        string Description { get; }
        bool IsCompleted { get; }
        void CheckProgress();
    }
}