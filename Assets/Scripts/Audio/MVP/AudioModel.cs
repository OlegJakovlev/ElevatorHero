using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace Audio.MVP
{
    public class AudioModel
    {
        private readonly AudioMixerGroup _soundMixerGroup;
        private readonly AudioMixerGroup _musicMixerGroup;

        // Array of all sounds to be played
        private readonly List<Sound> _sounds;
        
        public AudioModel(AudioMixerGroup newSoundMixer, AudioMixerGroup newMusicMixer, List<Sound> allSounds, float defaultSoundVolume, float defaultMusicVolume)
        {
            // Initialize audio mixers and their volume
            _soundMixerGroup = newSoundMixer;
            _musicMixerGroup = newMusicMixer;
            SetMixerValues(defaultSoundVolume, defaultMusicVolume);

            // Save all sounds
            _sounds = allSounds;

            // Initialize each sound / music source
            foreach (Sound s in _sounds)
            {
                // Set audio source to camera
                if (Camera.main)
                {
                    s._source = Camera.main.gameObject.AddComponent<AudioSource>();
                }
                
                switch (s._audioType)
                {
                    case Sound.AudioType.SoundEffect:
                        s._source.outputAudioMixerGroup = _soundMixerGroup;
                        break;

                    case Sound.AudioType.MusicEffect:
                        s._source.outputAudioMixerGroup = _musicMixerGroup;
                        break;
                }

                s._source.clip = s._clip;
                s._source.volume = s._volume;
                s._source.pitch = s._pitch;
                s._source.loop = s._loop;
            }
        }

        public List<Sound> GetSounds()
        {
            return _sounds;
        }

        public void SetMixerValues(float newSoundLevel, float newMusicLevel)
        {
            _soundMixerGroup.audioMixer.SetFloat("SoundVolume", Mathf.Log10(newSoundLevel) * 20);
            _musicMixerGroup.audioMixer.SetFloat("MusicVolume", Mathf.Log10(newMusicLevel) * 20);
        }
    }
}