using com.eak.cameracontroller;
using UnityEngine;

namespace com.eak.cameracontroller
{
    public class ThirdPersonCameraController : CameraController
    {
        // modules.
        [SerializeField] CameraFollowTarget followModule;
        [SerializeField] CameraOrbitalControl orbitalModule;
        [SerializeField] CameraLookAtTargetControl lookAtModule;
        [SerializeField] CameraAvoidObstacles avoidObstaclesModule;
        protected override void InitModules()
        {
            followModule = new CameraFollowTarget();
            orbitalModule = new CameraOrbitalControl();
            lookAtModule = new CameraLookAtTargetControl(targetFollow);
            avoidObstaclesModule = new CameraAvoidObstacles(Vector3.up);
            AddModule(followModule);
            AddModule(orbitalModule);
            AddModule(lookAtModule);
            AddModule(avoidObstaclesModule);
        }
    }
}