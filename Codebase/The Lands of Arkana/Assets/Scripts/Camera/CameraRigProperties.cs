using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "CameraRigProperties", menuName = "Camera Creator/Camera Rig/Create Properties")]
public class CameraRigProperties : ScriptableObject
{
    [Header("Follow Target")]
    public float FollowSpeed = 0.1f;

    [Header("Rotation Settings")]
    public float LookSpeed = 0.1f;
    public float PivotSpeed = 0.03f;
    public float MinimumPivotAngle = -35.0f;
    public float MaximumPivotAngle =  35.0f;

    [Header("Camera Collision")]
    public float Radius = 0.2f;
    public float CollisionOffset = 0.2f;
    public float MinimumCollisionOffset = 0.2f;

    public Vector3 Offset = Vector3.zero;
}
