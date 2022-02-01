using UnityEngine;

namespace Audio
{
    [System.Serializable]
    public class Sound
    {
        public enum AudioType { SoundEffect, MusicEffect }
        public AudioType _audioType;

        public string _name;
        public AudioClip _clip;

        [Range(0f, 1f)] public float _volume;
        [Range(0f, 1f)] public float _pitch;
        public bool _loop;

        [HideInInspector]
        public AudioSource _source;
    }
}