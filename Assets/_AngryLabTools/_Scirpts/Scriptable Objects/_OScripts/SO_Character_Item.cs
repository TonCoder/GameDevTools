using UnityEngine;

namespace AngryLab
{
    [CreateAssetMenu(menuName = "AngryLab/Store/Items/Character", fileName = "Character_Item")]
    public class SO_Character_Item : SO_Item
    {
        [SerializeField] internal SO_Killable_Props character;

        private void OnEnable()
        {
            Description = character.Desc;
        }
    }
}