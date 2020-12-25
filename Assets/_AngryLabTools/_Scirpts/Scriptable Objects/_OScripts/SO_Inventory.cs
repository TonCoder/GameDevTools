using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "AngryLab/Game System/Store and Inv/Inventory")]
public class SO_Inventory : ScriptableObject
{
    [SerializeField] internal List<Ab_BaseItemInfo> list = new List<Ab_BaseItemInfo>();

    internal void Add(Ab_BaseItemInfo item)
    {
        list.Add(item);
    }

    internal void RemoveItem(Ab_BaseItemInfo item)
    {
        list.Remove(item);
    }
}
