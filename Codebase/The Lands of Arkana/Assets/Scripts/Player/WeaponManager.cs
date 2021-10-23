using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Lands_of_Arkana
{

    public class WeaponManager : MonoBehaviour
    {
        [HideInInspector] public WeaponHolder LeftHandHolder;
        [HideInInspector] public WeaponHolder RightHandHolder;
        [HideInInspector] public WeaponHolder BackHolder_Sword;
        [HideInInspector] public WeaponHolder BackHolder_Shield;
        [HideInInspector] public bool CanSheathWeapon = true;
        
        bool toHands = true;

        WeaponHolder[] WeaponSlots;
        Animator m_anim;


        public void Init()
        {
            // find all weapon slots
            WeaponSlots = GetComponentsInChildren<WeaponHolder>();
            m_anim = GetComponentInChildren<Animator>();

            // determine which is left and which is right

            FindAllWeaponSlots();
        }

        public void Tick(float deltaTime)
        {
            if (GameManager.Instance.InputHandler.ToggleWeaponFlag)
            {
                if (CanSheathWeapon)
                {
                    if (toHands)
                    {
                        m_anim.CrossFade("Draw Sword", 0.05f);
                        toHands = false;
                    }
                    else if(!toHands)
                    {
                        m_anim.CrossFade("Sheathe Sword", 0.05f);
                        toHands = true;
                    }
                    CanSheathWeapon = false;
                }
                GameManager.Instance.InputHandler.ToggleWeaponFlag = false;

            }
        }

        void FindAllWeaponSlots()
        {
            foreach (WeaponHolder slot in WeaponSlots)
            {
                switch (slot.Slot)
                {
                    case EquipSlot.Left_Hand:
                        LeftHandHolder = slot;
                        break;
                    case EquipSlot.Right_Hand:
                        RightHandHolder = slot;

                        break;
                    case EquipSlot.Back_Sword:
                        BackHolder_Sword = slot;
                        break;
                    case EquipSlot.Back_Shield:
                        BackHolder_Shield = slot;

                        break;
                    default:
                        break;
                }

            }
        }

        public void LoadWeapon(WeaponItem weapon, EquipSlot slot)
        {

            switch (slot)
            {
                case EquipSlot.Left_Hand:
                    {
                        LeftHandHolder.LoadWeapon(weapon);
                        LeftHandHolder.transform.localRotation = Quaternion.Euler(weapon.RotationOffset);
                        m_anim.CrossFade(weapon.IdleAnimationID + "(Left)", 0.2f);
                        
                        if(BackHolder_Shield.HasWeapon)
                            BackHolder_Shield.Unload();

                    }
                    break;
                case EquipSlot.Right_Hand:
                    {
                        RightHandHolder.LoadWeapon(weapon);
                        RightHandHolder.transform.localRotation = Quaternion.Euler(weapon.RotationOffset);

                        // place the holder in the correct position
                        RightHandHolder.transform.localPosition = weapon.PositionOffset;
                        RightHandHolder.transform.localRotation = Quaternion.Euler(weapon.RotationOffset);
                        // zero the weapon so it is in the correct position
                        RightHandHolder.CurrentWeaponModel.transform.localPosition = Vector3.zero;
                        RightHandHolder.CurrentWeaponModel.transform.localRotation = Quaternion.identity;

                        m_anim.CrossFade(weapon.IdleAnimationID, 0.2f);
                        
                        if (BackHolder_Sword.HasWeapon)
                            BackHolder_Sword.Unload();
                    }
                    break;
                case EquipSlot.Back_Sword:
                    {
                        BackHolder_Sword.LoadWeapon(weapon);
                        // place the holder in the correct position
                        BackHolder_Sword.transform.localPosition = weapon.OnBackPositionOffset;
                        BackHolder_Sword.transform.localRotation = Quaternion.Euler(weapon.OnBackRotationOffset);
                        // zero the weapon so it is in the correct position
                        BackHolder_Sword.CurrentWeaponModel.transform.localPosition = Vector3.zero;
                        BackHolder_Sword.CurrentWeaponModel.transform.localRotation = Quaternion.identity;
                        
                        if(RightHandHolder.HasWeapon)
                            RightHandHolder.Unload();
                    }
                    break;
                case EquipSlot.Back_Shield:
                    {
                        BackHolder_Shield.LoadWeapon(weapon);
                       
                        // place the holder in the correct position
                        BackHolder_Shield.transform.localPosition = weapon.OnBackPositionOffset;
                        BackHolder_Shield.transform.localRotation = Quaternion.Euler(weapon.OnBackRotationOffset);
                       
                        // zero the weapon so it is in the correct position
                        BackHolder_Shield.CurrentWeaponModel.transform.localPosition = Vector3.zero;
                        BackHolder_Shield.CurrentWeaponModel.transform.localRotation = Quaternion.identity;


                        if (LeftHandHolder.HasWeapon)
                            LeftHandHolder.Unload();

                    }
                    break;
                default: 
                    {
                        m_anim.CrossFade("Locomotion", 0.2f);

                    }
                    break;
            }

        }
    }
}
