using AngryLab;
using UnityEngine;

namespace AngryLab
{
    [CreateAssetMenu(fileName = "Player_00_Details", menuName = "AngryLab/Player/Player Selection Details")]
    public class SO_PlayerSelectionDetails : ScriptableObject
    {
        [SerializeField] private int playerID = 0;
        [SerializeField] private SO_Killable_Props _character;
        [SerializeField] private SO_Weapon_Item _selectedWeapon;
        [SerializeField] private SO_Inventory _playerInv;

        internal int PlayerID { get { return playerID; } set { playerID = value; } }
        internal SO_Killable_Props Character { get { return _character; } set { _character = value; } }
        internal SO_Weapon_Item Weapon { get { return _selectedWeapon; } set { _selectedWeapon = value; } }
        internal SO_Inventory PlayerInventory { get { return _playerInv; } set { _playerInv = value; } }

        private void OnEnable()
        {
            //hideFlags = HideFlags.HideAndDontSave;
        }

        private void OnDisable()
        {
            //hideFlags = HideFlags.None;
        }

        internal void ClearSelections()
        {
            _character = null;
            _selectedWeapon = null;
            _playerInv = null;
        }

        internal void CreateNewKillableProp()
        {
            SO_Killable_Props newAsset = ScriptableObject.CreateInstance<SO_Killable_Props>();
            SaveToAssetDB(newAsset);
        }

        internal void SaveToAssetDB(SO_Killable_Props asset)
        {
            //string killableAssetPath = "";
            //AssetDatabase.CreateAsset(asset, killableAssetPath);
        }
    }
}