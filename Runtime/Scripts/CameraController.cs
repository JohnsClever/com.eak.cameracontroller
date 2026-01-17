using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;

namespace com.eak.cameracontroller
{
    public class CameraController : MonoBehaviour
    {

        [SerializeField] CinemachineCamera targetCam;
        [SerializeField] Transform targetFollow;
        List<ICamControllable> camControllables = new();
        // field.
        public CinemachineCamera TargetCam => targetCam;
        public Transform holder => transform;
        public Transform TargetFollow => targetFollow;

        // modules.
        CameraOrbitalControl orbitalModule;
        CameraLookAtTargetControl lookAtModule;
        CameraAvoidObstacles avoidObstaclesModule;
        void Start()
        {
            orbitalModule = new CameraOrbitalControl();
            lookAtModule = new CameraLookAtTargetControl(targetFollow);
            avoidObstaclesModule = new CameraAvoidObstacles(Vector3.up);
            camControllables.Add(orbitalModule);
            camControllables.Add(lookAtModule);
            camControllables.Add(avoidObstaclesModule);
        }
        void LateUpdate()
        {
            Vector2 mouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
            ProcessAllCameraControls(mouseInput);
        }

        private void ProcessAllCameraControls(Vector2 input)
        {
            foreach (var camControllable in camControllables)
            {
                camControllable.Process(input, this);
            }
        }
    }
}