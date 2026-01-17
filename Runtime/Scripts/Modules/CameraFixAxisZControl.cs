using com.eak.cameracontroller;
using UnityEngine;

namespace com.eak.charactermovement
{
    public class CameraFixAxisZControl : ICamControllable
    {
        [SerializeField] float zAxisMinClamp = -10;
        [SerializeField] float zAxisMaxClamp = -10;

        public CameraFixAxisZControl(float min = -10, float max = -10)
        {
            zAxisMinClamp = min;
            zAxisMaxClamp = max;
        }

        public void Process(Vector2 mouseInput, CameraController camera)
        {
            Vector3 camPos = camera.TargetCam.transform.position;
            camPos.z = Mathf.Clamp(camPos.z, zAxisMinClamp, zAxisMaxClamp);
            camera.TargetCam.transform.position = camPos;
        }
    }
}