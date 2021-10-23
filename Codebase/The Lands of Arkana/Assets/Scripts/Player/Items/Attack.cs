using UnityEngine;

namespace Lands_of_Arkana
{
    [CreateAssetMenu(menuName = "Combat/Create Attack")]
    public class Attack : ScriptableObject
    {
        public string AnimationID;
        public float SpeedMultiplier;
    }
}