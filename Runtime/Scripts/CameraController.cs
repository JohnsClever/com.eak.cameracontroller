using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;

namespace com.eak.cameracontroller
{
    public abstract class CameraController : MonoBehaviour
    {

        [SerializeField] protected CinemachineCamera targetCam;
        [SerializeField] protected Transform targetFollow;
        protected List<ICamControllable> camControllables = new();
        // field.
        public CinemachineCamera TargetCam => targetCam;
        public Transform holder => transform;
        public Transform TargetFollow => targetFollow;

        void Start()
        {
            InitModules();
        }
        abstract protected void InitModules();
        public void SetTargetFollow(Transform newTarget)
        {
            targetFollow = newTarget;
        }
        protected virtual void LateUpdate()
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
        protected void AddModule(ICamControllable module)
        {
            camControllables.Add(module);
        }
    }
}