using UnityEngine;

namespace NGPlus.Interactables
{
    public class InteractableFeedback : MonoBehaviour
    {
        [SerializeField] private GameObject _feedbackObj;

        private void Start()
        {
            Hide();
        }

        public void Show()
        {
            _feedbackObj.SetActive(true);
        }

        public void Hide()
        {
            _feedbackObj.SetActive(false);
        }
    }
}
