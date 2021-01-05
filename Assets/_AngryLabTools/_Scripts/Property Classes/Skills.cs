using UnityEngine;

[System.Serializable]
public class Skills
{
    [SerializeField] internal string name;
    [SerializeField, Tooltip("Set either damage or other this skill does")] internal float value;
    [SerializeField] internal float cooldown;
}