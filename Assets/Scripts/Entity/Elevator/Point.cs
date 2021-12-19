using System;
using UnityEngine;

namespace Entity.Elevator
{
    [Serializable]
    public class Point
    {
        [SerializeField] private Transform _position;

        public Vector3 GetPosition()
        {
            return _position.position;
        }
    }
}