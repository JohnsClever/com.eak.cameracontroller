using UnityEngine;

namespace com.eak.cameracontroller
{
    public class CameraLookAtTargetControl : ICamControllable
    {
        Transform target;
        public CameraLookAtTargetControl(Transform target)
        {
            this.target = target;
        }

        public void Process(Vector2 mouseInput, CameraController camera)
        {
            camera.TargetCam.transform.LookAt(target);
        }
    }
}