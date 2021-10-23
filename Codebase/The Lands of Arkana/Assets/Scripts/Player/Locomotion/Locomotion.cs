using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lands_of_Arkana
{


    [RequireComponent(typeof(Rigidbody))]
    public class Locomotion : MonoBehaviour
    {
        [HideInInspector] public bool IsSprinting;
        [HideInInspector] public float InAirTimer;
        [HideInInspector] public Vector3 MoveDirection;
        [HideInInspector] public bool Jumped;
        [HideInInspector] public Vector3 LastMoveDir;

        public Rigidbody PhysicsBody { get => rigidbody; }

        public void Init()
        {
            InitilizeRigidbody();

            inputManager = GameManager.Instance.InputHandler;
            camera = GameManager.Instance.CameraControl.transform;

            m_animController = GetComponentInChildren<AnimationController>();

            m_transform = transform;
            Control = GetComponent<PlayerController>();

            CombatHandler = GetComponent<CombatManager>();
            CombatHandler.Init();



            IsGrounded = true;

        }

        public void Tick(float deltaTime)
        {
            m_animController.GetAnimator().SetBool("isInAir", IsInAir);
            IdleTimer = m_animController.GetAnimator().GetFloat("Idle");
            
            HandleIdle();
            HandleIsGrounded(deltaTime);
            
            HandleMovement(deltaTime);
            HandleCombat(deltaTime);
            HandleEvade(deltaTime);
            
            if (Control.IsRotationAllowed)
                HandleRotation(deltaTime);

            m_animController.UpdateAnimationValues(inputManager.MoveMagnitude, 0, IsSprinting, deltaTime);
        }

        public void FixedTick(float fixedDeltaTime)
        {

        }

        public void LateTick()
        {

        }
      
        
        #region Locomotion Handlers
        void HandleIdle()
        {
            if (inputManager.MoveMagnitude < 0.1f)
            {
                IdleTimer += Time.deltaTime;
            }
            else
            {
                IdleTimer = 0;
            }

            m_animController.GetAnimator().SetFloat("Idle", IdleTimer);
        }
        
        void HandleMovement(float deltaTime)
        {
            if (Control.PerformingAction)
                return;

            if (IsGrounded)
                MoveDirection = CalculateMoveDirection();
            else
                MoveDirection = LastMoveDir;

            MoveDirection.Normalize();
            MoveDirection.y = LastMoveDir.y;
            LastMoveDir = MoveDirection;


            float speed = CalculateMoveSpeed();
            MoveDirection = new Vector3(
                MoveDirection.x * speed,
                MoveDirection.y * Mathf.Clamp(speed, m_properties.WalSpeed, m_properties.RunSpeed),
                MoveDirection.z * speed
                );


            HandleJump(deltaTime);

            Vector3 velocity = Vector3.ProjectOnPlane(MoveDirection, normVector);
            rigidbody.velocity = velocity;

        }

        void HandleRotation(float deltaTime)
        {

            Vector3 targetDir = Vector3.zero;
            float moveOverride = inputManager.MoveMagnitude;

            targetDir = CalculateMoveDirection();
            targetDir.Normalize();
            targetDir.y = 0;

            if (targetDir == Vector3.zero)
                targetDir = m_transform.forward;


            float rs = m_properties.RotationSpeed;
            Quaternion tr = Quaternion.LookRotation(targetDir);
            Quaternion targetRotation = Quaternion.Slerp(m_transform.rotation, tr, rs * deltaTime);

            m_transform.rotation = targetRotation;


        }

        void HandleEvade(float deltaTime)
        {
            if (Control.PerformingAction)
                return;

            if (inputManager.RollFlag)
            {
                MoveDirection = CalculateMoveDirection();
                MoveDirection.Normalize();

                if (inputManager.MoveMagnitude > 0)
                {
                    m_animController.PlayTargetAnimation("Roll_Forward", true, 0.05f);
                    //MoveDirection.y = 0;
                    Quaternion rollRotation = Quaternion.LookRotation(MoveDirection);
                    m_transform.rotation = rollRotation;
                }
                else
                {
                    m_animController.PlayTargetAnimation("Back_Step", true, 0.05f);
                }

            }
        }

        void HandleCombat(float deltaTime)
        {
            if (Control.PerformingAction)
                return;
            if (Control.Inventory.WeaponsEquipped)
            {

                if (inputManager.LightAttackFlag)
                {
                    CombatHandler.HandleLightAttack(
                        Control.Inventory.DEBUG_sword
                        //inputManager.LeftHandAttack
                        );

                    //inputManager.LeftHandAttack = false;
                    inputManager.AttackFlag = false;

                }
                else if (inputManager.HeavyAttackFlag)
                {
                    CombatHandler.HandleHeavyAttack(
                       Control.Inventory.DEBUG_sword
                       );

                    inputManager.AttackFlag = false;

                }
            }

        }

        void HandleJump(float deltaTime)
        {
            if (Control.PerformingAction)
                return;

            if (inputManager.JumpFlag && IsGrounded)
            {
                IsGrounded = false;
                //rigidbody.AddForce(Vector3.up * m_properties.JumpForce, m_properties.JumpForceMode);
                LastMoveDir = new Vector3(LastMoveDir.x, m_properties.JumpForce, LastMoveDir.z);
                Jumped = true;
                Control.StopRotation();
            }
        }

        void HandleIsGrounded(float deltaTime)
        {
            Vector3 origin = transform.position;
            origin += transform.forward * m_properties.GroundCheckOffset.z;
            origin.y += m_properties.GroundCheckOffset.y;


            RaycastHit hit;
            Vector3 targetPosition = transform.position;
            // Handle Grounding
            // Are we currently on the ground?
            if (Physics.Raycast(origin, -Vector3.up, out hit, m_properties.LandCheckDistance, m_properties.GroundMask))
            {
                InAirTimer = 0;
                IsGrounded = true;
                IsInAir = false;

                targetPosition = hit.point;
                transform.position = targetPosition;
                Control.AllowRotation();
            }
            else // no?
            {

                if (!IsGrounded)
                {
                    // then is grounded is false
                    IsGrounded = false;
                    IsInAir = true;
                    InAirTimer = InAirTimer + deltaTime;

                    float T2 = deltaTime * deltaTime;
                    LastMoveDir += new Vector3(LastMoveDir.x, -m_properties.Gravity * m_properties.Mass * T2, LastMoveDir.z);
                    //_lastMoveDirY -= Gravity * Mass * T2;

                }
            }


        }

        #endregion

       
        #region Helpers
        private float CalculateMoveSpeed()
        {
            float moveSpeed = m_properties.RunSpeed;

            // Is the Player Currently Sprinting ?
            // Are they Currently Pressing forward more than half the stick ?
            if (inputManager.SprintFlag && inputManager.MoveMagnitude > 0.5f)
            {
                moveSpeed = m_properties.SprintSpeed;
                IsSprinting = true;
            }
            else
            {
                // The Player Is not Sprinting.
                // The player Should Run when their MoveMagnitude is greater than half of the 
                // stick. or when an analog button is pressed
                if (inputManager.MoveMagnitude > 0.75f)
                {
                    moveSpeed = m_properties.RunSpeed;
                    IsSprinting = false;
                }
                else
                {
                    // the player is trying to walk
                    moveSpeed = m_properties.WalSpeed;
                    IsSprinting = false;
                }
            }

            return moveSpeed;
        }

        public Vector3 CalculateMoveDirection()
        {
            Vector3 moveDir = Vector3.zero;
            
            moveDir = camera.forward * inputManager.Vertical;
            moveDir += camera.right * inputManager.Horizontal;

            return moveDir;
        }

        void InitilizeRigidbody()
        {
            rigidbody = GetComponent<Rigidbody>();
            rigidbody.mass = m_properties.Mass;
            rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
        }
        #endregion

        #region Debug
        private void OnDrawGizmos()
        {
            m_properties.OnDebugDrawGizmos(transform);

        }
        #endregion

        [HideInInspector] public bool IsInAir;
        public bool IsGrounded;
        public float IdleTimer = 0;

        // Cache
        // Movement
        Vector3 normVector;
        Vector3 targetPosition;

        // Physics 
        Rigidbody rigidbody;

        Vector3 SmoothFallVelocity = Vector3.zero;
        // Camera
        Transform camera;

        // Input Manager
        InputManager inputManager;

        PlayerController Control;

        [SerializeField] LocomotionProperties m_properties;
        AnimationController m_animController;


        CombatManager CombatHandler { get; set; }
        //private float _lastMoveDirY;

     
        Transform m_transform;
    }
}
