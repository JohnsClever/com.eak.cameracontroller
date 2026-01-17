using Unity.Cinemachine;
using UnityEngine;
namespace com.eak.cameracontroller
{
    public interface ICamControllable
    {
        void Process(Vector2 mouseInput, CameraController camera);
    }
}