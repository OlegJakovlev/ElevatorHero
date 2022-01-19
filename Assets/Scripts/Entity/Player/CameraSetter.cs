using System;
using PlayCamera;
using UnityEngine;

namespace Entity.Player
{
    public class CameraSetter : MonoBehaviour
    {
        private void Start()
        {
            try
            {
                if (Camera.main != null && Camera.main.TryGetComponent(out CameraMovement movement))
                {
                    movement.SetObjectToFollow(this);
                }
            }
            catch (NullReferenceException)
            {
                Debug.LogWarning("No camera found!");
            }
        }
    }
}