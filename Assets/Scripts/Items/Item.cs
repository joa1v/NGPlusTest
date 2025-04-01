using NGPlus.Interactables;
using UnityEngine;

namespace NGPlus.Item
{
    public class Item : Interactable
    {
        public override void Interact()
        {
            gameObject.SetActive(false);
        }
    }
}