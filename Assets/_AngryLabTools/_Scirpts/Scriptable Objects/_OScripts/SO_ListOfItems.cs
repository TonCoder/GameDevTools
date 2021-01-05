using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new List", menuName = "AngryLab/Collections/List Of Objects")]
public class SO_ListOfItems : ScriptableObject
{
    [SerializeField] internal List<GameObject> items = new List<GameObject>();
}
