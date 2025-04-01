using UnityEngine;
using UnityEngine.InputSystem;

namespace NGPlus.Interactables
{
    public class Interactor : MonoBehaviour
    {
        public Interactable CurrentInteractable { get; set; }

        public void Interact(InputAction.CallbackContext context)
        {
            CurrentInteractable?.Interact();
        }
    }
}