using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lands_of_Arkana
{
    public class CombatManager : MonoBehaviour
    {
        public void Init()
        {
            m_anim = GetComponentInChildren<AnimationController>();
        }

        public void HandleCombo(WeaponItem weapon, bool isLeftHanded = false)
        {
            comboCounter = 0;

            if (GameManager.Instance.InputHandler.ComboFlag)
            {
                string id = weapon.LightAttacks[comboCounter].AnimationID;
                if (isLeftHanded)
                    id += "(Left)";
                
                m_anim.GetAnimator().SetBool("canCombo", false);

                if(lastAnim == id)
                {
                    IncrementComboCounter(weapon);
                    id = weapon.LightAttacks[comboCounter].AnimationID;
                    if (isLeftHanded)
                        id += "(Left)";
                    m_anim.PlayTargetAnimation(id, true);
                }
                else
                {
                    comboCounter = 0;
                    id = weapon.LightAttacks[comboCounter].AnimationID;
                    if (isLeftHanded)
                        id += "(Left)";
                    m_anim.PlayTargetAnimation(id, true);
                }
            }

        }
  
        public void HandleLightAttack(WeaponItem weapon, bool isLeftHanded = false)
        {
            comboCounter = 0;
            string id = weapon.LightAttacks[comboCounter].AnimationID;
            if (isLeftHanded)
                id += "(Left)";
            m_anim.PlayTargetAnimation(id, true, 0.05f);
            lastAnim = id;
        }

        public void HandleHeavyAttack(WeaponItem weapon, bool isLeftHanded = false)
        {
            comboCounter = 0;
            string id = weapon.HeavyAttack.AnimationID;
            if (isLeftHanded)
                id += "(Left)";
            m_anim.PlayTargetAnimation(id, true, 0.05f);
            lastAnim = id;

        }
        
        void IncrementComboCounter(WeaponItem weapon)
        {
            comboCounter++;
            int maxComboCounter = weapon.LightAttacks.Count;
            if (comboCounter > maxComboCounter)
            {
                comboCounter = 0;
            }

        }

        AnimationController m_anim;
        
        
        string lastAnim;
        int comboCounter;

    }

}