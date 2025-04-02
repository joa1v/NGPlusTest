using NGPlus.Quests;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Timer _timer;
    [SerializeField] private Quest _collectionQuest;

    [SerializeField] private float _delayToSetWinDefeat;
    private bool _won;
    private bool _lost;

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


        QuestManager.Instance.WatchQuestCompleted(_collectionQuest, SetWin);
        QuestManager.Instance.ActiveQuest(_collectionQuest);
    }

    public void SetWin()
    {
        if (_lost || _won)
            return;

        _won = true;
        Debug.Log("GANHOU");
    }

    public void SetDefeat()
    {
        if (_lost || _won)
            return;

        _lost = true;
        Debug.Log("PERDEU");
    }
}
