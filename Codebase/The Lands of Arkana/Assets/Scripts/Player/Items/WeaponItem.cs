using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lands_of_Arkana
{

    [CreateAssetMenu(fileName = "WeaponItem", menuName = "Item Creator/Create Weapon")]
    public class WeaponItem : BaseItem
    {
        [Header("World Properties")]
        public GameObject ModelPrefab;
        [Header("Equipped")]
        public Vector3 RotationOffset;
        public Vector3 PositionOffset;
        [Header("Sheathed")]
        public Vector3 OnBackPositionOffset;
        public Vector3 OnBackRotationOffset;

        [Header("Animations")]
        [Header("Idle")]
        public string IdleAnimationID;
        [Header("Attack")]
        public List<Attack> LightAttacks;
        public Attack HeavyAttack;
        
        public bool IsUnarmed;

    }
}