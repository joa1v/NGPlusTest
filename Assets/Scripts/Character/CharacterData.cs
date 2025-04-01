using UnityEngine;

[CreateAssetMenu(fileName = "CharacterData", menuName = "Scriptable Objects/CharacterData")]
public class CharacterData : ScriptableObject
{
    [SerializeField] private float _baseSpeed;
    [SerializeField] private float _baseHealth;

    [SerializeField, Range(1, 2)] private float _runningMultiplier;

    public float BaseSpeed => _baseSpeed;
    public float RunSpeedMultiplier => _runningMultiplier;
    public float BaseHealth => _baseHealth;
}
