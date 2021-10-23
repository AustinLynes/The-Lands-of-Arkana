using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Lands_of_Arkana
{

    public enum EquipSlot
    {
        Left_Hand,
        Right_Hand,
        Back_Sword,
        Back_Shield
    }

    public class WeaponHolder : MonoBehaviour
    {
        public WeaponItem CurrentWeapon;
        public GameObject CurrentWeaponModel;
        public EquipSlot Slot;
        public Vector3 RotationOffset;
        public bool HasWeapon = false;

        public void LoadWeapon(WeaponItem weapon)
        {
            Unload();

            if (weapon == null)
            {
                UnloadWeapon();
                return;
            }

            transform.rotation = Quaternion.Euler(RotationOffset);

            GameObject model = Instantiate(weapon.ModelPrefab);
            if (model != null)
            {
                model.transform.parent = transform;
                model.transform.localPosition = Vector3.zero;
                model.transform.localRotation = Quaternion.identity;
                model.transform.localScale = Vector3.one;
                model.transform.GetChild(0).localScale = Vector3.one * 100.0f; // adjust the model size
            } 

            CurrentWeapon = weapon;
            CurrentWeaponModel = model;
            HasWeapon = true;
        }

        void UnloadWeapon()
        {
            if (CurrentWeapon != null)
            {
                CurrentWeaponModel.SetActive(false);
                CurrentWeapon = null;
                HasWeapon = false;
            }
        }

        public void Unload()
        {
            if (CurrentWeaponModel != null)
            {
                Destroy(CurrentWeaponModel);
                CurrentWeapon = null;
                HasWeapon = false;

            }
        }
    }
}