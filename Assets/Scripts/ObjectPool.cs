using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool pool;
    
    [Header("Object")]
    [SerializeField] private GameObject _object;
    [SerializeField] private int _amountToPool = 1;
    
    private List<GameObject> _pooledObjects = new List<GameObject>();
    
    private void Awake()
    {
        pool = this;
    }

    private void Start()
    {
        GameObject newObject;
        
        for (var initializedObjects=0; initializedObjects < _amountToPool; initializedObjects++)
        {
            newObject = Instantiate(_object, transform);
            newObject.SetActive(false);
            _pooledObjects.Add(newObject);
        }
    }

    public GameObject GetPooledObject()
    {
        for (var objectIndex = 0; objectIndex < _amountToPool; objectIndex++)
        {
            if (!_pooledObjects[objectIndex].activeInHierarchy)
            {
                return _pooledObjects[objectIndex];
            }
        }

        return null;
    }
}
