using System;
using UnityEngine;

namespace Components.Health.PlayerHealth
{
    public class PlayerHealthView : MonoBehaviour
    {
        [SerializeField] private PlayerHealth _model;

        private void Awake()
        {
            _model.OnDamageTaken += () => print("Player lose health!");
            _model.OnDeath += () => print("Player is dead!");
        }
    }
}