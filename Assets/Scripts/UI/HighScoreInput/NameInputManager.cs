using System.Collections.Generic;
using UnityEngine;

namespace UI.HighScoreInput
{
    public class NameInputManager : MonoBehaviour
    {
        private InputMapping _controls;
        
        [SerializeField] private List<Tile> _inputTiles;
        private Tile _selectedTile;

        private void Awake()
        {
            _controls = new InputMapping();
            
            _controls.UI.Select.performed += _context => { };
            _controls.UI.NavigateHorizontally.performed += _context => { };
        }

        private void OnEnable()
        {
            _controls.Enable();
        }

        private void OnDisable()
        {
            _controls.Disable();
        }
    }
}