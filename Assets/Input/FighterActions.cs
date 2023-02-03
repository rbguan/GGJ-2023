//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Input/FighterActions.inputactions
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

public partial class @FighterActions : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @FighterActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""FighterActions"",
    ""maps"": [
        {
            ""name"": ""Menu"",
            ""id"": ""79e1a5e5-2a9f-4efe-ab1d-4d834656e43d"",
            ""actions"": [
                {
                    ""name"": ""ChangeCharacter"",
                    ""type"": ""Value"",
                    ""id"": ""38d7db63-3171-4350-903d-05496a3dc091"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""SelectCharacter"",
                    ""type"": ""Button"",
                    ""id"": ""745368fb-21e3-4d88-9733-be9cfab14c35"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""DeselectCharacter"",
                    ""type"": ""Button"",
                    ""id"": ""114afdd5-e126-4e9f-99e7-6d963faa7515"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""91846fb9-700a-4d6d-a140-758f668d7c12"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeCharacter"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""b8240fe7-d6c1-462f-9485-4becf9dc1cad"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeCharacter"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""e122f09b-59df-46c0-baeb-59ccb8d16a94"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""ChangeCharacter"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""c0b20d24-4d9b-46ac-8ed9-7b9f8b1f4875"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeCharacter"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""d90069bb-0b13-4d74-8555-2593335989ca"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""ChangeCharacter"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""dcf58b02-610a-4976-97a7-6bb7b4017ff5"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""ChangeCharacter"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""27cff6e1-5f95-4b44-9efc-0ea869796cf5"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""SelectCharacter"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""710cc53b-975d-40f7-ac2d-4e5b0204b5e2"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""SelectCharacter"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""41f6fb35-2f7b-4145-902a-c721f3d7adea"",
                    ""path"": ""<Keyboard>/backspace"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""DeselectCharacter"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f437e101-be12-4f83-8d44-e5669625d99b"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""DeselectCharacter"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Base"",
            ""id"": ""a9a8cfc4-d1c2-4622-b71f-32dcb19b275b"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""99be9611-49e6-4004-95b3-c2b75047b6cf"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""f48661ef-21e0-45c0-904d-57407a3f7958"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""BasicAttack"",
                    ""type"": ""Button"",
                    ""id"": ""03ad4191-bf0a-445f-a0b7-96bcac2b4bc2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""DodgeLeft"",
                    ""type"": ""Button"",
                    ""id"": ""eba92155-4f59-412b-a47f-ea3e67771455"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""MultiTap"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""DodgeRight"",
                    ""type"": ""Button"",
                    ""id"": ""2119e003-1d2f-4d67-9188-65bc6581bfa5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""MultiTap"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""FallThroughPlatform"",
                    ""type"": ""Button"",
                    ""id"": ""69e64bbe-293f-4841-afb2-456aea6db0eb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""MultiTap"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SpecialAttack"",
                    ""type"": ""Button"",
                    ""id"": ""62076a0d-26eb-4caa-a071-4d2b9658e5da"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Block"",
                    ""type"": ""Button"",
                    ""id"": ""c06dd848-7078-4ca7-8a80-d111add4943a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""354b2464-1e28-45dc-8716-a7002bc30e13"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d59ae8e5-bd2f-420b-88d9-0d77bf03160b"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cdf73527-bc79-4d68-aa95-13e7628fdf2b"",
                    ""path"": ""<DualSenseGamepadHID>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5e5dc741-f0d5-4a39-b93f-3774203773d0"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""BasicAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4be39905-eb89-4ab9-9bad-c13c3dc8552b"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""DodgeLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2016096c-a251-4683-86bb-1652df482822"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""DodgeLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""759aec26-3c35-437e-8fe4-67658ce37322"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""DodgeRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2056b46f-1b40-4774-893b-f788c0e6fb7c"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""DodgeRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""965a2821-015d-48f5-ac02-04ed458d98b7"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""FallThroughPlatform"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3f432e4a-1507-4e64-8640-fd41d64f714b"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""FallThroughPlatform"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""69a64332-106c-42b8-ab8d-4e05fd39e5b8"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""37eb24b7-cf61-45c2-bbd2-b00eafcf6374"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""1d758737-2c8e-468c-96c4-ce6def64330d"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""972d5f07-5b41-4268-b8e9-93e5cd34e289"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""3253cc87-7b67-4030-8bb1-fa9271c689a7"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""1581968a-dd2a-479d-b331-1d734713cff9"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""afe69962-65ba-4cc3-993d-5295b913ef1a"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""8df397fb-f184-4f82-8806-352d0a17ea72"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""19da4885-7477-401a-99d7-b085fa2ce0e4"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""c62025e4-a997-4357-912e-8db134159bfe"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""SpecialAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7b770331-7c41-4ea3-a0fd-81a52babf511"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Block"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""053714d5-3276-4493-8571-d3db52d9f488"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Block"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Menu
        m_Menu = asset.FindActionMap("Menu", throwIfNotFound: true);
        m_Menu_ChangeCharacter = m_Menu.FindAction("ChangeCharacter", throwIfNotFound: true);
        m_Menu_SelectCharacter = m_Menu.FindAction("SelectCharacter", throwIfNotFound: true);
        m_Menu_DeselectCharacter = m_Menu.FindAction("DeselectCharacter", throwIfNotFound: true);
        // Base
        m_Base = asset.FindActionMap("Base", throwIfNotFound: true);
        m_Base_Jump = m_Base.FindAction("Jump", throwIfNotFound: true);
        m_Base_Movement = m_Base.FindAction("Movement", throwIfNotFound: true);
        m_Base_BasicAttack = m_Base.FindAction("BasicAttack", throwIfNotFound: true);
        m_Base_DodgeLeft = m_Base.FindAction("DodgeLeft", throwIfNotFound: true);
        m_Base_DodgeRight = m_Base.FindAction("DodgeRight", throwIfNotFound: true);
        m_Base_FallThroughPlatform = m_Base.FindAction("FallThroughPlatform", throwIfNotFound: true);
        m_Base_SpecialAttack = m_Base.FindAction("SpecialAttack", throwIfNotFound: true);
        m_Base_Block = m_Base.FindAction("Block", throwIfNotFound: true);
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

    // Menu
    private readonly InputActionMap m_Menu;
    private IMenuActions m_MenuActionsCallbackInterface;
    private readonly InputAction m_Menu_ChangeCharacter;
    private readonly InputAction m_Menu_SelectCharacter;
    private readonly InputAction m_Menu_DeselectCharacter;
    public struct MenuActions
    {
        private @FighterActions m_Wrapper;
        public MenuActions(@FighterActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @ChangeCharacter => m_Wrapper.m_Menu_ChangeCharacter;
        public InputAction @SelectCharacter => m_Wrapper.m_Menu_SelectCharacter;
        public InputAction @DeselectCharacter => m_Wrapper.m_Menu_DeselectCharacter;
        public InputActionMap Get() { return m_Wrapper.m_Menu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenuActions set) { return set.Get(); }
        public void SetCallbacks(IMenuActions instance)
        {
            if (m_Wrapper.m_MenuActionsCallbackInterface != null)
            {
                @ChangeCharacter.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnChangeCharacter;
                @ChangeCharacter.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnChangeCharacter;
                @ChangeCharacter.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnChangeCharacter;
                @SelectCharacter.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnSelectCharacter;
                @SelectCharacter.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnSelectCharacter;
                @SelectCharacter.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnSelectCharacter;
                @DeselectCharacter.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnDeselectCharacter;
                @DeselectCharacter.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnDeselectCharacter;
                @DeselectCharacter.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnDeselectCharacter;
            }
            m_Wrapper.m_MenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @ChangeCharacter.started += instance.OnChangeCharacter;
                @ChangeCharacter.performed += instance.OnChangeCharacter;
                @ChangeCharacter.canceled += instance.OnChangeCharacter;
                @SelectCharacter.started += instance.OnSelectCharacter;
                @SelectCharacter.performed += instance.OnSelectCharacter;
                @SelectCharacter.canceled += instance.OnSelectCharacter;
                @DeselectCharacter.started += instance.OnDeselectCharacter;
                @DeselectCharacter.performed += instance.OnDeselectCharacter;
                @DeselectCharacter.canceled += instance.OnDeselectCharacter;
            }
        }
    }
    public MenuActions @Menu => new MenuActions(this);

    // Base
    private readonly InputActionMap m_Base;
    private IBaseActions m_BaseActionsCallbackInterface;
    private readonly InputAction m_Base_Jump;
    private readonly InputAction m_Base_Movement;
    private readonly InputAction m_Base_BasicAttack;
    private readonly InputAction m_Base_DodgeLeft;
    private readonly InputAction m_Base_DodgeRight;
    private readonly InputAction m_Base_FallThroughPlatform;
    private readonly InputAction m_Base_SpecialAttack;
    private readonly InputAction m_Base_Block;
    public struct BaseActions
    {
        private @FighterActions m_Wrapper;
        public BaseActions(@FighterActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump => m_Wrapper.m_Base_Jump;
        public InputAction @Movement => m_Wrapper.m_Base_Movement;
        public InputAction @BasicAttack => m_Wrapper.m_Base_BasicAttack;
        public InputAction @DodgeLeft => m_Wrapper.m_Base_DodgeLeft;
        public InputAction @DodgeRight => m_Wrapper.m_Base_DodgeRight;
        public InputAction @FallThroughPlatform => m_Wrapper.m_Base_FallThroughPlatform;
        public InputAction @SpecialAttack => m_Wrapper.m_Base_SpecialAttack;
        public InputAction @Block => m_Wrapper.m_Base_Block;
        public InputActionMap Get() { return m_Wrapper.m_Base; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(BaseActions set) { return set.Get(); }
        public void SetCallbacks(IBaseActions instance)
        {
            if (m_Wrapper.m_BaseActionsCallbackInterface != null)
            {
                @Jump.started -= m_Wrapper.m_BaseActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_BaseActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_BaseActionsCallbackInterface.OnJump;
                @Movement.started -= m_Wrapper.m_BaseActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_BaseActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_BaseActionsCallbackInterface.OnMovement;
                @BasicAttack.started -= m_Wrapper.m_BaseActionsCallbackInterface.OnBasicAttack;
                @BasicAttack.performed -= m_Wrapper.m_BaseActionsCallbackInterface.OnBasicAttack;
                @BasicAttack.canceled -= m_Wrapper.m_BaseActionsCallbackInterface.OnBasicAttack;
                @DodgeLeft.started -= m_Wrapper.m_BaseActionsCallbackInterface.OnDodgeLeft;
                @DodgeLeft.performed -= m_Wrapper.m_BaseActionsCallbackInterface.OnDodgeLeft;
                @DodgeLeft.canceled -= m_Wrapper.m_BaseActionsCallbackInterface.OnDodgeLeft;
                @DodgeRight.started -= m_Wrapper.m_BaseActionsCallbackInterface.OnDodgeRight;
                @DodgeRight.performed -= m_Wrapper.m_BaseActionsCallbackInterface.OnDodgeRight;
                @DodgeRight.canceled -= m_Wrapper.m_BaseActionsCallbackInterface.OnDodgeRight;
                @FallThroughPlatform.started -= m_Wrapper.m_BaseActionsCallbackInterface.OnFallThroughPlatform;
                @FallThroughPlatform.performed -= m_Wrapper.m_BaseActionsCallbackInterface.OnFallThroughPlatform;
                @FallThroughPlatform.canceled -= m_Wrapper.m_BaseActionsCallbackInterface.OnFallThroughPlatform;
                @SpecialAttack.started -= m_Wrapper.m_BaseActionsCallbackInterface.OnSpecialAttack;
                @SpecialAttack.performed -= m_Wrapper.m_BaseActionsCallbackInterface.OnSpecialAttack;
                @SpecialAttack.canceled -= m_Wrapper.m_BaseActionsCallbackInterface.OnSpecialAttack;
                @Block.started -= m_Wrapper.m_BaseActionsCallbackInterface.OnBlock;
                @Block.performed -= m_Wrapper.m_BaseActionsCallbackInterface.OnBlock;
                @Block.canceled -= m_Wrapper.m_BaseActionsCallbackInterface.OnBlock;
            }
            m_Wrapper.m_BaseActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @BasicAttack.started += instance.OnBasicAttack;
                @BasicAttack.performed += instance.OnBasicAttack;
                @BasicAttack.canceled += instance.OnBasicAttack;
                @DodgeLeft.started += instance.OnDodgeLeft;
                @DodgeLeft.performed += instance.OnDodgeLeft;
                @DodgeLeft.canceled += instance.OnDodgeLeft;
                @DodgeRight.started += instance.OnDodgeRight;
                @DodgeRight.performed += instance.OnDodgeRight;
                @DodgeRight.canceled += instance.OnDodgeRight;
                @FallThroughPlatform.started += instance.OnFallThroughPlatform;
                @FallThroughPlatform.performed += instance.OnFallThroughPlatform;
                @FallThroughPlatform.canceled += instance.OnFallThroughPlatform;
                @SpecialAttack.started += instance.OnSpecialAttack;
                @SpecialAttack.performed += instance.OnSpecialAttack;
                @SpecialAttack.canceled += instance.OnSpecialAttack;
                @Block.started += instance.OnBlock;
                @Block.performed += instance.OnBlock;
                @Block.canceled += instance.OnBlock;
            }
        }
    }
    public BaseActions @Base => new BaseActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    public interface IMenuActions
    {
        void OnChangeCharacter(InputAction.CallbackContext context);
        void OnSelectCharacter(InputAction.CallbackContext context);
        void OnDeselectCharacter(InputAction.CallbackContext context);
    }
    public interface IBaseActions
    {
        void OnJump(InputAction.CallbackContext context);
        void OnMovement(InputAction.CallbackContext context);
        void OnBasicAttack(InputAction.CallbackContext context);
        void OnDodgeLeft(InputAction.CallbackContext context);
        void OnDodgeRight(InputAction.CallbackContext context);
        void OnFallThroughPlatform(InputAction.CallbackContext context);
        void OnSpecialAttack(InputAction.CallbackContext context);
        void OnBlock(InputAction.CallbackContext context);
    }
}