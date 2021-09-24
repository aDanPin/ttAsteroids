// GENERATED AUTOMATICALLY FROM 'Assets/Scriptes/InputHandler/InputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActions"",
    ""maps"": [
        {
            ""name"": ""main"",
            ""id"": ""f90ed2b8-c516-41d7-b69d-af8b4d0f52a4"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""fff183a9-8a91-48bb-ba5f-2a2860bd0968"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""RotationRight"",
                    ""type"": ""Button"",
                    ""id"": ""50af8ace-9617-41ff-8fe1-78ff6732aa32"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""RotationLeft"",
                    ""type"": ""Button"",
                    ""id"": ""e23735d8-c849-4db4-beb6-49480db762e6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""Fier"",
                    ""type"": ""Button"",
                    ""id"": ""9410cf33-13e9-4396-8bdb-a915839228ec"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Laser"",
                    ""type"": ""Button"",
                    ""id"": ""ea9cb00c-c838-4f3a-ad23-daebd6cd44f4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f63dbe6c-6386-4f5c-b767-54958a048314"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5b1c8552-3633-42e7-ac11-1591a6b31a02"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotationRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3b31382c-f9eb-4ff2-889f-1e145a7edda7"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotationLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d51fa7f7-c63b-40ba-89c2-f588669d7685"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fier"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f8345e43-4f17-4876-a179-4cc47aab5afb"",
                    ""path"": ""<Keyboard>/v"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Laser"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // main
        m_main = asset.FindActionMap("main", throwIfNotFound: true);
        m_main_Move = m_main.FindAction("Move", throwIfNotFound: true);
        m_main_RotationRight = m_main.FindAction("RotationRight", throwIfNotFound: true);
        m_main_RotationLeft = m_main.FindAction("RotationLeft", throwIfNotFound: true);
        m_main_Fier = m_main.FindAction("Fier", throwIfNotFound: true);
        m_main_Laser = m_main.FindAction("Laser", throwIfNotFound: true);
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

    // main
    private readonly InputActionMap m_main;
    private IMainActions m_MainActionsCallbackInterface;
    private readonly InputAction m_main_Move;
    private readonly InputAction m_main_RotationRight;
    private readonly InputAction m_main_RotationLeft;
    private readonly InputAction m_main_Fier;
    private readonly InputAction m_main_Laser;
    public struct MainActions
    {
        private @InputActions m_Wrapper;
        public MainActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_main_Move;
        public InputAction @RotationRight => m_Wrapper.m_main_RotationRight;
        public InputAction @RotationLeft => m_Wrapper.m_main_RotationLeft;
        public InputAction @Fier => m_Wrapper.m_main_Fier;
        public InputAction @Laser => m_Wrapper.m_main_Laser;
        public InputActionMap Get() { return m_Wrapper.m_main; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MainActions set) { return set.Get(); }
        public void SetCallbacks(IMainActions instance)
        {
            if (m_Wrapper.m_MainActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_MainActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnMove;
                @RotationRight.started -= m_Wrapper.m_MainActionsCallbackInterface.OnRotationRight;
                @RotationRight.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnRotationRight;
                @RotationRight.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnRotationRight;
                @RotationLeft.started -= m_Wrapper.m_MainActionsCallbackInterface.OnRotationLeft;
                @RotationLeft.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnRotationLeft;
                @RotationLeft.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnRotationLeft;
                @Fier.started -= m_Wrapper.m_MainActionsCallbackInterface.OnFier;
                @Fier.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnFier;
                @Fier.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnFier;
                @Laser.started -= m_Wrapper.m_MainActionsCallbackInterface.OnLaser;
                @Laser.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnLaser;
                @Laser.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnLaser;
            }
            m_Wrapper.m_MainActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @RotationRight.started += instance.OnRotationRight;
                @RotationRight.performed += instance.OnRotationRight;
                @RotationRight.canceled += instance.OnRotationRight;
                @RotationLeft.started += instance.OnRotationLeft;
                @RotationLeft.performed += instance.OnRotationLeft;
                @RotationLeft.canceled += instance.OnRotationLeft;
                @Fier.started += instance.OnFier;
                @Fier.performed += instance.OnFier;
                @Fier.canceled += instance.OnFier;
                @Laser.started += instance.OnLaser;
                @Laser.performed += instance.OnLaser;
                @Laser.canceled += instance.OnLaser;
            }
        }
    }
    public MainActions @main => new MainActions(this);
    public interface IMainActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnRotationRight(InputAction.CallbackContext context);
        void OnRotationLeft(InputAction.CallbackContext context);
        void OnFier(InputAction.CallbackContext context);
        void OnLaser(InputAction.CallbackContext context);
    }
}
