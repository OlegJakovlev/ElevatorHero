using System;
using UnityEngine;

namespace Player
{
    public class JumpType : MonoBehaviour
    {
        [Header("Time")]
        private float _currentTime;
        private float _progress = 0;
        public float duration;

        [Header("Height")]
        public float heightCoefficient;
        
        [Header("Gravity Graphic")]
        public AnimationCurve gravityRise;

        private void Update()
        {
            _currentTime += Time.deltaTime;

            // Update progress
            _progress = _currentTime / duration;
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
            return gravityRise.Evaluate(_progress);
        }
    }
}
