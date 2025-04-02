using System;
using UnityEngine;

namespace NGPlus.Interactables
{
    [RequireComponent(typeof(InteractableFeedback))]
    [RequireComponent(typeof(Collider))]
    public abstract class Interactable : MonoBehaviour
    {
        [SerializeField] protected InteractableFeedback _feedback;

        public Action OnInteractorLeft { get; set; }
        public Action OnInteracted { get; set; }

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

                OnInteractorLeft?.Invoke();
            }
        }

        public virtual void Interact()
        {
            OnInteracted?.Invoke();
        }

    }
}