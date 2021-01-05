using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AngryLab
{
    [CreateAssetMenu(menuName = "AngryLab/Store/Items/Weapon Item", fileName = "Weapon_item")]
    public class SO_Weapon_Item : SO_Item
    {
        [Header("Weapon Settings")]
        [SerializeField] private bool isMelee = false;
        [SerializeField] private bool isPistol;
        [SerializeField, Range(1, 500)] private int damage = 20;
        [SerializeField, Range(0.05f, 0.8f)] private float fireRate = 0.5f;
        [SerializeField] private SO_SoundFX soundFx;

        [Header("Bullet Setup")]
        [SerializeField] internal ProjectileDetails bullet;
        [SerializeField] internal ProjectileDetails specialBullet;

        public virtual bool IsMelee { get { return isMelee; } }
        public virtual bool IsPistol { get { return isPistol; } }
        public virtual int Damage { get { return damage; } }
        public virtual float FireRate { get { return fireRate; } }
        public virtual SO_SoundFX SoundFX { get { return soundFx; } }

    }
}