using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AngryLab
{
    [CreateAssetMenu(fileName = "new List", menuName = "AngryLab/Game System/Items/List Of Objects")]
    public class SO_ListOfItems : ScriptableObject
    {
        [SerializeField] internal List<Ab_BaseItemInfo> items = new List<Ab_BaseItemInfo>();
    }
}