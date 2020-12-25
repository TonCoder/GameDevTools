using UnityEngine;
using UnityEngine.Events;

namespace AngryLab
{
    public class KillableEvents : MonoBehaviour
    {
        [Space(10), Header("Event setup")]
        [SerializeField] internal UEvents.EBool InitEvent;
        [SerializeField] internal UEvents.EVector2 damageEvent;
        [SerializeField] internal UEvents.EVector2 deathEvent;
        [SerializeField] internal UEvents.EVector2 addHealthEvent;
    }
}