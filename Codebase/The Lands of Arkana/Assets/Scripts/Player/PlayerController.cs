using UnityEngine;

namespace Lands_of_Arkana
{

    [RequireComponent(typeof(Locomotion))]
    public class PlayerController : MonoBehaviour
    {
        [HideInInspector] public InputManager InputHandler;
        [HideInInspector] public AnimationController AnimationControl;
        [HideInInspector] public Locomotion LocomotionControl;

        [HideInInspector] public bool IsInteracting;
        [HideInInspector] public bool IsInAir;
        [HideInInspector] public bool IsGrounded;


        public void Init()
        {
            InputHandler = GameManager.Instance.InputHandler;

            LocomotionControl = GetComponent<Locomotion>();
            LocomotionControl.Init();

            AnimationControl = GetComponentInChildren<AnimationController>();
            AnimationControl.Init();

        }

        public void Tick(float deltaTime)
        {

            LocomotionControl.Tick(deltaTime);

            IsInteracting = AnimationControl.GetAnimator().GetBool("isInteracting");

        }

        public void FixedTick(float fixedDeltaTime)
        {
            LocomotionControl.FixedTick(fixedDeltaTime);
        }

        public void LateTick()
        {
            LocomotionControl.LateTick();



            InputHandler.RollFlag = false;
            InputHandler.SprintFlag = false;

            if (IsInAir)
            {
                LocomotionControl.InAirTimer = LocomotionControl.InAirTimer + Time.deltaTime;

            }
        }


    }
}