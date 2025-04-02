using TMPro;
using UnityEngine;

public class TimerDisplayer : MonoBehaviour
{
    [SerializeField] private Timer _timer;
    [SerializeField] private TextMeshProUGUI _timerTMP;

    private void Update()
    {
        int minutes = (int)_timer.CurretTime / 60;
        int seconds = (int)_timer.CurretTime % 60;
        _timerTMP.text = $"{minutes}:{seconds}";
    }
}
