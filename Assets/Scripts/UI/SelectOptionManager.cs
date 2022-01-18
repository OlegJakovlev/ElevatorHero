using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class SelectOptionManager : MonoBehaviour
    {
        protected InputMapping Controls;
        
        [SerializeField] protected List<Option> _inputOptions = new List<Option>();
        protected Option SelectedOption;
        private int _selectedOptionIndex;

        private void Awake()
        {
            Controls = new InputMapping();
            
            Controls.UI.Select.performed += _ => Finish();
            Controls.UI.NavigateVertically.performed += context => SelectOption(context.ReadValue<float>() * -1); // Reversed vertical input
            Controls.UI.NavigateHorizontally.performed += context => SelectOption(context.ReadValue<float>());
        }

        protected void Start()
        {
            SelectedOption = _inputOptions[0];
            SelectedOption.IsActive = true;
        }

        protected void OnEnable()
        {
            Controls.Enable();
        }

        protected void OnDisable()
        {
            Controls.Disable();
        }

        protected void SelectOption(float direction)
        {
            if (direction == 0) return;
            
            // Update selected tile index
            if (direction > 0) ChooseNextOption();
            else ChoosePreviousOption();
            
            // Deactivate previous tile
            SelectedOption.IsActive = false;
            
            // Select new tile and activate it
            SelectedOption = _inputOptions[_selectedOptionIndex];
            SelectedOption.IsActive = true;
        }

        private void ChooseNextOption()
        {
            if (_selectedOptionIndex < _inputOptions.Count - 1) _selectedOptionIndex++;
        }

        private void ChoosePreviousOption()
        {
            if (_selectedOptionIndex > 0) _selectedOptionIndex--;
        }

        protected virtual void Finish()
        {
            CustomSceneManager.Instance.LoadNextSceneAsync();
        }
    }
}