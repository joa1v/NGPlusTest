using UnityEngine;

namespace NGPlus.Interactables
{
    [RequireComponent(typeof(InteractableFeedback))]
    public abstract class Interactable : MonoBehaviour
    {
        [SerializeField] private InteractableFeedback _feedback;
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Interactor interactor))
            {
                interactor.CurrentInteractable = this;
                _feedback.Show();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out Interactor interactor) && interactor.CurrentInteractable == this)
            {
                interactor.CurrentInteractable = null;
                _feedback.Hide();
            }
        }

        public abstract void Interact();

    }
}