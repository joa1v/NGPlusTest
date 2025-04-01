using Codice.CM.Common;
using UnityEngine;
using UnityEngine.InputSystem;

namespace NGPlus.Character
{
    public class PlayerMovement : CharacterMovement
    {
        [SerializeField] private CharacterController _controller;

        private Vector3 _movementInput;
        private Transform _cameraTransform;
        private float _gravity = -9.8f;
        private Vector3 _velocity;

        private void Start()
        {
            _cameraTransform = Camera.main.transform;
        }

        private void FixedUpdate()
        {
            Move();
            ApplyGravity();
        }

        public void SetMovementDirection(InputAction.CallbackContext context)
        {
            var input = context.ReadValue<Vector2>();
            _movementInput = new Vector3(input.x, 0, input.y);
        }

        public void SetIsRunning(InputAction.CallbackContext context)
        {
            IsRunning = context.ReadValue<float>() > 0;
            SetSpeed();
        }

        public override void Move()
        {
            Vector3 cameraForward = _cameraTransform.forward;
            Vector3 cameraRight = _cameraTransform.right;
            cameraForward.y = 0;
            cameraRight.y = 0;
            cameraForward.Normalize();
            cameraRight.Normalize();

            MovementDirection = (cameraForward * _movementInput.z + cameraRight * _movementInput.x).normalized;

            SetRotation();
            _controller.Move(MovementDirection * Speed * Time.fixedDeltaTime);
        }

        private void ApplyGravity()
        {
            if (_controller.isGrounded)
            {
                _velocity.y = -2f;
            }
            else
            {
                _velocity.y += _gravity * Time.fixedDeltaTime;
            }

            _controller.Move(_velocity * Time.fixedDeltaTime);
        }

        public override void SetRotation()
        {
            if (MovementDirection.sqrMagnitude > 0.01f)
            {
                Quaternion targetRotation = Quaternion.LookRotation(MovementDirection);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
            }
        }
    }
}
