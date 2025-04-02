using System;
using UnityEngine;

namespace NGPlus.Interactables
{
    [RequireComponent(typeof(InteractableFeedback))]
    [RequireComponent(typeof(Collider))]
    public abstract class Interactable : MonoBehaviour
    {
        [SerializeField] protected InteractableFeedback _feedback;
        protected Interactor _interactor;
        public Action OnInteractorLeft { get; set; }
        public Action OnInteracted { get; set; }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Interactor interactor) && !interactor.CurrentInteractable)
            {
                _interactor = interactor;
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

                _interactor = null;
                OnInteractorLeft?.Invoke();
            }
        }

        private void OnDisable()
        {
            CheckRemoveAsInteractable();
        }

        private void CheckRemoveAsInteractable()
        {
            if (_interactor && _interactor.CurrentInteractable == this)
            {
                _interactor.CurrentInteractable = null;
            }
        }

        public virtual void Interact()
        {
            OnInteracted?.Invoke();
        }

    }
}