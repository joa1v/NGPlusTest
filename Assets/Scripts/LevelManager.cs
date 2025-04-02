using NGPlus.Quests;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Timer _timer;
    [SerializeField] private Quest _collectionQuest;

    private void Start()
    {
        _timer.OnEndTimer += SetDefeat;
    }
    public void SetWin()
    {

    }

    public void SetDefeat()
    {
    }
}
