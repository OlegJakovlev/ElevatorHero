using System.Collections.Generic;
using UnityEngine;

namespace ObjectPool
{
    public class ObjectPool : MonoBehaviour
    {
        [Header("Object")] 
        [SerializeField] private GameObject _poolObject;
        [SerializeField] private int _amountToPool = 1;

        private List<GameObject> _poolOfObjects = new List<GameObject>();

        private void Start()
        {
            if (!_poolObject) Debug.LogWarning("Object Pool is not initialized!");

            for (int initializedObjects = 0; initializedObjects < _amountToPool; initializedObjects++)
            {
                // Create new object
                GameObject newObject = Instantiate(_poolObject, transform);
                
                _poolOfObjects.Add(newObject);
                
                // Set inactive and save the object
                newObject.SetActive(false);
            }
        }

        public GameObject GetPooledObject()
        {
            if (_poolOfObjects.Count < 0) return null;

            foreach (GameObject newObject in _poolOfObjects)
            {
                if (!newObject.activeInHierarchy)
                {
                    return newObject;
                }
            }

            return null;
        }

        public List<GameObject> GetAllPooledObjects()
        {
            return _poolOfObjects;
        }
    }
}