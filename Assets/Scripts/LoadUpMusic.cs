using System.Collections.Generic;
using Audio;
using UnityEngine;

public class LoadUpMusic : MonoBehaviour
{
    [SerializeField] private List<string> _audioToStop;
    [SerializeField] private string _audioName;

    private void Start()
    {
        foreach (string oldAudioName in _audioToStop)
        {
            AudioSetup.Instance.StopSound(oldAudioName);
        }
        
        AudioSetup.Instance.PlaySound(_audioName);
    }
}
