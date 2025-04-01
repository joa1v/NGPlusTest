using NGPlus.Interactables;
using UnityEngine;

namespace NGPlus.Item
{
    public class ItemInteraction : Interactable
    {
        public override void Interact()
        {
            gameObject.SetActive(false);
        }
    }
}