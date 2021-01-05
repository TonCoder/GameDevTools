using UnityEngine;

namespace AngryLab
{
    public class FireWeapon : MonoBehaviour
    {
        [SerializeField] internal bool _autoFire;
        [SerializeField] internal bool _isEnemyCharacter = true;
        [SerializeField] private AudioSource _asource;

        [Space]
        [SerializeField] private UEvents.EBase OnFiring;
        WeaponInfo _activeWeapon;

        private bool _canFire;
        float _fireSpeed = 0;
        private float _weaponOveralDamage;
        private string _bulletType;

        private void Start()
        {
            _asource = GetComponent<AudioSource>();
        }

        // Update is called once per frame
        void Update()
        {
            _fireSpeed += Time.deltaTime;
            if (_canFire && !_autoFire && _fireSpeed > _activeWeapon.details.FireRate)
            {
                InstantiateBullet();
                _fireSpeed = 0;
            }
            else if (_autoFire && _fireSpeed > _activeWeapon.details.FireRate)
            {
                InstantiateBullet();
                _fireSpeed = 0;
            }
        }

        public void SetFireWeaponValues(WeaponInfo activeWeapon)
        {
            if (activeWeapon != null)
            {
                _weaponOveralDamage = activeWeapon.details.Damage;
                _bulletType = activeWeapon.details.bullet.type.ToString();
                _activeWeapon = activeWeapon;
            }
        }

        public void CanFire(bool value)
        {
            _canFire = value;
        }

        void InstantiateBullet()
        {
            GameObject bullet;
            // TONY - Adjust this to check for pool manager else instantiate
            if (SimplePoolManager.instance != null)
            {
                bullet = SimplePoolManager.instance.GetNextAvailablePoolItem(_bulletType);
                if (bullet == null) return;
                bullet.GetComponent<ProjectileDetails>().SetProperties(_weaponOveralDamage, 0, 0, _isEnemyCharacter);
                bullet.transform.SetPositionAndRotation(_activeWeapon.shootingPoint.position, _activeWeapon.shootingPoint.rotation);
                bullet.SetActive(true);
            }
            else
            {
                Instantiate(_activeWeapon.details.bullet.gameObject, _activeWeapon.shootingPoint.position, _activeWeapon.shootingPoint.rotation);
            }

            PlayWeaponFx();
        }

        internal void PlayWeaponFx(AudioSource asource = null)
        {
            _activeWeapon.fireFX.Play();
            PlayAudioFx();
            OnFiring?.Invoke();
        }

        void PlayAudioFx()
        {
            if (_activeWeapon.details.SoundFX == null) return;

            int count = _activeWeapon.details.SoundFX.Clip.Count;
            int randomInt = UnityEngine.Random.Range(0, count);

            _asource.pitch = UnityEngine.Random.Range(_activeWeapon.details.SoundFX.Pitch.x, _activeWeapon.details.SoundFX.Pitch.y);
            _asource.PlayOneShot(_activeWeapon.details.SoundFX.Clip[randomInt], _activeWeapon.details.SoundFX.Volume);
        }
    }
}