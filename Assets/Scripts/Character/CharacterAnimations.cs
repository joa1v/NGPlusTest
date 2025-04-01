using Unity.VisualScripting.YamlDotNet.Core.Tokens;
using UnityEngine;
using UnityEngine.InputSystem;

namespace NGPlus.Character
{
    public class CharacterAnimations : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private string _movementParameter;

        private bool _isRunning;
        private bool _isMoving;

        public void SetMovement(InputAction.CallbackContext context)
        {
            var input = context.ReadValue<Vector2>();
            _isMoving = input.magnitude > 0;

            SetMovement();
        }

        public void SetIsRunning(InputAction.CallbackContext context)
        {
            _isRunning = context.ReadValue<float>() > 0;
            SetMovement();
        }

        private void SetMovement()
        {
            if (!_isMoving)
            {
                _animator.SetFloat(_movementParameter, 0);
                return;
            }

            float movementValue = _isRunning ? 1 : .5f;
            _animator.SetFloat(_movementParameter, movementValue);
        }
    }
}
