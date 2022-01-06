using System;
using UnityEngine;

public class LevelTimer : MonoBehaviour
{
    [SerializeField] private float _alarmTimer;
    public event Action OnAlarm;

    private void Start()
    {
        InvokeRepeating(nameof(AlarmStatusChange), _alarmTimer, _alarmTimer);
    }

    private void AlarmStatusChange()
    {
        OnAlarm?.Invoke();
        Debug.Log("Level Alarm!");
    }
}
