// GENERATED AUTOMATICALLY FROM 'Assets/_AngryLabTools/_Input Controlls Setup/InputControlls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputHandler : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputHandler()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputControlls"",
    ""maps"": [
        {
            ""name"": ""TopDown"",
            ""id"": ""295b2deb-19fc-4075-94ec-09bae3b7bd61"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Button"",
                    ""id"": ""4026a545-3cf9-4242-b3ab-a6c665151101"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Aiming"",
                    ""type"": ""Value"",
                    ""id"": ""d00965e5-70c6-4258-b813-b19de9723f89"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""021d8020-a68f-4336-b1b9-a4ba19f78d37"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ThrowGranade"",
                    ""type"": ""Button"",
                    ""id"": ""308e8bd4-e034-46b8-a973-41491933c0f5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""f906ed0b-0573-4c60-bc52-83936fd582be"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SwitchWeapons"",
                    ""type"": ""Value"",
                    ""id"": ""9ff57da5-6d6a-45a5-8b66-7c3d95e31495"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""KeyboardMovement"",
                    ""id"": ""8653e2ea-4980-44d7-9ea9-6c659318c474"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Up"",
                    ""id"": ""52046bc2-e52e-4bcf-a2f1-ef22e9f1e31a"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Down"",
                    ""id"": ""189852f6-9919-446f-a365-644df206add3"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Left"",
                    ""id"": ""ebaff2a6-6e59-4520-880a-f2142b052fa0"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Right"",
                    ""id"": ""66d91547-b02e-47a1-a404-006ba85a2786"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""70d3d1e4-3674-47eb-8dda-9cb2b58852cc"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aiming"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""187b4c68-3cb1-491a-bbe2-36c3e3bf41fe"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fb34f54f-074a-4f67-9b5f-a29e485efc36"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ThrowGranade"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2241351c-b293-47f9-9ed4-d01c8d75e035"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""513dca79-aecc-4e14-9b78-1c8077321cf4"",
                    ""path"": ""<Mouse>/scroll"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwitchWeapons"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // TopDown
        m_TopDown = asset.FindActionMap("TopDown", throwIfNotFound: true);
        m_TopDown_Movement = m_TopDown.FindAction("Movement", throwIfNotFound: true);
        m_TopDown_Aiming = m_TopDown.FindAction("Aiming", throwIfNotFound: true);
        m_TopDown_Shoot = m_TopDown.FindAction("Shoot", throwIfNotFound: true);
        m_TopDown_ThrowGranade = m_TopDown.FindAction("ThrowGranade", throwIfNotFound: true);
        m_TopDown_Interact = m_TopDown.FindAction("Interact", throwIfNotFound: true);
        m_TopDown_SwitchWeapons = m_TopDown.FindAction("SwitchWeapons", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // TopDown
    private readonly InputActionMap m_TopDown;
    private ITopDownActions m_TopDownActionsCallbackInterface;
    private readonly InputAction m_TopDown_Movement;
    private readonly InputAction m_TopDown_Aiming;
    private readonly InputAction m_TopDown_Shoot;
    private readonly InputAction m_TopDown_ThrowGranade;
    private readonly InputAction m_TopDown_Interact;
    private readonly InputAction m_TopDown_SwitchWeapons;
    public struct TopDownActions
    {
        private @InputHandler m_Wrapper;
        public TopDownActions(@InputHandler wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_TopDown_Movement;
        public InputAction @Aiming => m_Wrapper.m_TopDown_Aiming;
        public InputAction @Shoot => m_Wrapper.m_TopDown_Shoot;
        public InputAction @ThrowGranade => m_Wrapper.m_TopDown_ThrowGranade;
        public InputAction @Interact => m_Wrapper.m_TopDown_Interact;
        public InputAction @SwitchWeapons => m_Wrapper.m_TopDown_SwitchWeapons;
        public InputActionMap Get() { return m_Wrapper.m_TopDown; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TopDownActions set) { return set.Get(); }
        public void SetCallbacks(ITopDownActions instance)
        {
            if (m_Wrapper.m_TopDownActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_TopDownActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_TopDownActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_TopDownActionsCallbackInterface.OnMovement;
                @Aiming.started -= m_Wrapper.m_TopDownActionsCallbackInterface.OnAiming;
                @Aiming.performed -= m_Wrapper.m_TopDownActionsCallbackInterface.OnAiming;
                @Aiming.canceled -= m_Wrapper.m_TopDownActionsCallbackInterface.OnAiming;
                @Shoot.started -= m_Wrapper.m_TopDownActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_TopDownActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_TopDownActionsCallbackInterface.OnShoot;
                @ThrowGranade.started -= m_Wrapper.m_TopDownActionsCallbackInterface.OnThrowGranade;
                @ThrowGranade.performed -= m_Wrapper.m_TopDownActionsCallbackInterface.OnThrowGranade;
                @ThrowGranade.canceled -= m_Wrapper.m_TopDownActionsCallbackInterface.OnThrowGranade;
                @Interact.started -= m_Wrapper.m_TopDownActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_TopDownActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_TopDownActionsCallbackInterface.OnInteract;
                @SwitchWeapons.started -= m_Wrapper.m_TopDownActionsCallbackInterface.OnSwitchWeapons;
                @SwitchWeapons.performed -= m_Wrapper.m_TopDownActionsCallbackInterface.OnSwitchWeapons;
                @SwitchWeapons.canceled -= m_Wrapper.m_TopDownActionsCallbackInterface.OnSwitchWeapons;
            }
            m_Wrapper.m_TopDownActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Aiming.started += instance.OnAiming;
                @Aiming.performed += instance.OnAiming;
                @Aiming.canceled += instance.OnAiming;
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
                @ThrowGranade.started += instance.OnThrowGranade;
                @ThrowGranade.performed += instance.OnThrowGranade;
                @ThrowGranade.canceled += instance.OnThrowGranade;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @SwitchWeapons.started += instance.OnSwitchWeapons;
                @SwitchWeapons.performed += instance.OnSwitchWeapons;
                @SwitchWeapons.canceled += instance.OnSwitchWeapons;
            }
        }
    }
    public TopDownActions @TopDown => new TopDownActions(this);
    public interface ITopDownActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnAiming(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
        void OnThrowGranade(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnSwitchWeapons(InputAction.CallbackContext context);
    }
}
