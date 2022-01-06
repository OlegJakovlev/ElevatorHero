using UnityEngine;

namespace Entity.Player
{
    public class JumpType : MonoBehaviour
    {
        [Header("Time")]
        private float _currentTime;
        private float _progress;
        private float _duration;

        [Header("Height")]
        public float heightCoefficient;
        
        [Header("Gravity Graphic")]
        public AnimationCurve gravityChange;

        private void Awake()
        {
            _duration = gravityChange.keys[gravityChange.keys.Length - 1].time;
        }
        
        private void Update()
        {
            _currentTime += Time.deltaTime;
            _progress = _currentTime / _duration;
        }

        public void ResetProgress()
        {
            _currentTime = 0;
            _progress = 0;
        }

        public float GetProgress()
        {
            return _progress;
        }

        public float GetProgressValue()
        {
            return gravityChange.Evaluate(_progress);
        }
    }
}
