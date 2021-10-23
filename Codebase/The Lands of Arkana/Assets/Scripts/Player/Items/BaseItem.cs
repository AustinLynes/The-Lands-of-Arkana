using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Lands_of_Arkana
{

    public class BaseItem : ScriptableObject
    {
        [Header("Item Information")]
        public string Name;
        public Sprite Icon;
    }
}