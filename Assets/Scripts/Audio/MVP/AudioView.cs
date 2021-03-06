using System;
using UnityEngine;
using UnityEngine.UI;

namespace Audio.MVP
{
    public class AudioView : MonoBehaviour
    {
        [SerializeField] private Slider _musicSlider;
        [SerializeField] private Slider _soundSlider;

        public event Action OnSliderValueChange;
        
        private void Awake()
        {
            _musicSlider.onValueChanged.AddListener(delegate { OnSliderValueChange?.Invoke(); });
            _soundSlider.onValueChanged.AddListener(delegate { OnSliderValueChange?.Invoke(); });
        }

        public void UpdateVisuals(float newMusicValue, float newSoundValue)
        {
            _musicSlider.value = newMusicValue;
            _soundSlider.value = newSoundValue;
        }

        public Slider GetMusicSlider()
        {
            return _musicSlider;
        }
        
        public Slider GetSoundSlider()
        {
            return _soundSlider;
        }
    }
}