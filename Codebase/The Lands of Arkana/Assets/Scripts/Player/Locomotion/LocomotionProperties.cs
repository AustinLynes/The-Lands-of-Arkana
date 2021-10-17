using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LocomotionProperties", menuName = "Character Creation/Locomotion/Create Properties")]
public class LocomotionProperties : ScriptableObject
{
    [Header("Movement Stats")]
    public float RunSpeed = 5.0f;
    public float SprintSpeed = 8.0f;
    [Header("Rotation Stats")]
    public float RotationSpeed = 10.0f;

    public float FallSpeed = 45.0f;
}
