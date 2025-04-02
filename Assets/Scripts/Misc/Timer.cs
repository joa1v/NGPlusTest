using NGPlus.SaveSystem;
using System;
using UnityEngine;

public class Timer : MonoBehaviour, ISaveable
{
    [SerializeField, Tooltip("Seconds")] private float _timer;
    private bool _updateTimer;
    private float _currentTimer;

    public bool UpdateTimer { get => _updateTimer; set => _updateTimer = value; }
    public float CurretTime => _currentTimer;
    public Action OnEndTimer { get; set; }
    public string Key { get; set; } = "timer";

    private void Awake()
    {
        SubscribeToSaveManager();
    }

    public void StartTimer()
    {
        Load();
        _updateTimer = true;
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

    public void Save()
    {
        PlayerPrefs.SetFloat(Key, _currentTimer);
    }

    public void Load()
    {
        _timer = PlayerPrefs.GetFloat(Key, _timer);
    }

    public void SubscribeToSaveManager()
    {
        SaveManager.OnSave += Save;
        SaveManager.OnLoad += Load;
    }
}
