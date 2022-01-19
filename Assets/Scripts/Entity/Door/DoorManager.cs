using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Entity.Door
{
    public class DoorManager : MonoBehaviour
    {
        [SerializeField] private List<DoorActivator> _allDoors = new List<DoorActivator>();
        
        public Door GetSafeDoor()
        {
            return _allDoors.Select(activator => activator.GetDoor()).FirstOrDefault(
                potentialSafeDoor => potentialSafeDoor.gameObject.activeInHierarchy
                && potentialSafeDoor.IsSafe);
        }
    }
}