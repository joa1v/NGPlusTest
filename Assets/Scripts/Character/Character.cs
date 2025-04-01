using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private CharacterData _data;
    public float Speed => GetSpeed();
    public float RunSpeed => Speed * _data.RunSpeedMultiplier;

    protected float GetSpeed()
    {
        return _data.BaseSpeed;
    }
}
