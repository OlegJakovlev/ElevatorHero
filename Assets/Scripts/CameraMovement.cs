using System;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Vector3 _currentPosition;

    [SerializeField] private float _slowFactor = 0.2f;
    [SerializeField] private Transform _objectToFollow;
    [SerializeField] private Vector3 _defaultVisionArea;
        
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        _currentPosition = transform.position;

        if (Mathf.Abs(_defaultVisionArea.x - _objectToFollow.position.x) > 0)
        {
            _currentPosition.x =
                Mathf.Lerp(_currentPosition.x, _objectToFollow.position.x, Time.deltaTime * _slowFactor);
        }
        
        if (Mathf.Abs(_defaultVisionArea.y - _objectToFollow.position.y) > 0)
        {
            _currentPosition.y =
                Mathf.Lerp(_currentPosition.y, _objectToFollow.position.y, Time.deltaTime * _slowFactor);
        }

        transform.position = _currentPosition;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(transform.position, _defaultVisionArea);
    }
}
