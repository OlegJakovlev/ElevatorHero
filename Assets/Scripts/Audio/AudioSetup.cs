using System.Collections.Generic;
using Audio.MVP;
using UnityEngine;
using UnityEngine.Audio;

namespace Audio
{
    public class AudioSetup : MonoBehaviour
    {
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