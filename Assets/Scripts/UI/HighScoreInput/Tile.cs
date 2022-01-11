using UnityEngine;
using UnityEngine.UI;

namespace UI.HighScoreInput
{
    public class Tile : MonoBehaviour
    {
        [SerializeField] private Text _textComponent;
        
        private readonly char[] _letters = 
            {'a','b','c','d','e','f','g','h','i', 
             'j','k','l','m','n','o','p','q','r',
             's','t','u','v','w','x','y','z'};

        public char SelectedLetter
        {
            get => _selectedLetter;
            private set
            {
                _selectedLetter = value;
                _textComponent.text = value.ToString();
            }
        }

        private char _selectedLetter = 'a';

        private int _selectedLetterIndex;

        public bool IsActive { get; set; } = false;

        public void SelectNextLetter()
        {
            // Select next or first letter
            if (_selectedLetterIndex < _letters.Length - 1) _selectedLetterIndex++;
            else _selectedLetterIndex = 0;

            SelectedLetter = _letters[_selectedLetterIndex];
        }

        public void SelectPreviousLetter()
        {
            // Select previous or last letter
            if (_selectedLetterIndex > 0) _selectedLetterIndex--;
            else _selectedLetterIndex = _letters.Length - 1;
            
            SelectedLetter = _letters[_selectedLetterIndex];
        }
    }
}