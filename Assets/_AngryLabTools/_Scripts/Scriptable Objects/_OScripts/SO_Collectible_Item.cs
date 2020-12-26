using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AngryLab
{

    [CreateAssetMenu(fileName = "Collectible Item", menuName = "AngryLab/Game System/Items/Collectible")]
    public class SO_Collectible_Item : Ab_BaseItemInfo
    {
        [SerializeField] private ECollectibleType collectibleType;
        [SerializeField] private SO_SoundFX soundFx;
        [SerializeField] private int valuePoint = 0;
        [SerializeField] private float despawnTime = 2;

        public ECollectibleType CollectibleType { get; }
        public SO_SoundFX SoundFx { get; }
        public int ValuePoint { get; }
        public float DespawnTime { get; }

    }
}