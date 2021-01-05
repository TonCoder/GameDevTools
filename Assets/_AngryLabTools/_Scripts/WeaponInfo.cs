using TMPro;
using UnityEngine;

namespace AngryLab
{
    public class WeaponInfo : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private Collider _collider;
        [SerializeField] private Collider _pickupCollider;

        [Header("Weapon Setup")]
        [SerializeField] internal SO_Weapon_Item details;
        [SerializeField] internal Transform LeftHandGripPoint;
        [SerializeField] internal Transform RightHandGripPoint;
        [SerializeField] internal Transform shootingPoint;
        [SerializeField] internal ParticleSystem fireFX;
        [SerializeField] internal ParticleSystem pickUpFx;

        [Header("UI Setup")]
        [SerializeField] private TextMeshProUGUI weponNameText;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _collider = GetComponent<Collider>();
            weponNameText.text = details.name;
        }

        internal void Drop()
        {
            gameObject.SetActive(true);
            gameObject.transform.parent = null;
            _rigidbody.isKinematic = false;
            _rigidbody.AddForce(Vector3.up * 0.5f);
            _collider.enabled = true;
            _pickupCollider.enabled = true;
            pickUpFx.gameObject.SetActive(true);
            weponNameText.gameObject.SetActive(true);
            weponNameText.text = details.name;

            pickUpFx.transform.up = Vector3.up;
            weponNameText.transform.parent.up = Vector3.up;
        }

        internal void PickedUp()
        {
            _rigidbody.isKinematic = true;
            _collider.enabled = false;
            _pickupCollider.enabled = false;
            weponNameText.gameObject.SetActive(false);
            pickUpFx.gameObject.SetActive(false);
        }
    }
}