using System.Collections.Generic;
using Audio.MVP;
using UnityEngine;
using UnityEngine.Audio;

namespace Audio
{
    public class AudioSetup : MonoBehaviour
    {
        public static AudioSetup Instance
        {
            get
            {
                if (_instance == null)
                    _instance = FindObjectOfType(typeof(AudioSetup)) as AudioSetup;

                return _instance;
            }

            private set => _instance = (_instance == null) ? value : null;
        }

        private static AudioSetup _instance;
        
        // Initialize audio mixers for sound and sound
        [SerializeField] private AudioMixerGroup _soundMixerGroup;
        [SerializeField] private AudioMixerGroup _musicMixerGroup;

        [SerializeField] private float _defaultSoundVolume;
        [SerializeField] private float _defaultMusicVolume;
        
        [SerializeField] private List<Sound> _allSounds;

        [Header("MVP")]
        [SerializeField] private AudioView _view;
        private AudioModel _model;
        private AudioPresenter _presenter;

        private void Awake()
        {
            Instance = this;
            
            // Create model
            _model = new AudioModel(
                _soundMixerGroup,
                _musicMixerGroup,
                _allSounds,
                _defaultSoundVolume,
                _defaultMusicVolume
            );

            // Predefine view 
            _view.UpdateVisuals(_defaultSoundVolume, _defaultMusicVolume);
            
            _presenter = new AudioPresenter(_view, _model);
        }

        public void PlaySound(string soundName)
        {
            _presenter.PlaySound(soundName);
        }

        public void StopSound(string soundName)
        {
            _presenter.StopSound(soundName);
        }
    }
}