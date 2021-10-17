using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lands_of_Arkana
{
    public class AnimationController : MonoBehaviour
    {
        public void Init()
        {
            Control = GetComponentInParent<PlayerController>();

            inputManager = GameManager.Instance.InputHandler;
            locomotion = GetComponentInParent<Locomotion>();
            m_animatorController = GetComponent<Animator>();
            m_animatorController.applyRootMotion = false;

            m_vertical = Animator.StringToHash("Vertical");
            m_horizontal = Animator.StringToHash("Horizontal");
        }

        public void PlayTargetAnimation(string animationID, bool isInteracting)
        {
            m_animatorController.applyRootMotion = isInteracting;
            m_animatorController.SetBool("isInteracting", isInteracting);
            m_animatorController.CrossFade(animationID, 0.2f);
            
        }

        public void UpdateAnimationValues(float horizontal, float vertical, bool isSprinting, float deltaTime)
        {
            // This part may be unnecissary because the Tutorial is creating a Souls like Controller..
            // I May want to expand and make it more fluid.

            #region Vertical Clamp Value
            float v = 0;
            if (vertical > 0 && vertical < 0.55f)
            {
                v = 0.5f;
            }
            else if (vertical > 0.55f)
            {
                v = 1.0f;
            }
            else if (vertical < 0 && vertical > -0.55f)
            {
                v = -0.5f;
            }
            else if (vertical < -0.55f)
            {
                v = -1.0f;
            }
            else
            {
                v = 0;
            }

            #endregion

            #region Horizontal Clamp Values

            float h = 0;
            if (horizontal > 0 && horizontal < 0.55f)
            {
                h = 0.5f;
            }
            else if (horizontal > 0.55f)
            {
                h = 1.0f;
            }
            else if (horizontal < 0 && horizontal > -0.55f)
            {
                h = -0.5f;
            }
            else if (horizontal < -0.55f)
            {
                h = -1.0f;
            }
            else
            {
                h = 0;
            }

            #endregion

            if (isSprinting)
            {
                v = 2;
            }

            m_animatorController.SetFloat(m_vertical, v, 0.1f, deltaTime);
            m_animatorController.SetFloat(m_horizontal, h, 0.1f, deltaTime);

        }

        public Animator GetAnimator() { return m_animatorController; }
        public bool IsRotationAllowed { get => m_canRotate; }

        public void AllowRotation() { m_canRotate = true; }
        public void StopRotate() { m_canRotate = false; }

        int m_vertical;
        int m_horizontal;

        [SerializeField]bool m_canRotate;


        Animator m_animatorController;

        private void OnAnimatorMove() // this is not being called...
        {
            if (Control.IsInteracting == false)
                return;

            float delta = Time.deltaTime;
            locomotion.GetRigidbody().drag = 0;

            Vector3 deltaPosition = m_animatorController.deltaPosition;
            deltaPosition.y = 0;
            Vector3 velocity = deltaPosition / delta;
            locomotion.GetRigidbody().velocity = velocity;

        }
        InputManager inputManager;
        Locomotion locomotion;


        PlayerController Control;
    }


}