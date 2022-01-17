using UnityEngine;

namespace Audio.MVP
{
    public class AudioPresenter
    {
        private readonly AudioView _view;
        private readonly AudioModel _model;
        
        public AudioPresenter(AudioView newView, AudioModel newModel)
        {
            _view = newView;
            _model = newModel;

            _view.OnSliderValueChange += UpdateSoundLevel;
        }

        private void UpdateSoundLevel()
        {
            _model.SetMixerValues(_view.GetSoundSlider().value, _view.GetMusicSlider().value);
        }
        
        public void PlaySound(string soundName)
        {
            Sound newSound = _model.GetSounds().Find(sound => sound._name == soundName);
            
            if (newSound == null)
            {
                Debug.LogWarning(soundName + " sound/music was not found!");
                return;
            }
            
            newSound._source.Play();
        }
        
        public void StopSound(string soundName)
        {
            Sound newSound = _model.GetSounds().Find(sound => sound._name == soundName);
            
            if (newSound == null)
            {
                Debug.LogWarning(soundName + " sound/music was not found!");
                return;
            }
            
            newSound._source.Stop();
        }
    }
}