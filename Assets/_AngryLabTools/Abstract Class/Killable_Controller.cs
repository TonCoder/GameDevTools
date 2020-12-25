using System.Collections.Generic;
using UnityEngine;

namespace AngryLab
{
    [RequireComponent(typeof(AudioSource), typeof(KillableEvents))]
    public abstract class Killable_Controller : MonoBehaviour
    {
        [SerializeField] internal SO_Killable _properties;

        [Space(10), Header("Other Settings")]
        [SerializeField] internal AudioSource _asource;

        [SerializeField] private KillableEvents killableEvents;

        internal float killableHp;
        internal float killableMaxHp;
        internal float killableArmor;
        internal float killableMaxArmor;

        protected virtual void Awake()
        {
            killableHp = _properties.HP;
            killableMaxHp = _properties.MaxHP;
            killableArmor = _properties.Armor;
            killableMaxArmor = _properties.MaxArmor;
        }

        protected virtual void Start()
        {
            _asource = _asource ? _asource : GetComponent<AudioSource>();
        }

        protected abstract void Update();

        protected virtual void OnEnable() {
            killableEvents.damageEvent.AddListener((value) => HitFx());
            killableEvents.deathEvent.AddListener((value) => DeathFx());
            killableEvents.addHealthEvent.AddListener((value) => { AddHealth(value.y); HealFx(); });
        }

        protected virtual void OnDisable()
        {
            killableEvents.deathEvent.RemoveAllListeners();
            killableEvents.damageEvent.RemoveAllListeners();
            killableEvents.addHealthEvent.RemoveAllListeners();
        }

        public virtual void TakeDamage(float damage)
        {
            killableHp -= HitArmor(damage);
            if (killableHp <= 0)
            {
                killableHp = 0;
                killableEvents.deathEvent?.Invoke(new Vector2(killableHp, killableMaxHp));
            }
            killableEvents.damageEvent?.Invoke(new Vector2(killableHp, killableMaxHp));
        }

        public virtual void AddHealth(float value)
        {
            killableArmor += value;
            if (killableArmor >= killableMaxHp)
            {
                killableArmor = killableMaxHp;
            }
            killableEvents.addHealthEvent?.Invoke(new Vector2(killableHp, killableMaxHp));
        }

        private float HitArmor(float damage)
        {
            float damageDone = killableArmor - damage;
            if ((killableArmor - damage) < 0)
            {
                killableArmor = 0;
                return Mathf.Abs(damageDone);
            }
            return 0;
        }


        public virtual void AddArmor(float value)
        {
            killableHp += value;
            if (killableHp >= killableMaxArmor)
            {
                killableHp = killableMaxArmor;
            }
        }

        internal void HealFx()
        {
            if (_properties.HitSoundFX == null) return;
            PlaySound(_properties.HealSoundFx.Clip.Count, _properties.HealSoundFx.Pitch, _properties.HealSoundFx.Clip, _properties.HealSoundFx.Volume);
        }

        internal virtual void HitFx()
        {
            if (_properties.HitSoundFX == null) return;
            PlaySound(_properties.HitSoundFX.Clip.Count, _properties.HitSoundFX.Pitch, _properties.HitSoundFX.Clip, _properties.HitSoundFX.Volume);
        }

        internal virtual void DeathFx()
        {
            if (_properties.DeathSoundFx == null) return;
            PlaySound(_properties.DeathSoundFx.Clip.Count, _properties.DeathSoundFx.Pitch, _properties.DeathSoundFx.Clip, _properties.DeathSoundFx.Volume);
        }

        void PlaySound(int count, Vector2 pitchRange, List<AudioClip> clip, float volume)
        {
            _asource.Stop();
            int randomInt = Random.Range(0, count);
            _asource.pitch = Random.Range(pitchRange.x, pitchRange.y);
            _asource.PlayOneShot(clip[randomInt], volume);
        }

        Color GetRed() =>  Color.red;
        Color GetGreen() =>  Color.green;

    }
}