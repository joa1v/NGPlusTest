using TMPro;
using UnityEngine;

namespace NGPlus.Dialogue
{
    [RequireComponent(typeof(Dialoguer))]
    public class DialoguerDisplayer : MonoBehaviour
    {
        [SerializeField] private Dialoguer _dialoguer;
        [SerializeField] private GameObject _dialogueDisplayObj;
        [SerializeField] private TextMeshProUGUI _dialogueTMP;
        private void OnEnable()
        {
            if (!_dialoguer) _dialoguer = GetComponent<Dialoguer>();

            EndDialogue();

            _dialoguer.OnLineStarted += DisplayDialogue;
            _dialoguer.OnDialogueEnd += EndDialogue;
        }

        private void OnDisable()
        {
            _dialoguer.OnLineStarted -= DisplayDialogue;
            _dialoguer.OnDialogueEnd -= EndDialogue;
        }

        private void DisplayDialogue(string line)
        {
            _dialogueDisplayObj.SetActive(true);

            _dialogueTMP.text = line;
        }

        private void EndDialogue()
        {
            _dialogueDisplayObj.SetActive(false);
        }
    }

}