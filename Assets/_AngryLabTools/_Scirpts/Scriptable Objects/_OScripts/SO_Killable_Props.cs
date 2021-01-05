using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

namespace AngryLab
{
    [CreateAssetMenu(fileName = "Killable Props", menuName = "AngryLab/Killable/Props")]
    public class SO_Killable_Props : ScriptableObject
    {
        [SerializeField, Range(0.2f, 1f)] private float _despawnTime = 0.5f;
        [SerializeField] private bool _isPlayer = false;
        [SerializeField, Range(100, 1000)] private float _hp = 100;
        [SerializeField, Range(100, 1000)] private float _maxHp = 100;
        [SerializeField, Range(0, 1000)] private float _armor = 0;
        [SerializeField, Range(100, 1000)] private float _maxArmor = 500;
        [SerializeField, Range(1, 15f)] private float _moveSpeed = 10;
        [SerializeField, Range(1, 15f)] private float _turnSpeed = 10;
        [SerializeField, TextArea(3, 5)] private string _desc = "";
        [SerializeField] private SO_SoundFX _hitSoundFx;
        [SerializeField] private SO_SoundFX _deathSoundFx;
        [SerializeField] private SO_SoundFX _healSoundFx;
        [SerializeField] private List<Skills> _skills;

        public bool IsPlayer { get { return _isPlayer; } }
        public float HP { get { return _hp; } }
        public float MaxHP { get { return _maxHp; } }
        public float Armor { get { return _armor; } }
        public float MaxArmor { get { return _maxArmor; } }
        public float DespawnTime { get { return _despawnTime; } }
        public float MoveSpeed { get { return _moveSpeed; } }
        public float TurnSpeed { get { return _turnSpeed; } }
        public string Desc { get { return _desc; } }
        public SO_SoundFX HitSoundFX { get { return _hitSoundFx; } }
        public SO_SoundFX DeathSoundFx { get { return _deathSoundFx; } }
        public SO_SoundFX HealSoundFx { get { return _healSoundFx; } }
        public List<Skills> Skills { get { return _skills; } }


        //internal void CreateNewKillableProp()
        //{
        //    SO_Killable_Props newAsset = ScriptableObject.CreateInstance<SO_Killable_Props>();
        //    SaveToAssetDB(newAsset);
        //}

        //internal void SaveToAssetDB(SO_Killable_Props asset)
        //{
        //    string killableAssetPath = "";
        //    AssetDatabase.CreateAsset(asset, killableAssetPath);
        //}

    }
}