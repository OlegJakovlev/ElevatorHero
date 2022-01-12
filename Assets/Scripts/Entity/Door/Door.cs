using UnityEngine;
using Random = UnityEngine.Random;

namespace Entity.Door
{
    public class Door : MonoBehaviour
    {
        [SerializeField] private DoorManager _doorManager;
        
        [SerializeField] private GameObject _doorShield;
        [SerializeField] private bool _inversed;

        [Header("Safe teleport")] 
        [SerializeField] private int _teleportPercentChance = 25;
        public bool IsSafe { get; set; } = true;

        private void Start()
        {
            Vector3 currentPosition = _doorShield.transform.localPosition;
            if (_inversed)
            {
                _doorShield.transform.localPosition =
                    new Vector3(currentPosition.x * -1, currentPosition.y, currentPosition.z);
            }
        
            _doorShield.SetActive(false);
        }

        public void Use(GameObject player)
        {
            // Teleport player to safe door with some chance
            if (Random.Range(1, 100) > _teleportPercentChance) return;
            
            // Get safe door
            Door safeDoor = _doorManager.GetSafeDoor();
            if (!safeDoor) return;
            
            // Teleport player to safe door coordinates
            player.transform.position = safeDoor.transform.position;
        }
    }
}
