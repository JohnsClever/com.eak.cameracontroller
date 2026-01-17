using UnityEngine;

namespace com.eak.cameracontroller
{
    [System.Serializable]
    public class CameraAvoidObstacles : ICamControllable
    {
        Vector3 offsetFrom;

        public CameraAvoidObstacles(Vector3 offset)
        {
            this.offsetFrom = offset;
        }

        public void Process(Vector2 mouseInput, CameraController camera)
        {
            RaycastHit hit;
            Vector3 direction = camera.TargetCam.transform.position - (camera.TargetFollow.position + offsetFrom);
            if (Physics.Raycast(camera.TargetFollow.position + offsetFrom, direction.normalized, out hit, direction.magnitude))
            {
                camera.TargetCam.transform.position = hit.point;
            }
        }
    }
}