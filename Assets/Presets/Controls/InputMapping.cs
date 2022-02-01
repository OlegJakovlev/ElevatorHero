// GENERATED AUTOMATICALLY FROM 'Assets/Presets/Controls/InputMapping.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputMapping : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputMapping()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputMapping"",
    ""maps"": [
        {
            ""name"": ""Character"",
            ""id"": ""c6019fbe-d5d9-450a-92cb-591346cd2a5e"",
            ""actions"": [
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""a452c62a-5db9-4392-a840-1b43f4988d87"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Movement"",
                    ""type"": ""Button"",
                    ""id"": ""6d7825f6-7763-45ec-b52f-0ac999ca50a7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""c0bb43d8-aca3-47b2-9d68-a47913ac0666"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""Activation"",
                    ""type"": ""Button"",
                    ""id"": ""a64d77c1-19ab-4ec4-bf8d-2c4af473c42c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Duck"",
                    ""type"": ""Button"",
                    ""id"": ""0611d7ca-f6cf-464c-800c-4d1c8c4e39c0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""ElevatorHorizontalControl"",
                    ""type"": ""Button"",
                    ""id"": ""bad0bd11-9d67-4506-80f2-d0b39c6d4990"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""ElevatorVerticalControl"",
                    ""type"": ""Button"",
                    ""id"": ""a0cc7d88-3635-461c-8810-3179db222e16"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b46c7410-9b76-4e37-83af-f7ac2166d02e"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""563483ff-bf14-4da4-9593-869d4a28a9cb"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""a5d70bbc-d7d8-4f16-9377-015226f65a56"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Negative"",
                    ""id"": ""25408af4-e081-46c8-b859-a44818ffdae0"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Positive"",
                    ""id"": ""b70f0584-36ca-4ac0-bdc3-b6675a3b89fc"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""435bb3be-3a3f-4087-9935-b00a2d1b593d"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""6573ff56-bbad-4b64-9d30-7a8ba5f0aed6"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""ac025fdb-5c54-4221-a350-c59c1957842a"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""23808949-6e9c-451a-b8ae-08429a2e19fe"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Activation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""05b3f1f0-d1b9-4300-9b14-ef7fc675e3ff"",
                    ""path"": ""<Keyboard>/leftCtrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Duck"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""485f130a-ed01-4786-b040-f8b00053beff"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Duck"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""HorizontalArrows"",
                    ""id"": ""0ea510d5-db1e-42d0-81dc-544d7611ad95"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ElevatorHorizontalControl"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Negative"",
                    ""id"": ""c39968ee-84a5-4ff9-a6fa-94dd3f8191b3"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""ElevatorHorizontalControl"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Positive"",
                    ""id"": ""abccf12b-74e7-4dd0-9f01-5de68f06ba3e"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""ElevatorHorizontalControl"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrows"",
                    ""id"": ""90aafa21-fbe6-4eef-bef6-20d1f60097f7"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ElevatorVerticalControl"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""36fa221e-1648-4c2a-bfe9-26210f09d0b7"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""ElevatorVerticalControl"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""f299530c-bfcb-4b22-b93e-be6471b3ce24"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""ElevatorVerticalControl"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""676d13be-6d1a-4f27-8e40-5c9c35230e55"",
            ""actions"": [
                {
                    ""name"": ""Select"",
                    ""type"": ""Button"",
                    ""id"": ""5ebebb57-2bbf-47c8-9dec-8b5be951f43d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""NavigateHorizontally"",
                    ""type"": ""Button"",
                    ""id"": ""d678d6a8-2866-4ecd-bb6d-0358ad8c5726"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""NavigateVertically"",
                    ""type"": ""Button"",
                    ""id"": ""9d9490af-39d1-414e-9865-5f9fdde5e70c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""60b359c2-a9b9-431f-9a7d-14d5b13090f4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""fc08a450-afe7-4601-9358-cede3e28a7e7"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""914f044f-d0fe-49ed-a785-7185ed4d43ce"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a3d2fad6-7e2d-496b-bfab-186cb8902640"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""LeftAndRight"",
                    ""id"": ""91361e4d-971f-4396-8e10-9f51dd2761ea"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NavigateHorizontally"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""92d80715-4b09-4edf-a027-0263b57b8d0c"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NavigateHorizontally"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""1f23befb-91c9-4595-89dd-0a812c77e4a2"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NavigateHorizontally"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""UpAndDown"",
                    ""id"": ""6e8c556a-ea30-4693-9399-603fb91091a2"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NavigateVertically"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""33924806-5e35-44ee-9ac0-802c1645a6d7"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NavigateVertically"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""5383f771-92a8-479a-a5ec-4c3e9d299cc5"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NavigateVertically"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""854373f5-606b-425f-b2d3-ef62e75bd62c"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard and Mouse"",
            ""bindingGroup"": ""Keyboard and Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Character
        m_Character = asset.FindActionMap("Character", throwIfNotFound: true);
        m_Character_Shoot = m_Character.FindAction("Shoot", throwIfNotFound: true);
        m_Character_Movement = m_Character.FindAction("Movement", throwIfNotFound: true);
        m_Character_Jump = m_Character.FindAction("Jump", throwIfNotFound: true);
        m_Character_Activation = m_Character.FindAction("Activation", throwIfNotFound: true);
        m_Character_Duck = m_Character.FindAction("Duck", throwIfNotFound: true);
        m_Character_ElevatorHorizontalControl = m_Character.FindAction("ElevatorHorizontalControl", throwIfNotFound: true);
        m_Character_ElevatorVerticalControl = m_Character.FindAction("ElevatorVerticalControl", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_Select = m_UI.FindAction("Select", throwIfNotFound: true);
        m_UI_NavigateHorizontally = m_UI.FindAction("NavigateHorizontally", throwIfNotFound: true);
        m_UI_NavigateVertically = m_UI.FindAction("NavigateVertically", throwIfNotFound: true);
        m_UI_Pause = m_UI.FindAction("Pause", throwIfNotFound: true);
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

    // Character
    private readonly InputActionMap m_Character;
    private ICharacterActions m_CharacterActionsCallbackInterface;
    private readonly InputAction m_Character_Shoot;
    private readonly InputAction m_Character_Movement;
    private readonly InputAction m_Character_Jump;
    private readonly InputAction m_Character_Activation;
    private readonly InputAction m_Character_Duck;
    private readonly InputAction m_Character_ElevatorHorizontalControl;
    private readonly InputAction m_Character_ElevatorVerticalControl;
    public struct CharacterActions
    {
        private @InputMapping m_Wrapper;
        public CharacterActions(@InputMapping wrapper) { m_Wrapper = wrapper; }
        public InputAction @Shoot => m_Wrapper.m_Character_Shoot;
        public InputAction @Movement => m_Wrapper.m_Character_Movement;
        public InputAction @Jump => m_Wrapper.m_Character_Jump;
        public InputAction @Activation => m_Wrapper.m_Character_Activation;
        public InputAction @Duck => m_Wrapper.m_Character_Duck;
        public InputAction @ElevatorHorizontalControl => m_Wrapper.m_Character_ElevatorHorizontalControl;
        public InputAction @ElevatorVerticalControl => m_Wrapper.m_Character_ElevatorVerticalControl;
        public InputActionMap Get() { return m_Wrapper.m_Character; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CharacterActions set) { return set.Get(); }
        public void SetCallbacks(ICharacterActions instance)
        {
            if (m_Wrapper.m_CharacterActionsCallbackInterface != null)
            {
                @Shoot.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnShoot;
                @Movement.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnMovement;
                @Jump.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnJump;
                @Activation.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnActivation;
                @Activation.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnActivation;
                @Activation.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnActivation;
                @Duck.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnDuck;
                @Duck.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnDuck;
                @Duck.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnDuck;
                @ElevatorHorizontalControl.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnElevatorHorizontalControl;
                @ElevatorHorizontalControl.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnElevatorHorizontalControl;
                @ElevatorHorizontalControl.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnElevatorHorizontalControl;
                @ElevatorVerticalControl.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnElevatorVerticalControl;
                @ElevatorVerticalControl.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnElevatorVerticalControl;
                @ElevatorVerticalControl.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnElevatorVerticalControl;
            }
            m_Wrapper.m_CharacterActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Activation.started += instance.OnActivation;
                @Activation.performed += instance.OnActivation;
                @Activation.canceled += instance.OnActivation;
                @Duck.started += instance.OnDuck;
                @Duck.performed += instance.OnDuck;
                @Duck.canceled += instance.OnDuck;
                @ElevatorHorizontalControl.started += instance.OnElevatorHorizontalControl;
                @ElevatorHorizontalControl.performed += instance.OnElevatorHorizontalControl;
                @ElevatorHorizontalControl.canceled += instance.OnElevatorHorizontalControl;
                @ElevatorVerticalControl.started += instance.OnElevatorVerticalControl;
                @ElevatorVerticalControl.performed += instance.OnElevatorVerticalControl;
                @ElevatorVerticalControl.canceled += instance.OnElevatorVerticalControl;
            }
        }
    }
    public CharacterActions @Character => new CharacterActions(this);

    // UI
    private readonly InputActionMap m_UI;
    private IUIActions m_UIActionsCallbackInterface;
    private readonly InputAction m_UI_Select;
    private readonly InputAction m_UI_NavigateHorizontally;
    private readonly InputAction m_UI_NavigateVertically;
    private readonly InputAction m_UI_Pause;
    public struct UIActions
    {
        private @InputMapping m_Wrapper;
        public UIActions(@InputMapping wrapper) { m_Wrapper = wrapper; }
        public InputAction @Select => m_Wrapper.m_UI_Select;
        public InputAction @NavigateHorizontally => m_Wrapper.m_UI_NavigateHorizontally;
        public InputAction @NavigateVertically => m_Wrapper.m_UI_NavigateVertically;
        public InputAction @Pause => m_Wrapper.m_UI_Pause;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void SetCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterface != null)
            {
                @Select.started -= m_Wrapper.m_UIActionsCallbackInterface.OnSelect;
                @Select.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnSelect;
                @Select.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnSelect;
                @NavigateHorizontally.started -= m_Wrapper.m_UIActionsCallbackInterface.OnNavigateHorizontally;
                @NavigateHorizontally.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnNavigateHorizontally;
                @NavigateHorizontally.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnNavigateHorizontally;
                @NavigateVertically.started -= m_Wrapper.m_UIActionsCallbackInterface.OnNavigateVertically;
                @NavigateVertically.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnNavigateVertically;
                @NavigateVertically.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnNavigateVertically;
                @Pause.started -= m_Wrapper.m_UIActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnPause;
            }
            m_Wrapper.m_UIActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Select.started += instance.OnSelect;
                @Select.performed += instance.OnSelect;
                @Select.canceled += instance.OnSelect;
                @NavigateHorizontally.started += instance.OnNavigateHorizontally;
                @NavigateHorizontally.performed += instance.OnNavigateHorizontally;
                @NavigateHorizontally.canceled += instance.OnNavigateHorizontally;
                @NavigateVertically.started += instance.OnNavigateVertically;
                @NavigateVertically.performed += instance.OnNavigateVertically;
                @NavigateVertically.canceled += instance.OnNavigateVertically;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public UIActions @UI => new UIActions(this);
    private int m_KeyboardandMouseSchemeIndex = -1;
    public InputControlScheme KeyboardandMouseScheme
    {
        get
        {
            if (m_KeyboardandMouseSchemeIndex == -1) m_KeyboardandMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard and Mouse");
            return asset.controlSchemes[m_KeyboardandMouseSchemeIndex];
        }
    }
    public interface ICharacterActions
    {
        void OnShoot(InputAction.CallbackContext context);
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnActivation(InputAction.CallbackContext context);
        void OnDuck(InputAction.CallbackContext context);
        void OnElevatorHorizontalControl(InputAction.CallbackContext context);
        void OnElevatorVerticalControl(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnSelect(InputAction.CallbackContext context);
        void OnNavigateHorizontally(InputAction.CallbackContext context);
        void OnNavigateVertically(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
    }
}
