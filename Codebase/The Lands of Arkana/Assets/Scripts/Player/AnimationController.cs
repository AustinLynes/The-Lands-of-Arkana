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

        public void PlayTargetAnimation(string animationID, bool isInteracting, float blendTime = 0.2f)
        {
            m_animatorController.applyRootMotion = isInteracting;
            m_animatorController.SetBool("isInteracting", isInteracting);
            m_animatorController.CrossFade(animationID, blendTime);
            
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

        public void EnableCombo()
        {
            m_animatorController.SetBool("canCombo", true);
        }
        public void DisableCombo()
        {
            m_animatorController.SetBool("canCombo", false);
        }

        public void AddSwordToHand()
        {
            Control.Inventory.WeaponsManager.LoadWeapon(
                Control.Inventory.WeaponsManager.BackHolder_Sword.CurrentWeapon,
                EquipSlot.Right_Hand
                );
        }

        public void AddSwordToSheath()
        {
            Control.Inventory.WeaponsManager.LoadWeapon(
                Control.Inventory.WeaponsManager.RightHandHolder.CurrentWeapon,
                EquipSlot.Back_Sword
                );
        }

        public void PlayerCanSheath()
        {
            Control.Inventory.WeaponsManager.CanSheathWeapon = true;
        }

        public Animator GetAnimator() { return m_animatorController; }


        int m_vertical;
        int m_horizontal;




        Animator m_animatorController;

        private void OnAnimatorMove()
        {
            if (Control.PerformingAction == false)
                return;

            UpdatePhysicsBodyVelocity();

        }

        void UpdatePhysicsBodyVelocity()
        {
            float delta = Time.deltaTime;
            locomotion.PhysicsBody.drag = 0;

            Vector3 deltaPosition = m_animatorController.deltaPosition;
            deltaPosition.y = 0;

            Vector3 velocity = deltaPosition / delta;

            locomotion.PhysicsBody.velocity = velocity;
        }

        InputManager inputManager;
        Locomotion locomotion;


        PlayerController Control;
        public float JumpTransitionHeight = 2.0f;
        public float JumpTransitionLerpScalar = 0.1f;
    }


}