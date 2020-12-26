using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AngryLab
{
	[CreateAssetMenu(menuName = "AngryLab/Game System/Weapons/BulletDetails", fileName = "NewBullet")]
	public class SO_Bullets : ScriptableObject
	{
		// [SerializeField] internal GameObject bulletObject;
		[SerializeField] internal float bulletDamage = 10f;
		[SerializeField] internal float bulletSpeed = 50f;
		[SerializeField] internal float despawnTime = 0.8f;
		[SerializeField] internal LayerMask hitLayer = 0;
	}
}