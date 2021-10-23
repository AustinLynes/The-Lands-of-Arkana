using UnityEngine;

namespace Lands_of_Arkana
{

    [RequireComponent(typeof(Locomotion))]
    public class PlayerController : MonoBehaviour
    {
        [HideInInspector] public InputManager InputHandler;
        [HideInInspector] public AnimationController AnimationControl;
        [HideInInspector] public Locomotion LocomotionControl;
        [HideInInspector] public PlayerInventory Inventory;

        [HideInInspector] public bool PerformingAction;
        [HideInInspector] public bool CanCombo;

        public bool IsRotationAllowed { get => m_canRotate; }

        public void AllowRotation() { m_canRotate = true; }
        public void StopRotation() { m_canRotate = false; }


        public void Init()
        {
            InputHandler = GameManager.Instance.InputHandler;

            LocomotionControl = GetComponent<Locomotion>();
            LocomotionControl.Init();

            AnimationControl = GetComponentInChildren<AnimationController>();
            AnimationControl.Init();

            Inventory = GetComponent<PlayerInventory>();
            Inventory.Init();


            InputHandler.Init();
            
            AllowRotation();

        }

        public void Tick(float deltaTime)
        {
            PerformingAction = AnimationControl.GetAnimator().GetBool("isInteracting");
            CanCombo = AnimationControl.GetAnimator().GetBool("canCombo");

            LocomotionControl.Tick(deltaTime);
            Inventory.Tick(deltaTime);
           
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
            InputHandler.JumpFlag = false;

            InputHandler.LightAttackFlag = false;
            InputHandler.HeavyAttackFlag = false;
            

            
        }

        bool m_canRotate = true;
    }
}