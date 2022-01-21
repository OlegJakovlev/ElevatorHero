using System;
using Audio;
using UnityEngine;

public class LevelTimer : MonoBehaviour
{
    [SerializeField] private float _alarmTimer;
    public event Action OnAlarm;

    private void Start()
    {
        InvokeRepeating(nameof(Alarm), _alarmTimer, _alarmTimer);
    }

    public void Alarm()
    {
        // If invoke pending - cancel and start a new one
        if (IsInvoking(nameof(Alarm))) CancelInvoke(nameof(Alarm));
        OnAlarm?.Invoke();
        
        // Play sound
        AudioSetup.Instance.PlaySound("Alarm");
        
        // In case of manual call, after we cancel invoke, need to start new
        InvokeRepeating(nameof(Alarm), _alarmTimer, _alarmTimer);
        
        Debug.Log("Alert");
    }
}
