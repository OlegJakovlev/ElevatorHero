using UnityEngine;
using UnityEngine.UI;

namespace Components.Health.PlayerHealth
{
    public class PlayerHealthView : MonoBehaviour
    {
        private PlayerHealth _model;

        [SerializeField] private Slider _healthSlider;

        public void SetModel(PlayerHealth newModel)
        {
            _model = newModel;
            _model.OnDamageTaken += () => _healthSlider.value += 1; // Fill background from left to right
            _model.OnDeath += () => _healthSlider.value = 0; // Reset fill
        }
    }
}