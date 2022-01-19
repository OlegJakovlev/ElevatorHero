using UnityEngine;

namespace UI.Select.Slider
{
    public class SliderOption : Option
    {
        [SerializeField] protected float _stepDelta;
        [SerializeField] protected UnityEngine.UI.Slider _slider;

        public void IncreaseValue()
        {
            _slider.value += _stepDelta;
        }

        public void DecreaseValue()
        {
            _slider.value -= _stepDelta;
        }
    }
}