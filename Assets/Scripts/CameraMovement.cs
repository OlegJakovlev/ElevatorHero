using System;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float _slowFactor = 0.2f;
    [SerializeField] private Transform _objectToFollow;
    private Vector3 _currentPosition;

    private void FixedUpdate()
    {
        _currentPosition = transform.position;

        if (Mathf.Abs(_objectToFollow.position.x) > 0)
        {
            _currentPosition.x =
                Mathf.Lerp(_currentPosition.x, _objectToFollow.position.x, Time.deltaTime * _slowFactor);
        }
        
        if (Mathf.Abs(_objectToFollow.position.y) > 0)
        {
            _currentPosition.y =
                Mathf.Lerp(_currentPosition.y, _objectToFollow.position.y, Time.deltaTime * _slowFactor);
        }

        transform.position = _currentPosition;
    }
}
