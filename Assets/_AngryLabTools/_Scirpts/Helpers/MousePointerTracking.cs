using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MousePointerTracking : MonoBehaviour
{
    private Camera _camera;
    Vector2 joyPos;
    public bool enableInputHandler;
    public LayerMask hitLayer;

    private InputHandler inputHandler;

    private void Awake()
    {
        inputHandler = new InputHandler();
    }

    private void Start()
    {
        _camera = Camera.main;

        if (enableInputHandler)
        {
            inputHandler.TopDown.Aiming.performed += AimDirection;
            inputHandler.TopDown.Aiming.Enable();
        }
    }

    public void AimDirection(InputAction.CallbackContext context)
    {
        var contextPos = context.ReadValue<Vector2>();
        Ray castPoint = _camera.ScreenPointToRay(contextPos);

        RaycastHit hit;

        if (Physics.Raycast(castPoint, out hit, Mathf.Infinity, hitLayer))
        {
            transform.position = hit.point;
        }
         
    }

    private void Update()
    {
        if (!enableInputHandler)
        {
            RaycastHit hit;
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, hitLayer))
            {
                transform.position = hit.point;
            }
        }
    }
}
