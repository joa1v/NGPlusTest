using NGPlus.Dialogue;
using NGPlus.Interactables;
using UnityEngine;

namespace NGPlus.NPCs
{
    public class NPCInteraction : Interactable
    {
        [SerializeField] private Dialoguer _dialoguer;

        private void OnEnable()
        {
            OnInteractorLeft += SetInteractionEnd;
        }

        private void OnDisable()
        {
            OnInteractorLeft -= SetInteractionEnd;
        }

        public override void Interact()
        {
            _feedback.Hide();
            _dialoguer.StartDialogue();
        }

        private void SetInteractionEnd()
        {
            _dialoguer.SetDialogueEnd();
        }
    }
}
