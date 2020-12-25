using UnityEngine;

[CreateAssetMenu(menuName = "AngryLab/Game System/Store and Inv/New Store", fileName = "New Store")]
public class SO_Store : ScriptableObject
{
    [SerializeField] internal string storeName;
    [SerializeField] internal EItemType storyType;
    [SerializeField] internal SO_Inventory storeGoods;
    private int currentStoreIndx = 0;

    internal Ab_BaseItemInfo GetItemByIndx(int indx)
    {
        return storeGoods.list[indx];
    }
}
