using System;
using UnityEngine;
using UnityEngine.InputSystem;
using AngryLab;

namespace HeistEscape
{
    public class TopDownAimingShooting : MonoBehaviour
    {
        [Header("Character")]
        [SerializeField] private SO_Killable_Props character_props;

        [Header("Testing Device")]
        [SerializeField] private bool isMobile = false;

        [Header("Aiming Setup")]
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private bool isUsingMouse = false;
        [SerializeField] private LayerMask hitLayer;
        //[SerializeField, Sirenix.OdinInspector.ReadOnly] private MMTouchJoystick rightJoyStick;

        [Space]
        [Header("Aiming Events")]
        public UEvents.EBool OnCanShoot;

        private InputHandler inputHandler;
        private Camera _camera;
        private Vector3 joyPos;
        private float _turnSpeed;
        private bool canShoot = false;

        private void Awake()
        {
            inputHandler = new InputHandler();
        }

        void Start()
        {
            _turnSpeed = character_props.TurnSpeed;

            _camera = _camera? _camera : Camera.main;
            _rigidbody = _rigidbody ? _rigidbody : GetComponent<Rigidbody>();
        }

        private void OnEnable()
        {
            CheckDevice();

            inputHandler.TopDown.Shoot.performed += EnableFire;
            inputHandler.TopDown.Shoot.canceled += DisableFire;
            inputHandler.TopDown.Shoot.Enable();
        }

        private void OnDisable()
        {
            //rightJoyStick?.JoystickValue.RemoveListener(AimDirection);
            inputHandler?.TopDown.Aiming.Disable();
            inputHandler?.TopDown.Shoot.Disable();
        }

        void FixedUpdate()
        {
            if (isMobile)
            {
                if (!joyPos.Equals(Vector3.zero))
                {
                    OnCanShoot?.Invoke(false);
                }
                else
                {
                    OnCanShoot?.Invoke(true);
                }
            }

            TurnTowards();
        }

        private void EnableFire(InputAction.CallbackContext obj)
        {
            OnCanShoot?.Invoke(true);
        }

        private void DisableFire(InputAction.CallbackContext obj)
        {
            OnCanShoot?.Invoke(false);
        }

        public void SetTurnSpeed(float val)
        {
            _turnSpeed = val;
        }

        void CheckDevice()
        {
            if (isMobile)
            {
                //if (!rightJoyStick)
                //{
                //    rightJoyStick = rightJoyStick ? rightJoyStick : GameObject.FindGameObjectsWithTag("Right_JoyStick")[0].GetComponent<MMTouchJoystick>();
                //    rightJoyStick.JoystickValue.AddListener(AimDirection);
                //}
            }
            else
            {
                inputHandler.TopDown.Aiming.performed += AimDirection;
                inputHandler.TopDown.Aiming.Enable();
            }
        }

        public void AimDirection(Vector2 move)
        {
            joyPos = move;
        }

        public void AimDirection(InputAction.CallbackContext context)
        {
            var contextPos = context.ReadValue<Vector2>();
            //var contextPos = Input.mousePosition;
            Ray castPoint = _camera.ScreenPointToRay(contextPos);

            RaycastHit hit;
            if (Physics.Raycast(castPoint, out hit, Mathf.Infinity, hitLayer))
            {
                joyPos = hit.point;
            }
        }

        void TurnTowards()
        {
            Vector3 lookDir = isMobile ? new Vector3(joyPos.x, 0, joyPos.y) - _rigidbody.transform.position : joyPos - _rigidbody.transform.position;
            lookDir.y = 0;

            // var rotateTo = Quaternion.RotateTowards(_rigidbody.rotation, Quaternion.LookRotation(-lookDir), Time.deltaTime * characterInfo.TurnSpeed);

            Quaternion rotateTo = Quaternion.Lerp(_rigidbody.rotation, Quaternion.LookRotation(lookDir), Time.deltaTime * _turnSpeed);
            _rigidbody.rotation = rotateTo;
        }
    }
}