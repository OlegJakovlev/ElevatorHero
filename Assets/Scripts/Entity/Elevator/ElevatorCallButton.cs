using Components;
using UnityEngine;

namespace Entity.Elevator
{
    public class ElevatorCallButton : MonoBehaviour, IActivator
    {
        [SerializeField] private Elevator _elevator;
        [SerializeField] private Point _currentStop;

        public void Activate()
        {
            _elevator.SetNextStop(_currentStop);
        }
    }
}
