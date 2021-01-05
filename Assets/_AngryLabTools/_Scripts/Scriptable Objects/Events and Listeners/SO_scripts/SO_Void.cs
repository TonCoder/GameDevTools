using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NullEvent", menuName = "AngryLab/Game System/Event/Null Event")]
public class SO_Void : AGameEvent<EmptyClass> { }

[System.Serializable]
public class EmptyClass{}