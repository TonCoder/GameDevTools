using UnityEngine;

namespace AngryLab
{
    [CreateAssetMenu(menuName = "AngryLab/Game System/Settings/GameSettings", fileName = "Game Settings")]
    public class SO_GeneralSettings : ScriptableObject
    {
        [SerializeField, TextArea(3, 5)] internal string _info = "";
        [SerializeField] internal string _fbLink = "facebook.com";
        [SerializeField] internal string _tweetLink = "twitter.com";
        [SerializeField] internal string _store = "storeName";
    }
}