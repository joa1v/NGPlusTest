using UnityEngine;

namespace NGPlus.SaveSystem
{
    public class ObjectStateSetter : MonoBehaviour
    {
        private string _key;

        private void Awake()
        {
            _key = GenerateUniqueKey();
            int state = PlayerPrefs.GetInt(_key, 1);
            gameObject.SetActive(state == 1);
        }

        private void OnDestroy()
        {
            SaveState();
        }

        private void SaveState()
        {
            PlayerPrefs.SetInt(_key, gameObject.activeSelf ? 1 : 0);
            PlayerPrefs.Save();
        }

        private string GenerateUniqueKey()
        {
            return $"ObjectState_{gameObject.scene.name}_{gameObject.name}_{transform.GetSiblingIndex()}";
        }
    }
}
