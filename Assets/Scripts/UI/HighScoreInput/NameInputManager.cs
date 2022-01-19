using SaveAndLoadSystem;
using UI.Select;

namespace UI.HighScoreInput
{
    public class NameInputManager : SelectOptionManager
    {
        private string _playerName;

        private void Awake()
        {
            Controls = new InputMapping();
            
            Controls.UI.Select.performed += _ => Finish();
            Controls.UI.NavigateHorizontally.performed += context => SelectOption(context.ReadValue<float>());
            Controls.UI.NavigateVertically.performed += context => SelectLetter(context.ReadValue<float>());
        }

        private void SelectLetter(float direction)
        {
            if (direction == 0) return;
            
            if (direction > 0) ((Tile) SelectedOption).SelectPreviousLetter();
            else ((Tile) SelectedOption).SelectNextLetter();
        }
        
        protected override void Finish()
        {
            _playerName = "";
            
            foreach (var inputOption in _inputOptions)
            {
                _playerName += ((Tile) inputOption).SelectedLetter;
            }
            Serializer.SaveLoadManager.Save(_playerName);

            CustomSceneManager.Instance.LoadNextSceneAsync();
        }
    }
}