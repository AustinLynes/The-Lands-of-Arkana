using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lands_of_Arkana
{
    [RequireComponent(typeof(Rigidbody))]
    public class Locomotion : MonoBehaviour
    {
        public bool IsSprinting;
        [Header("Ground and Air Detection")]
        public float groundDetectionRayStart = 0.5f;
        public float LandCheckDistance = 1.0f;
        public float groundDetectionRayDistance = 0.2f;
        LayerMask ignoreForGroundCheck;
        public float InAirTimer;

        public Rigidbody GetRigidbody()
        {
            return rigidbody;
        }

        public void Init()
        {
            rigidbody = GetComponent<Rigidbody>();
            InitilizeRigidbody();

            inputManager = GameManager.Instance.InputHandler;
            camera = GameManager.Instance.CameraControl.transform;

            m_animController = GetComponentInChildren<AnimationController>();

            m_transform = transform;
            Control = GetComponent<PlayerController>();
            Control.IsGrounded = true;
            ignoreForGroundCheck = ~(1 << 8 | 1 << 11);
        }

        public void Tick(float deltaTime)
        {
            IsSprinting = inputManager.Input_SOUTH;

            HandleMovement();
            HandleRoll(deltaTime);

            HandleFalling(deltaTime, MoveDirection);

            if (m_animController.IsRotationAllowed)
            {
                HandleRotation(deltaTime);
            }

            m_animController.UpdateAnimationValues(inputManager.MoveAmount, 0, IsSprinting, deltaTime);
        }

        public void FixedTick(float fixedDeltaTime)
        {

        }

        public void LateTick()
        {

        }


        void HandleMovement()
        {
            if (GetComponent<PlayerController>().IsInteracting)
                return;


            MoveDirection = CalculateMoveDirection();
            MoveDirection.Normalize();
            MoveDirection.y = 0;

            float speed = m_properties.RunSpeed;

            if (inputManager.SprintFlag)
            {
                speed = m_properties.SprintSpeed;
                IsSprinting = true;
                MoveDirection *= speed;
            }
            else
            {

                MoveDirection *= speed;
            }


            Vector3 velocity = Vector3.ProjectOnPlane(MoveDirection, normVector);
            rigidbody.velocity = velocity;
        }


        void HandleRotation(float deltaTime)
        {
            Vector3 targetDir = Vector3.zero;
            float moveOverride = inputManager.MoveAmount;

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

        void HandleRoll(float deltaTime)
        {
            if (m_animController.GetAnimator().GetBool("isInteracting"))
                return;

            if (inputManager.RollFlag)
            {
                MoveDirection = CalculateMoveDirection();
                MoveDirection.Normalize();

                if (inputManager.MoveAmount > 0)
                {
                    m_animController.PlayTargetAnimation("Roll_Forward", true);
                    MoveDirection.y = 0;
                    Quaternion rollRotation = Quaternion.LookRotation(MoveDirection);
                    m_transform.rotation = rollRotation;
                }
                else
                {
                    m_animController.PlayTargetAnimation("Back_Step", true);
                }

            }
        }

        public void HandleFalling(float delta, Vector3 moveDirection)
        {
            Control.IsGrounded = false;
            RaycastHit hit;
            Vector3 origin = m_transform.position;
            origin.y += 0.5f;

            // is something in front of me? 
            if (Physics.Raycast(origin, m_transform.forward, out hit, 0.4f))
            {
                moveDirection = Vector3.zero;
            }

            if (Control.IsInAir)
            {
                rigidbody.AddForce(-Vector3.up * m_properties.FallSpeed);
                rigidbody.AddForce(moveDirection * m_properties.FallSpeed / 10.0f);

            }

            Vector3 dir = moveDirection;
            dir.Normalize();

            origin = origin + dir * groundDetectionRayDistance;
            
            targetPosition = m_transform.position;

            Debug.DrawRay(origin, -Vector3.up * LandCheckDistance, Color.red);

            if (Physics.Raycast(origin, -Vector3.up, out hit, LandCheckDistance))
            {
                normVector = hit.normal;
                Vector3 tp = hit.point;

                Control.IsGrounded = true;
                targetPosition.y = tp.y;
                if (Control.IsInAir)
                {
                    if (InAirTimer > 0.5f && InAirTimer < 1.0f)
                    {
                        m_animController.PlayTargetAnimation("Land", true);
                        InAirTimer = 0;

                    }
                    else if (InAirTimer >= 1.0f)
                    {
                        m_animController.PlayTargetAnimation("Land_Hard", true);
                        InAirTimer = 0;

                    }
                    else
                    {
                        m_animController.PlayTargetAnimation("Locomotion", false);
                        InAirTimer = 0;
                    }

                    Control.IsInAir = false;
                }
            }
            else
            {
                if (Control.IsGrounded)
                {
                    Control.IsGrounded = false;
                }

                if(Control.IsInAir == false)
                {
                    if(Control.IsInteracting == false)
                    {
                        m_animController.PlayTargetAnimation("Falling", true);
                        Vector3 vel = rigidbody.velocity;
                        vel.Normalize();

                        rigidbody.velocity = vel * (m_properties.FallSpeed / 2);
                        Control.IsInAir = true;
                    }
                }
            }

            if (Control.IsGrounded)
            {
                if(Control.IsInteracting || inputManager.MoveAmount > 0)
                {
                    m_transform.position = Vector3.Lerp(m_transform.position, targetPosition, 10.0f * Time.deltaTime);
                }
                else
                {
                    m_transform.position = targetPosition;
                }
            }
        }
        Vector3 CalculateMoveDirection()
        {
            Vector3 moveDir = Vector3.zero;

            moveDir = camera.forward * inputManager.Vertical;
            moveDir += camera.right * inputManager.Horizontal;

            return moveDir;
        }

        void InitilizeRigidbody()
        {
            rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
        }

        // Cache
        // Movement
        public Vector3 MoveDirection;
        Vector3 normVector;
        Vector3 targetPosition;

        // Physics 
        Rigidbody rigidbody;

        Vector3 SmoothFallVelocity = Vector3.zero;
        // Camera
        Transform camera;

        // Input Manager
        InputManager inputManager;


        // Members
        Transform m_transform;

        [SerializeField] LocomotionProperties m_properties;
        AnimationController m_animController;

        PlayerController Control;
    }
}
