using System;
using UnityEngine;

namespace NGPlus.Dialogue
{
    public class Dialoguer : MonoBehaviour
    {
        [SerializeField] private DialogueData _dialogueData;
        private int _currentLine = 0;

        public Action<string> OnLineStarted { get; set; }
        public Action OnDialogueEnd { get; set; }

        public void StartDialogue()
        {
            if (!_dialogueData || _dialogueData.DialogueLines.Length == 0)
            {
                Debug.LogWarning("No Data or No DialogueLines");
                return;
            }

            string currentLine = _dialogueData.DialogueLines[_currentLine];

            OnLineStarted?.Invoke(currentLine);

            _currentLine++;
            _currentLine = (int)Mathf.Repeat(_currentLine, _dialogueData.DialogueLines.Length);
        }

        public void SetDialogueEnd()
        {
            OnDialogueEnd?.Invoke();
        }
        
    }
}
