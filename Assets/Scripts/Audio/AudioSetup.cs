using System.Collections.Generic;
using Audio.MVP;
using UnityEngine;
using UnityEngine.Audio;

namespace Audio
{
    public class AudioSetup : MonoBehaviour
    {
        public static AudioSetup Instance;
        
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
            if (!Instance)
                Instance = this;
            else Destroy(gameObject);
        }

        public void Start()
        {
            _model = new AudioModel(
                _soundMixerGroup,
                _musicMixerGroup,
                _allSounds,
                _defaultSoundVolume,
                _defaultMusicVolume
            );
            
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