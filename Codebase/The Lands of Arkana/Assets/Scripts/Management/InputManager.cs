using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Lands_of_Arkana
{
    public class InputManager : MonoBehaviour
    {
        
        public float Horizontal;
        public float Vertical;
        
        public float MoveAmount;

        public float MouseX;
        public float MouseY;

        public bool RollFlag;
        
        public bool SprintFlag;

        public bool Input_EAST;
        public bool Input_SOUTH;

        PlayerInputActions InputActions;

        Vector2 MovementInput;
        Vector2 CameraInput;


        public void OnEnable()
        {
            if(InputActions == null)
            {
                InputActions = new PlayerInputActions();
                InputActions.PlayerMovement.Movement.performed += InputActions => MovementInput = InputActions.ReadValue<Vector2>();
                InputActions.PlayerMovement.Camera.performed += value => CameraInput = value.ReadValue<Vector2>();
                
            }

            InputActions.Enable();
        }



        public void OnDisable()
        {
            InputActions.Disable();

        }

        public void Tick(float deltaTime)
        {
            MoveInput(deltaTime);
            RollInput(deltaTime);
            SprintInput(deltaTime);
        }


        private void MoveInput(float deltaTime)
        {
            Horizontal = MovementInput.x;
            Vertical = MovementInput.y;
            // clamp the movement amount from 0 -> 1
            // do this because Horizontal + Vertical could be more than 1
            MoveAmount = Mathf.Clamp01(Mathf.Abs(Horizontal) + Mathf.Abs(Vertical));
            
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


    }
}
