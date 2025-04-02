using System;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField, Tooltip("Seconds")] private float _timer;
    private bool _updateTimer = true;
    private float _currentTimer;

    public bool UpdateTimer { get => _updateTimer; set => _updateTimer = value; }
    public float CurretTime => _currentTimer;
    public Action OnEndTimer { get; set; }

    private void Start()
    {
        _currentTimer = _timer;
    }

    private void Update()
    {
        if (!_updateTimer)
            return;

        _currentTimer -= Time.deltaTime;

        if (_currentTimer <= 0)
        {
            OnEndTimer?.Invoke();
            _updateTimer = false;
        }
    }
}
