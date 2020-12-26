using UnityEngine;

namespace AngryLab
{
    public abstract class Ab_BaseItemInfo : ScriptableObject
    {
        [SerializeField] private EItemType type = EItemType.Consumable;
        [SerializeField] private GameObject itemPrefab;

        [Space]
        [Header("General Details")]
        [SerializeField] private string itemId;
        [SerializeField, TextArea(4, 5)] private string description;
        [SerializeField] private float price;
        [SerializeField] private float salePrice;

        public virtual GameObject ItemPrefab { get { return itemPrefab; } }
        public EItemType ItemType { get { return type; } }
        public virtual string ItemId { get { return itemId; } internal set { } }
        public virtual string Description { get { return description; } }
        public virtual float Price { get { return price; } }
        public virtual float SalePrice { get { return salePrice; } }

        public virtual void Use()
        {
            // DO something or let the child override it
        }
    }
}