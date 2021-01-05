using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AngryLab
{
    [CreateAssetMenu(fileName = "New Item", menuName = "AngryLab/Inventory/Inventory")]
    public class SO_Inventory : ScriptableObject
    {
        [SerializeField] internal List<SO_Item> list = new List<SO_Item>();

        internal void Add(SO_Item item)
        {
            list.Add(item);
        }

        internal void RemoveItem(SO_Item item)
        {
            list.Remove(item);
        }
    }
}