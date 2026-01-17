using Unity.Cinemachine;
using UnityEngine;

namespace com.eak.cameracontroller
{
    public class CameraOrbitalControl : ICamControllable
    {
        float yAxisRotation = 0;
        float cameraXSensitivity = 180;


        float cameraYSensitivity = 1;
        float offsetFromTarget = 10;

        const float maxSinX = -0.1f;
        const float minSinX = -Mathf.PI / 2f + 0.1f;

        const float maxCosX = -0.1f;
        const float minCosX = -Mathf.PI / 2f + 0.1f;

        float z = 0;
        float y = 0;
        public void Process(Vector2 mouseInput, CameraController camera)
        {
            yAxisRotation += mouseInput.x * cameraXSensitivity * Time.deltaTime;
            camera.holder.transform.rotation = Quaternion.Euler(0, yAxisRotation, 0);

            z = Mathf.Clamp(z - mouseInput.y * cameraYSensitivity * Time.deltaTime, minSinX, maxSinX);
            y = Mathf.Clamp(y - mouseInput.y * cameraYSensitivity * Time.deltaTime, minCosX, maxCosX);
            float localZ = Mathf.Sin(z) * offsetFromTarget;
            float localY = Mathf.Cos(y) * offsetFromTarget;
            camera.TargetCam.transform.localPosition = new Vector3(0, localY, localZ);
        }
    }
}
