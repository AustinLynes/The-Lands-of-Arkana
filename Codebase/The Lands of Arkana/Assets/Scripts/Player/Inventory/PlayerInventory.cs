using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lands_of_Arkana { 

    public class PlayerInventory : MonoBehaviour
    {
        public WeaponItem DEBUG_sword;
        public WeaponItem DEBUG_shield;
        
        public WeaponManager WeaponsManager;

        public bool WeaponsEquipped { get => WeaponsManager.RightHandHolder.HasWeapon; }

        public void Init()
        {
            WeaponsManager = GetComponent<WeaponManager>();
            WeaponsManager.Init();
            //weaponsManager.LoadWeapon(DEBUG_shield, EquipSlot.Back_Shield);
            WeaponsManager.LoadWeapon(DEBUG_sword, EquipSlot.Back_Sword);
        }

        public void Tick(float deltaTime)
        {
            WeaponsManager.Tick(deltaTime);
        }


    }
}
