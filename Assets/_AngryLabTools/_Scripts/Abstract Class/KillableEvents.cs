using UnityEngine;
using UnityEngine.Events;

namespace AngryLab
{
    /// <summary>
    /// This killable Events script helps to separate the Events from the main Killable controller, which will help calling any
    /// other script upon its trigger.
    /// </summary>
    public class KillableEvents : MonoBehaviour
    {
        [Space(10), Header("Event setup")]
        [SerializeField] internal UEvents.EBool InitEvent;
        [SerializeField] internal UEvents.EVector2 damageEvent;
        [SerializeField] internal UEvents.EVector2 deathEvent;
        [SerializeField] internal UEvents.EVector2 addHealthEvent;
    }
}