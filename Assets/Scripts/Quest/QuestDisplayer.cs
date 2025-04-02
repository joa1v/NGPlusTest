using TMPro;
using UnityEngine;

namespace NGPlus.Quests
{
    public class QuestDisplayer : MonoBehaviour
    {
        [Header("Texts")]
        [SerializeField] private TextMeshProUGUI _titleTMP;
        [SerializeField] private TextMeshProUGUI _descriptionTMP;

        [Header("Animation")]
        [SerializeField] private Animator _animator;
        [SerializeField] private string _appearState;
        [SerializeField] private string _hideState;

        [SerializeField] private float _delayToHide;

        public void ShowQuest(Quest quest)
        {
            _titleTMP.text = quest.Title;
            _descriptionTMP.text = quest.Description;

            _animator.CrossFadeInFixedTime(_appearState, 0);
            WaitToHide();
        }

        private async void WaitToHide()
        {
            await Awaitable.WaitForSecondsAsync(_delayToHide);
            _animator.CrossFadeInFixedTime(_hideState, 0);
        }
    }
}
