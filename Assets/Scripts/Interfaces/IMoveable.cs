using UnityEngine;

public interface IMoveable
{
    float Speed { get; set; }
    Vector3 MovementDirection { get; set; }

    void Move();
    void SetSpeed();
}
