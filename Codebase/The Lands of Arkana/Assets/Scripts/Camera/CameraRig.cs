using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lands_of_Arkana
{
    public class CameraRig : MonoBehaviour
    {
        public Transform Target;
        public Vector3 Position { get => cameraPosition; }

        public Transform GetCamera() { return m_camera; }

        public void Init()
        {
            m_transform = transform;
            m_pivot = m_transform.GetChild(0); // the pivot should always be child 0
            m_camera = m_pivot.GetChild(0);     // the camera should always be the only child of the pivot.

            // apply offset
            
            m_pivot.localPosition = new Vector3(0, m_properties.Offset.y, 0);
            m_camera.localPosition = new Vector3(m_properties.Offset.x, 0, m_properties.Offset.z);

            // save position

            defaultPosition = m_camera.localPosition.z;
            ignoreLayers = ~(1 << 8 | 1 << 9 | 1 << 10);

        }

        public void Tick(float deltaTime)
        {
            Vector3 position = Vector3.zero;
            position.y = m_properties.Offset.y;
            m_pivot.localPosition = position;

            position = Vector3.zero;
            position.x = m_properties.Offset.x;
            position.z = m_properties.Offset.z;
            m_camera.localPosition = position;

        }

        public void FixedTick(float fixedDeltaTime)
        {
            if (Target != null)
            {
                FollowTarget(fixedDeltaTime);
            }



            HandleRotation(fixedDeltaTime, GameManager.Instance.InputHandler.MouseX, GameManager.Instance.InputHandler.MouseY);
            HandleCollisions(fixedDeltaTime);
        }


        void FollowTarget(float deltaTime)
        {
            Vector3 targetPosition = Vector3.SmoothDamp(m_transform.position, Target.position, ref SmoothFollowVelocity, deltaTime / m_properties.FollowSpeed);
            m_transform.position = targetPosition;

        }

        void HandleRotation(float deltaTime, float inputX, float inputY)
        {


            lookAngle += (inputX * m_properties.LookSpeed) / deltaTime;
            pivotAngle -= (inputY * m_properties.PivotSpeed) / deltaTime;
            pivotAngle = Mathf.Clamp(pivotAngle, m_properties.MinimumPivotAngle, m_properties.MaximumPivotAngle);

            Vector3 rotation = Vector3.zero;
            rotation.y = lookAngle;

            Quaternion targetRotation = Quaternion.Euler(rotation);
            m_transform.rotation = targetRotation;

            rotation = Vector3.zero;
            rotation.x = pivotAngle;
            targetRotation = Quaternion.Euler(rotation);

            m_pivot.localRotation = targetRotation;

        }

       /* |
          |--****C
          |
       */

        void HandleCollisions(float delta)
        {
            targetPosition = defaultPosition;
            RaycastHit hit;
            Vector3 direction = m_camera.position - m_pivot.position;
            direction.Normalize();

            if (Physics.SphereCast(m_pivot.position, m_properties.Radius, direction, out hit, Mathf.Abs(targetPosition), ignoreLayers))
            {
                float dist = Vector3.Distance(m_pivot.position, hit.point);
                targetPosition = -(dist - m_properties.CollisionOffset);
            }

            if (Mathf.Abs(targetPosition) < m_properties.MinimumCollisionOffset)
            {
                targetPosition = -m_properties.MinimumCollisionOffset;
            }

            cameraPosition.z = Mathf.SmoothDamp(m_camera.localPosition.z, targetPosition, ref SmoothCollisionVelocity, delta / 0.2f);
            m_camera.localPosition = cameraPosition;
        }

        // Cache
        Vector3 cameraPosition;
        float lookAngle;
        float pivotAngle;
        // Collision
        private float targetPosition;

        float SmoothCollisionVelocity = 0;

        Vector3 SmoothFollowVelocity = Vector3.zero;
        
        // Inspector Variables
        [SerializeField] CameraRigProperties m_properties;


        // Members
        float defaultPosition;
        LayerMask ignoreLayers;

        Transform m_transform;
        Transform m_camera;
        Transform m_pivot;

    }
}
