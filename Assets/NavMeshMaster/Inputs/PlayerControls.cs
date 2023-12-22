//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Inputs/PlayerControls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerControls: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""ShrimpActionMap"",
            ""id"": ""214a7288-f2a6-4a8f-95e4-8062aec5926a"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""2b8f9098-15c1-404d-9c8d-daffae408f68"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Restart"",
                    ""type"": ""Button"",
                    ""id"": ""1f18b184-dd02-43be-9706-7b42dc53d0ae"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""QuitGame"",
                    ""type"": ""Button"",
                    ""id"": ""6b33d5da-00d1-408a-88a9-ce8e441c17d2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""36131700-96c6-45b5-936f-9d537425da43"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Crouch"",
                    ""type"": ""Button"",
                    ""id"": ""c153c128-8c01-446b-a128-5d5b28c9b82e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""7eb119c9-2b3f-49d1-97d4-670446fa305d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Stir"",
                    ""type"": ""PassThrough"",
                    ""id"": ""e6756637-049a-4505-aeaf-e0a82be496e4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""e2bc41ba-41cb-4663-af00-29d96a73ca7e"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b6c42e48-3a84-4db2-b620-e2ba0e474499"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Restart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""161add69-5c19-4759-b429-5e12da9d35f0"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""QuitGame"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""4ed3458f-992d-4811-97f2-8ade7b3a4e8f"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""034ae023-f2eb-4254-aedc-1d2e9cb94f48"",
                    ""path"": ""<Keyboard>/#(W)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""81e849d7-cf34-4298-9c88-039b70a7dced"",
                    ""path"": ""<Keyboard>/#(S)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""f18297d4-6b2b-4e67-9e9f-bd2a58b807d5"",
                    ""path"": ""<Keyboard>/#(A)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""1182a9a6-3fc3-428a-8262-66773cc49339"",
                    ""path"": ""<Keyboard>/#(D)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""eb2f9ca7-22bd-4eb9-9365-ef62a2f526d1"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d817b53e-26e6-439b-b0ec-0a39530ddd0d"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6422c0e1-68f6-4de5-be3b-d328adb59501"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Stir"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""15e3d82e-0b7c-440d-aa80-575077cbd38a"",
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
                    ""id"": ""84cd6b7b-000f-4755-a671-27f08b35d693"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // ShrimpActionMap
        m_ShrimpActionMap = asset.FindActionMap("ShrimpActionMap", throwIfNotFound: true);
        m_ShrimpActionMap_Move = m_ShrimpActionMap.FindAction("Move", throwIfNotFound: true);
        m_ShrimpActionMap_Restart = m_ShrimpActionMap.FindAction("Restart", throwIfNotFound: true);
        m_ShrimpActionMap_QuitGame = m_ShrimpActionMap.FindAction("QuitGame", throwIfNotFound: true);
        m_ShrimpActionMap_Jump = m_ShrimpActionMap.FindAction("Jump", throwIfNotFound: true);
        m_ShrimpActionMap_Crouch = m_ShrimpActionMap.FindAction("Crouch", throwIfNotFound: true);
        m_ShrimpActionMap_Interact = m_ShrimpActionMap.FindAction("Interact", throwIfNotFound: true);
        m_ShrimpActionMap_Stir = m_ShrimpActionMap.FindAction("Stir", throwIfNotFound: true);
        m_ShrimpActionMap_Look = m_ShrimpActionMap.FindAction("Look", throwIfNotFound: true);
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

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // ShrimpActionMap
    private readonly InputActionMap m_ShrimpActionMap;
    private List<IShrimpActionMapActions> m_ShrimpActionMapActionsCallbackInterfaces = new List<IShrimpActionMapActions>();
    private readonly InputAction m_ShrimpActionMap_Move;
    private readonly InputAction m_ShrimpActionMap_Restart;
    private readonly InputAction m_ShrimpActionMap_QuitGame;
    private readonly InputAction m_ShrimpActionMap_Jump;
    private readonly InputAction m_ShrimpActionMap_Crouch;
    private readonly InputAction m_ShrimpActionMap_Interact;
    private readonly InputAction m_ShrimpActionMap_Stir;
    private readonly InputAction m_ShrimpActionMap_Look;
    public struct ShrimpActionMapActions
    {
        private @PlayerControls m_Wrapper;
        public ShrimpActionMapActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_ShrimpActionMap_Move;
        public InputAction @Restart => m_Wrapper.m_ShrimpActionMap_Restart;
        public InputAction @QuitGame => m_Wrapper.m_ShrimpActionMap_QuitGame;
        public InputAction @Jump => m_Wrapper.m_ShrimpActionMap_Jump;
        public InputAction @Crouch => m_Wrapper.m_ShrimpActionMap_Crouch;
        public InputAction @Interact => m_Wrapper.m_ShrimpActionMap_Interact;
        public InputAction @Stir => m_Wrapper.m_ShrimpActionMap_Stir;
        public InputAction @Look => m_Wrapper.m_ShrimpActionMap_Look;
        public InputActionMap Get() { return m_Wrapper.m_ShrimpActionMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ShrimpActionMapActions set) { return set.Get(); }
        public void AddCallbacks(IShrimpActionMapActions instance)
        {
            if (instance == null || m_Wrapper.m_ShrimpActionMapActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_ShrimpActionMapActionsCallbackInterfaces.Add(instance);
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @Restart.started += instance.OnRestart;
            @Restart.performed += instance.OnRestart;
            @Restart.canceled += instance.OnRestart;
            @QuitGame.started += instance.OnQuitGame;
            @QuitGame.performed += instance.OnQuitGame;
            @QuitGame.canceled += instance.OnQuitGame;
            @Jump.started += instance.OnJump;
            @Jump.performed += instance.OnJump;
            @Jump.canceled += instance.OnJump;
            @Crouch.started += instance.OnCrouch;
            @Crouch.performed += instance.OnCrouch;
            @Crouch.canceled += instance.OnCrouch;
            @Interact.started += instance.OnInteract;
            @Interact.performed += instance.OnInteract;
            @Interact.canceled += instance.OnInteract;
            @Stir.started += instance.OnStir;
            @Stir.performed += instance.OnStir;
            @Stir.canceled += instance.OnStir;
            @Look.started += instance.OnLook;
            @Look.performed += instance.OnLook;
            @Look.canceled += instance.OnLook;
        }

        private void UnregisterCallbacks(IShrimpActionMapActions instance)
        {
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @Restart.started -= instance.OnRestart;
            @Restart.performed -= instance.OnRestart;
            @Restart.canceled -= instance.OnRestart;
            @QuitGame.started -= instance.OnQuitGame;
            @QuitGame.performed -= instance.OnQuitGame;
            @QuitGame.canceled -= instance.OnQuitGame;
            @Jump.started -= instance.OnJump;
            @Jump.performed -= instance.OnJump;
            @Jump.canceled -= instance.OnJump;
            @Crouch.started -= instance.OnCrouch;
            @Crouch.performed -= instance.OnCrouch;
            @Crouch.canceled -= instance.OnCrouch;
            @Interact.started -= instance.OnInteract;
            @Interact.performed -= instance.OnInteract;
            @Interact.canceled -= instance.OnInteract;
            @Stir.started -= instance.OnStir;
            @Stir.performed -= instance.OnStir;
            @Stir.canceled -= instance.OnStir;
            @Look.started -= instance.OnLook;
            @Look.performed -= instance.OnLook;
            @Look.canceled -= instance.OnLook;
        }

        public void RemoveCallbacks(IShrimpActionMapActions instance)
        {
            if (m_Wrapper.m_ShrimpActionMapActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IShrimpActionMapActions instance)
        {
            foreach (var item in m_Wrapper.m_ShrimpActionMapActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_ShrimpActionMapActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public ShrimpActionMapActions @ShrimpActionMap => new ShrimpActionMapActions(this);
    public interface IShrimpActionMapActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnRestart(InputAction.CallbackContext context);
        void OnQuitGame(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnCrouch(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnStir(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
    }
}