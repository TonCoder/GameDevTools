using UnityEngine;

namespace AngryLab
{
    [RequireComponent(typeof(Projectile_Move))]
    public class ProjectileDetails : MonoBehaviour
    {
        [SerializeField] internal ProjectileType type = ProjectileType.Normal;
        [SerializeField] internal float _bulletDamage = 25;
        [SerializeField] internal float _bulletSpeed = 30f;
        [SerializeField] internal float _despawnTime = 0.8f;
        [SerializeField] internal bool _hitsplayer = true;

        private float timer = 0;

        internal void SetProperties(float damage, float speed, float despawnTime, bool hitsPlayer)
        {
            _bulletDamage = damage > 0 ? damage : _bulletDamage;
            _bulletSpeed = speed > 0 ? speed : _bulletSpeed;
            _despawnTime = despawnTime > 0 ? despawnTime : _despawnTime;
            _hitsplayer = hitsPlayer;
        }

        void Update()
        {
            var moveVelocity = _bulletSpeed * Time.deltaTime * transform.forward;
            transform.position += moveVelocity;

            timer += Time.deltaTime;
            if (timer >= _despawnTime)
            {
                timer = 0;
                SimplePoolManager.instance?.DisablePoolObject(transform);
            }
        }
    }
}