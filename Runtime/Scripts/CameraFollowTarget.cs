using UnityEngine;

namespace com.eak.cameracontroller
{
    [System.Serializable]
    public class CameraFollowTarget : ICamControllable
    {
        [SerializeField] private Vector3 offset;
        [SerializeField] private float smoothSpeed = 0.125f;

        private Vector3 velocity;

        public void Process(Vector2 mouseInput, CameraController camera)
        {
            if (camera.TargetFollow == null) return;

            Vector3 desiredPosition = camera.TargetFollow.position + offset;
            Vector3 smoothedPosition = Vector3.SmoothDamp(camera.transform.position, desiredPosition, ref velocity, smoothSpeed);
            camera.transform.position = smoothedPosition;
        }
    }
}