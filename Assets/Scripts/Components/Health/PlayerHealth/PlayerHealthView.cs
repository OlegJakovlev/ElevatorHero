using UnityEngine;

namespace Components.Health.PlayerHealth
{
    public class PlayerHealthView : MonoBehaviour
    {
        private PlayerHealth _model;

        public void SetModel(PlayerHealth newModel)
        {
            _model = newModel;
            
            // Assign new events
            _model.OnDamageTaken += () => print("Player lose health!");
            _model.OnDeath += () => print("Player is dead!");
        }
    }
}