using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AngryLab
{
	public class DespawnAfterTime : MonoBehaviour
	{
		[SerializeField, Tooltip("If you are using the SimplePoolManager, select this box")] private bool _usingSimplePool = false;
		[SerializeField] private float _timeToDespawn = 1.2f;

		private float originalTimeToDespawn;

		void OnEnable()
		{
			originalTimeToDespawn = _timeToDespawn;
		}

		// Update is called once per frame
		void Update()
		{
			// Check to see if despawn is less than or equal to 0 and prevent it from continuing
			if (_timeToDespawn <= 0) return;

			// Start the timer
			_timeToDespawn -= Time.deltaTime;

			// check to see if the time has lapsed below 0 and despawn item/object
			if (_timeToDespawn <= 0)
			{
				_timeToDespawn = originalTimeToDespawn;
                if (_usingSimplePool)
                {
					SimplePoolManager.instance.DisablePoolObject(gameObject.transform);
					return;
				}

				Destroy(gameObject);
			}

		}
	}
}