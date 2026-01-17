using UnityEngine;

namespace com.eak.cameracontroller
{
    public class SideScrollingCameraController : CameraController
    {
        protected override void InitModules()
        {
            AddModule(new CameraLookAtTargetControl(targetFollow));
        }
    }
}
