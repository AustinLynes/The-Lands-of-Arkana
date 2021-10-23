using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lands_of_Arkana
{

    [CreateAssetMenu(fileName = "LocomotionProperties", menuName = "Character Creation/Locomotion/Create Properties")]
    public class LocomotionProperties : ScriptableObject
    {
        [Header("Character")]
        public float Mass = 65.0f; // KG

        [Header("Movement")]
        public float WalSpeed = 3.0f;
        public float RunSpeed = 5.0f;
        public float SprintSpeed = 8.0f;

        [Header("Rotation Stats")]
        public float RotationSpeed = 10.0f;

        [Header("Ground and Air Detection")]
        public float Gravity = 9.81f;
        public float JumpForce = 14.0f;
        public ForceMode JumpForceMode = ForceMode.Force;
        public LayerMask GroundMask = 1 << 30;

        [Header("Fall Stats")]
        public float FallSpeed = 45.0f;
        public float LeapVelocity = 10.0f;

        [Header("Ground Detection")]
        public Vector3 GroundCheckOffset = Vector3.zero;
        public float LandCheckDistance = 1.0f;



        public void OnDebugDrawGizmos(Transform _transform)
        {
            Gizmos.color = Color.red;
            Vector3 origin = _transform.position;
            origin += _transform.forward * GroundCheckOffset.z;
            origin.y += GroundCheckOffset.y;

            Vector3 destination = origin + Vector3.down * LandCheckDistance;
            Gizmos.DrawLine(origin, destination);

            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(origin, 0.1f);
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(destination, 0.1f);
        }

    }
}
