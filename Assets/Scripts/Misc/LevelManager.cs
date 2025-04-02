using NGPlus.Quests;
using System;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Timer _timer;
    [SerializeField] private Quest _collectionQuest;

    private bool _won;
    private bool _lost;

    public Action OnLevelWin { get; set; }
    public Action OnLevelDefeat { get; set; }

    public void StartLevel()
    {
        _timer.OnEndTimer += SetDefeat;
        AddQuest();
    }

    private void AddQuest()
    {
        bool hasQuest = QuestManager.Instance.CheckHasQuest(_collectionQuest);
        if (!hasQuest)
            QuestManager.Instance.AddQuest(_collectionQuest);

        if (QuestManager.Instance.CheckQuestIsComplete(_collectionQuest))
        {
            _won = true;
            return;
        }

        QuestManager.Instance.WatchQuestCompleted(_collectionQuest, SetWin);
        QuestManager.Instance.ActiveQuest(_collectionQuest);
    }

    [ContextMenu("WIN")]
    public void SetWin()
    {
        if (_lost || _won)
            return;

        _won = true;
        OnLevelWin?.Invoke();
        Time.timeScale = 0;
    }

    [ContextMenu("DEFEAT")]
    public void SetDefeat()
    {
        if (_lost || _won)
            return;

        _lost = true;
        OnLevelDefeat?.Invoke();
        Time.timeScale = 0;
    }
}
