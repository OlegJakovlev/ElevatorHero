using UnityEngine;

namespace PlayCamera
{
    public class CameraMovement : MonoBehaviour
    {
        [SerializeField] private float _slowFactor = 0.2f;
        [SerializeField] private Transform _objectToFollow;
        private Vector3 _currentPosition;

        private void FixedUpdate()
        {
            if (!_objectToFollow) return;

            // Save current position
            _currentPosition = transform.position;

            // Calculate new position using linear interpolation
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
        
            // Update position
            transform.position = _currentPosition;
        }

        public void SetObjectToFollow<T>(T newTarget) where T : MonoBehaviour
        {
            if (newTarget.TryGetComponent(out Transform target))
            {
                _objectToFollow = target;
            }
        }
    }
}
