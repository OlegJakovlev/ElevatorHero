using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Entity.Door
{
    public class DoorManager : MonoBehaviour
    {
        private List<DoorActivator> _allDoors = new List<DoorActivator>();

        private void Start()
        {
            foreach (Transform child in transform)
            {
                if (child.TryGetComponent(out DoorActivator door))
                {
                    _allDoors.Add(door);
                }
            }
        }

        public Door GetSafeDoor()
        {
            return _allDoors.Select(activator => activator.GetDoor()).FirstOrDefault(safeDoor => safeDoor.IsSafe);
        }
    }
}