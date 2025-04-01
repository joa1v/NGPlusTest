using UnityEngine;

namespace NGPlus.Dialogue
{
    [CreateAssetMenu(fileName = "DialogueData", menuName = "Scriptable Objects/DialogueData")]
    public class DialogueData : ScriptableObject
    {
        [SerializeField] private string[] _dialogueLines;

        public string[] DialogueLines => _dialogueLines;
    }
}