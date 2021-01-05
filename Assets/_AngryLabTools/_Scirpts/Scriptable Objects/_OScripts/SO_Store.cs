using UnityEngine;

namespace AngryLab
{
    [CreateAssetMenu(menuName = "AngryLab/Store/New Store", fileName = "New Store")]
    public class SO_Store : ScriptableObject
    {
        [SerializeField] internal string storeName;
        [SerializeField] internal EItemType storeType;
        [SerializeField] internal SO_Inventory storeGoods;
        private int currentStoreIndx = 0;

        internal SO_Item GetItemByIndx(int indx)
        {
            return storeGoods.list[indx];
        }
    }
}