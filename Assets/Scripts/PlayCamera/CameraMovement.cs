using UnityEngine;

namespace PlayCamera
{
    public class CameraMovement : MonoBehaviour
    {
        [SerializeField] private Vector2 _maxOffset;
        private Vector2 _currentOffset;
        private bool _boostApplied;
        
        [SerializeField] private float _slowFactor = 0.2f;
        [SerializeField] private Transform _objectToFollow;
        private Vector3 _currentPosition;

        private void FixedUpdate()
        {
            if (!_objectToFollow) return;
            
            // Save current position
            _currentPosition = transform.position;
            
            // Calculate offset and apply boost in case overcoming the limit
            _currentOffset = _currentPosition - _objectToFollow.position;

            if (!_boostApplied && (Mathf.Abs(_currentOffset.x) > _maxOffset.x || Mathf.Abs(_currentOffset.y) > _maxOffset.y))
            {
                _boostApplied = true;
                _slowFactor *= 2;
            }

            // Calculate new position using lerp
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

            // Reset boost after applying
            if (_boostApplied)
            {
                _slowFactor /= 2;
                _boostApplied = false;
            }
        }

        public void SetObjectToFollow<T>(T newTarget) where T : MonoBehaviour
        {
            if (newTarget.TryGetComponent(out Transform target))
            {
                // Teleport after setting
                transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
                _objectToFollow = target;
            }
        }
    }
}
