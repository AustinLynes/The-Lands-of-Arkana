// GENERATED AUTOMATICALLY FROM 'Assets/Input/PlayerInputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Lands_of_Arkana
{
    public class @PlayerInputActions : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @PlayerInputActions()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""Player Movement"",
            ""id"": ""36f3c0df-2585-45db-9752-54d296f205fc"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""49087016-2b32-45e9-a086-f7de5a097a3c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Camera"",
                    ""type"": ""PassThrough"",
                    ""id"": ""1082c585-08b5-4aa3-b9c0-d1bd7096132c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e713eca1-2dc6-4e8a-b163-ca4eec4c2d93"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": ""NormalizeVector2"",
                    ""groups"": """",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cb6ad442-695b-4223-b23f-78efe7eddd4b"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone"",
                    ""groups"": """",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""34483da2-542a-4b28-bf08-5edc3011e797"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""715bf42a-1e47-4b6f-886e-b133dfd3dab6"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""46de6424-0285-44e8-a373-0439514d397a"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""4947ed96-47c0-46aa-97bc-71d28130f123"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""c04bff91-3cbf-442b-8af3-d8b7e49b94e9"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Gamepad"",
                    ""id"": ""4625707a-e65b-4d89-ba4d-8fe0eedc3e6e"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""93cc47b3-25a9-4291-9c9a-8a35b04888e8"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""844c28f8-dfd2-44bd-9117-2ea7cc1fb3a6"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""8af5b8cb-4344-4b52-9b9c-014292854a73"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""5d43012c-41e3-48a0-9e9e-54c6ab417064"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""Player Actions"",
            ""id"": ""eca65c51-433b-4d95-b88a-d8252beee38f"",
            ""actions"": [
                {
                    ""name"": ""Roll"",
                    ""type"": ""Button"",
                    ""id"": ""2c9428bb-3281-4315-9e4c-086afaa59612"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Sprint"",
                    ""type"": ""Button"",
                    ""id"": ""286cce97-17ac-44d6-b76e-b79fab9ef47b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""e0f5c45c-b6d6-4829-a1fd-c5e4004bf7e8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AttackRightHand"",
                    ""type"": ""Button"",
                    ""id"": ""88685aae-1418-4947-ae9c-300086bb7053"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ToggleWeapon"",
                    ""type"": ""Button"",
                    ""id"": ""5616a892-e4d4-4aa3-817c-3072c61d3002"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b7319b9b-9686-447e-9915-9bc7bc630bcb"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Roll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ac3a1eaa-c4c9-4396-8ef1-385c054cc468"",
                    ""path"": ""<Keyboard>/v"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Roll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c6b1bb1d-c200-4f75-b37f-14ae70595551"",
                    ""path"": ""<Gamepad>/leftStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ac272740-da28-4a82-a8e9-ed9e26f4c847"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d6668b73-5795-4d13-8fd1-d5c455c8f34f"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AttackRightHand"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bef06c2b-5c01-472e-8579-2a8d391b38b4"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AttackRightHand"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1a09e8c9-c75c-4a85-8d03-42be1c5b4a3a"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8cb85a81-9dce-4e1a-b21c-49d7cfde651f"",
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
                    ""id"": ""8954e1a7-57ca-4733-b547-1d97b4b51fe1"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToggleWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""284668b0-ea73-4161-9169-e4d986f29f1f"",
                    ""path"": ""<Keyboard>/t"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToggleWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Player Movement
            m_PlayerMovement = asset.FindActionMap("Player Movement", throwIfNotFound: true);
            m_PlayerMovement_Movement = m_PlayerMovement.FindAction("Movement", throwIfNotFound: true);
            m_PlayerMovement_Camera = m_PlayerMovement.FindAction("Camera", throwIfNotFound: true);
            // Player Actions
            m_PlayerActions = asset.FindActionMap("Player Actions", throwIfNotFound: true);
            m_PlayerActions_Roll = m_PlayerActions.FindAction("Roll", throwIfNotFound: true);
            m_PlayerActions_Sprint = m_PlayerActions.FindAction("Sprint", throwIfNotFound: true);
            m_PlayerActions_Jump = m_PlayerActions.FindAction("Jump", throwIfNotFound: true);
            m_PlayerActions_AttackRightHand = m_PlayerActions.FindAction("AttackRightHand", throwIfNotFound: true);
            m_PlayerActions_ToggleWeapon = m_PlayerActions.FindAction("ToggleWeapon", throwIfNotFound: true);
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

        // Player Movement
        private readonly InputActionMap m_PlayerMovement;
        private IPlayerMovementActions m_PlayerMovementActionsCallbackInterface;
        private readonly InputAction m_PlayerMovement_Movement;
        private readonly InputAction m_PlayerMovement_Camera;
        public struct PlayerMovementActions
        {
            private @PlayerInputActions m_Wrapper;
            public PlayerMovementActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @Movement => m_Wrapper.m_PlayerMovement_Movement;
            public InputAction @Camera => m_Wrapper.m_PlayerMovement_Camera;
            public InputActionMap Get() { return m_Wrapper.m_PlayerMovement; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(PlayerMovementActions set) { return set.Get(); }
            public void SetCallbacks(IPlayerMovementActions instance)
            {
                if (m_Wrapper.m_PlayerMovementActionsCallbackInterface != null)
                {
                    @Movement.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMovement;
                    @Movement.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMovement;
                    @Movement.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMovement;
                    @Camera.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnCamera;
                    @Camera.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnCamera;
                    @Camera.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnCamera;
                }
                m_Wrapper.m_PlayerMovementActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Movement.started += instance.OnMovement;
                    @Movement.performed += instance.OnMovement;
                    @Movement.canceled += instance.OnMovement;
                    @Camera.started += instance.OnCamera;
                    @Camera.performed += instance.OnCamera;
                    @Camera.canceled += instance.OnCamera;
                }
            }
        }
        public PlayerMovementActions @PlayerMovement => new PlayerMovementActions(this);

        // Player Actions
        private readonly InputActionMap m_PlayerActions;
        private IPlayerActionsActions m_PlayerActionsActionsCallbackInterface;
        private readonly InputAction m_PlayerActions_Roll;
        private readonly InputAction m_PlayerActions_Sprint;
        private readonly InputAction m_PlayerActions_Jump;
        private readonly InputAction m_PlayerActions_AttackRightHand;
        private readonly InputAction m_PlayerActions_ToggleWeapon;
        public struct PlayerActionsActions
        {
            private @PlayerInputActions m_Wrapper;
            public PlayerActionsActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @Roll => m_Wrapper.m_PlayerActions_Roll;
            public InputAction @Sprint => m_Wrapper.m_PlayerActions_Sprint;
            public InputAction @Jump => m_Wrapper.m_PlayerActions_Jump;
            public InputAction @AttackRightHand => m_Wrapper.m_PlayerActions_AttackRightHand;
            public InputAction @ToggleWeapon => m_Wrapper.m_PlayerActions_ToggleWeapon;
            public InputActionMap Get() { return m_Wrapper.m_PlayerActions; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(PlayerActionsActions set) { return set.Get(); }
            public void SetCallbacks(IPlayerActionsActions instance)
            {
                if (m_Wrapper.m_PlayerActionsActionsCallbackInterface != null)
                {
                    @Roll.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnRoll;
                    @Roll.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnRoll;
                    @Roll.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnRoll;
                    @Sprint.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnSprint;
                    @Sprint.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnSprint;
                    @Sprint.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnSprint;
                    @Jump.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnJump;
                    @Jump.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnJump;
                    @Jump.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnJump;
                    @AttackRightHand.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnAttackRightHand;
                    @AttackRightHand.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnAttackRightHand;
                    @AttackRightHand.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnAttackRightHand;
                    @ToggleWeapon.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnToggleWeapon;
                    @ToggleWeapon.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnToggleWeapon;
                    @ToggleWeapon.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnToggleWeapon;
                }
                m_Wrapper.m_PlayerActionsActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Roll.started += instance.OnRoll;
                    @Roll.performed += instance.OnRoll;
                    @Roll.canceled += instance.OnRoll;
                    @Sprint.started += instance.OnSprint;
                    @Sprint.performed += instance.OnSprint;
                    @Sprint.canceled += instance.OnSprint;
                    @Jump.started += instance.OnJump;
                    @Jump.performed += instance.OnJump;
                    @Jump.canceled += instance.OnJump;
                    @AttackRightHand.started += instance.OnAttackRightHand;
                    @AttackRightHand.performed += instance.OnAttackRightHand;
                    @AttackRightHand.canceled += instance.OnAttackRightHand;
                    @ToggleWeapon.started += instance.OnToggleWeapon;
                    @ToggleWeapon.performed += instance.OnToggleWeapon;
                    @ToggleWeapon.canceled += instance.OnToggleWeapon;
                }
            }
        }
        public PlayerActionsActions @PlayerActions => new PlayerActionsActions(this);
        public interface IPlayerMovementActions
        {
            void OnMovement(InputAction.CallbackContext context);
            void OnCamera(InputAction.CallbackContext context);
        }
        public interface IPlayerActionsActions
        {
            void OnRoll(InputAction.CallbackContext context);
            void OnSprint(InputAction.CallbackContext context);
            void OnJump(InputAction.CallbackContext context);
            void OnAttackRightHand(InputAction.CallbackContext context);
            void OnToggleWeapon(InputAction.CallbackContext context);
        }
    }
}
