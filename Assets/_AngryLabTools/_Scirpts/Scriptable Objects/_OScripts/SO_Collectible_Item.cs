using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AngryLab
{
    [CreateAssetMenu(fileName = "Collectible Item", menuName = "AngryLab/Store/Items/Collectible")]
    public class SO_Collectible_Item : SO_Item
    {
        [SerializeField] private ECollectibleType collectibleType;
        [SerializeField] private SO_SoundFX soundFx;
        [SerializeField] private int valuePoint = 0;
        [SerializeField] private float despawnTime = 2;

        public ECollectibleType CollectibleType { get; set; }
        public SO_SoundFX SoundFx { get; set; }
        public int ValuePoint { get; set; }
        public float DespawnTime { get; set; }

    }
}