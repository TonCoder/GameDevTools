using UnityEngine;
//using MoreMountains.Tools;
using System;
using UnityEngine.InputSystem;
using AngryLab;

namespace HeistEscape
{
    public class TopDownMovement : MonoBehaviour
    {
        [Header("Character")]
        [SerializeField] private SO_Killable_Props character_props;

        [Header("Testing Device")]
        [SerializeField] private bool isMobile = false;

        [Header("Movement Settings")]
        [SerializeField] private Rigidbody rbody;
        [SerializeField] private UEvents.EVector2 OnUpdateAnim;

        //private MMTouchJoystick moveJoyStick;
        private InputHandler inputHandler;
        private Vector2 joyMovePos;

        private Camera cam;
        private Vector3 camForward;
        private Vector3 move;

        private float movementSpeed;

        // properties set for inverting direction
        private float forwardAmount;
        private float turnAmount;

        private void Awake()
        {
            inputHandler = new InputHandler();
        }

        void Start()
        {
            movementSpeed = character_props.MoveSpeed;

            rbody = rbody ? rbody : GetComponent<Rigidbody>();
            cam = Camera.main;
        }

        private void OnEnable()
        {
            CheckDevice();
        }

        private void OnDisable()
        {
            //moveJoyStick?.JoystickValue.RemoveListener(MoveCharacter);
            inputHandler?.TopDown.Movement.Disable();
        }

        void FixedUpdate()
        {
            if (joyMovePos == Vector2.zero)
            {
                UpdateAnimator(0,0);
                return;
            }

            // check if camera is present
            if (cam != null)
            {
                camForward = Vector3.Scale(cam.transform.up, new Vector3(1, 0, 1)).normalized;
                move = joyMovePos.y * camForward + joyMovePos.x * cam.transform.right;
            }
            else
            {
                move = joyMovePos.y * Vector3.forward + joyMovePos.x * Vector3.right;
            }

            if (move.magnitude > 1)
            {
                move.Normalize();
            }

            NormalizeDirectionForAnimation(move);

            Vector3 newPos = new Vector3(joyMovePos.x, 0, joyMovePos.y);
            rbody.MovePosition(rbody.position + newPos * movementSpeed * Time.deltaTime);
        }

        void CheckDevice()
        {
            if (isMobile)
            {
                //if (!moveJoyStick)
                //{
                //    moveJoyStick = GameObject.FindGameObjectsWithTag("Left_JoyStick")[0].GetComponent<MMTouchJoystick>();
                //    moveJoyStick.JoystickValue.AddListener(MoveCharacter);
                //}
            }
            else
            {
                inputHandler.TopDown.Movement.performed += MoveCharacter;
                inputHandler.TopDown.Movement.canceled += StopMoving;
                inputHandler.TopDown.Movement.Enable();
            }
        }

        void StopMoving(InputAction.CallbackContext context)
        {
            joyMovePos = Vector2.zero;
        }

        /// <summary>
        /// This Func is used for the onscreen joystick
        /// </summary>
        /// <param name="move"></param>
        void MoveCharacter(Vector2 move)
        {
            joyMovePos = move;
        }

        void MoveCharacter(InputAction.CallbackContext context)
        {
            joyMovePos = context.ReadValue<Vector2>();
        }

        private void NormalizeDirectionForAnimation(Vector3 move)
        {
            // Normalize magnitude to avoid speeding up when moving diagonally
            if (move.magnitude > 1)
            {
                move.Normalize();
            }

            TransformDirectionToLocalSpace(move);
        }

        private void TransformDirectionToLocalSpace(Vector3 move)
        {
            // converts the direction from from world to local
            Vector3 localMove = transform.InverseTransformDirection(move);
            turnAmount = localMove.x;
            forwardAmount = localMove.z;
            UpdateAnimator(turnAmount, forwardAmount);
        }

        private void UpdateAnimator(float turn, float forward)
        {
            // Sets the animatin to the correct dirrection the player aims
            OnUpdateAnim?.Invoke(new Vector2(turn, forward));
        }

    }
}