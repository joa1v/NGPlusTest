using UnityEngine;

[RequireComponent(typeof(Character))]
public abstract class CharacterMovement : MonoBehaviour, IMoveable
{
    [SerializeField] protected Character _character;
    [SerializeField] protected float _rotationSpeed;
    public float Speed { get; set; }
    public Vector3 MovementDirection { get; set; }
    public bool IsRunning { get; set; }

    private void OnEnable()
    {
        SetSpeed();
    }

    public abstract void Move();
    public abstract void SetRotation();

    public virtual void SetSpeed()
    {
        if (!_character)
        {
            _character = GetComponent<Character>();
        }

        Speed = IsRunning ? _character.RunSpeed : _character.Speed;
    }
}
