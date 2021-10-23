using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Lands_of_Arkana
{
    public class InputManager : MonoBehaviour
    {
        
        public float Horizontal;
        public float Vertical;
        
        public float MoveMagnitude;

        public float MouseX;
        public float MouseY;

        public bool RollFlag;
        public bool ToggleWeaponFlag;


        public bool SprintFlag;
        public bool ComboFlag;
        public bool JumpFlag;

        public bool LightAttackFlag;
        public bool HeavyAttackFlag;
        public bool AttackFlag;

        public bool Input_NORTH;
        public bool Input_EAST;
        public bool Input_SOUTH;
        public bool Input_WEST;


        public float AttackInputTimer = 0.0f;
        
        PlayerInputActions InputActions;

        Vector2 MovementInput;
        Vector2 CameraInput;


        public void Init()
        {
            if(InputActions == null)
            {
                InputActions = new PlayerInputActions();
                InputActions.PlayerMovement.Movement.performed += InputActions => MovementInput = InputActions.ReadValue<Vector2>();
                InputActions.PlayerMovement.Camera.performed += value => CameraInput = value.ReadValue<Vector2>();
                
            }

            InputActions.Enable();

            Player = GameManager.Instance.Player;
            Inventory = GameManager.Instance.Player.Inventory;
            CombatController = GameManager.Instance.Player.GetComponent<CombatManager>();
        }



        public void OnDisable()
        {
            InputActions.Disable();

        }

        public void Tick(float deltaTime)
        {
            MoveInput(deltaTime);
            RollInput(deltaTime);
            JumpInput(deltaTime);
            SprintInput(deltaTime);
            AttackInput(deltaTime);
            ToggleWeaponInput();
        }


        private void MoveInput(float deltaTime)
        {
            Horizontal = MovementInput.x;
            Vertical = MovementInput.y;
            // clamp the movement amount from 0 -> 1
            // do this because Horizontal + Vertical could be more than 1
            MoveMagnitude = Mathf.Clamp01(Mathf.Abs(Horizontal) + Mathf.Abs(Vertical));
            
            MouseX = CameraInput.x;
            MouseY = CameraInput.y;

        }

        public void SprintInput(float delta)
        {
            Input_SOUTH = InputActions.PlayerActions.Sprint.phase == UnityEngine.InputSystem.InputActionPhase.Started;

            if (Input_SOUTH)
            {
                   SprintFlag = true;
            }
        }

        public void RollInput(float delta)
        {

            Input_EAST = InputActions.PlayerActions.Roll.phase == UnityEngine.InputSystem.InputActionPhase.Started;

            if (Input_EAST)
            {
                RollFlag = true;
            }
        }

        bool hasInitilizedAttack = false;

        public void ToggleWeaponInput()
        {
            Input_NORTH = InputActions.PlayerActions.ToggleWeapon.phase == UnityEngine.InputSystem.InputActionPhase.Started;

            if (Input_NORTH)
            {
                ToggleWeaponFlag = true;
            }
        }

        public void AttackInput(float delta)
        {

            Input_WEST = InputActions.PlayerActions.AttackRightHand.phase == UnityEngine.InputSystem.InputActionPhase.Started;
           

            if (Input_WEST)
            {

                if (Player.CanCombo)
                {
                    ComboFlag = true;

                    CombatController.HandleCombo(Inventory.DEBUG_sword);

                    ComboFlag = false;
                }

                AttackInputTimer += delta;
                hasInitilizedAttack = true;

            }
            else
            {
                if (hasInitilizedAttack)
                {
                    if (AttackInputTimer > 0.25f)
                    {
                        LightAttackFlag = false;
                        HeavyAttackFlag = true;
                    }
                    else
                    {
                        LightAttackFlag = true;
                    }


                    hasInitilizedAttack = false;
                    AttackInputTimer = 0;

                }
            }

        }

        void JumpInput(float deltaTime)
        {
            Input_SOUTH = InputActions.PlayerActions.Jump.phase == UnityEngine.InputSystem.InputActionPhase.Started;
            if (Input_SOUTH)
            {
                JumpFlag = true;
            }
        }

        PlayerController Player;
        PlayerInventory Inventory;
        CombatManager CombatController;
    }
}
