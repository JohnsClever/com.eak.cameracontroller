using com.eak.charactermovement;
using UnityEngine;

namespace com.eak.cameracontroller
{
    public class SideScrollingCameraController : CameraController
    {
        protected override void InitModules()
        {
            AddModule(new CameraFollowTarget());
            AddModule(new CameraLookAtTargetControl(targetFollow));
            AddModule(new CameraFixAxisZControl());
        }
    }
}
