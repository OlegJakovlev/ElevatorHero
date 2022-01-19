namespace UI.Select.Slider
{
    public class SliderOptionManager : SelectOptionManager
    {
        private void Awake()
        {
            Controls = new InputMapping();
            
            Controls.UI.Select.performed += _ => Finish();
            Controls.UI.NavigateVertically.performed += context => SelectOption(context.ReadValue<float>() * -1); // Reversed vertical input
            Controls.UI.NavigateHorizontally.performed += context => EvaluateSlider(context.ReadValue<float>());
        }

        private void EvaluateSlider(float direction)
        {
            if (direction == 0) return;
            
            if (direction > 0) ((SliderOption) SelectedOption).IncreaseValue();
            else ((SliderOption) SelectedOption).DecreaseValue();
        }
    }
}