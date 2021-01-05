using System;
using System.Collections.Generic;
using UnityEngine;

namespace AngryLab
{
    [CreateAssetMenu(menuName = "AngryLab/Settings/GameSettings", fileName = "Game Settings")]
    public class SO_GeneralSettings : ScriptableObject
    {
        [SerializeField] internal int musicVol = 20;
        [SerializeField] internal int fxVol = 20;
        [SerializeField] internal string dateTimeVal = DateTime.Now.ToString("HHmmss");
        [SerializeField] internal List<GameScore> gameScore = new List<GameScore>();
    }

    [System.Serializable]
    public class GameScore
    {
        public string name;
        public int score;
    }
}