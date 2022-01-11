using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI.HighScoreInput
{
    public class NameInputManager : MonoBehaviour
    {
        private InputMapping _controls;
        
        [SerializeField] private List<Tile> _inputTiles = new List<Tile>();
        private Tile _selectedTile;
        private int _selectedTileIndex;

        private void Awake()
        {
            _controls = new InputMapping();
            
            _controls.UI.Select.performed += _ => Finish();
            _controls.UI.NavigateHorizontally.performed += context => SelectTile(context.ReadValue<float>());
            _controls.UI.NavigateVertically.performed += context => SelectLetter(context.ReadValue<float>());
        }

        private void Start()
        {
            _selectedTile = _inputTiles[0];
        }

        private void OnEnable()
        {
            _controls.Enable();
        }

        private void OnDisable()
        {
            _controls.Disable();
        }

        private void SelectTile(float direction)
        {
            if (direction == 0) return;
            
            // Update selected tile index
            if (direction > 0) ChooseNextTile();
            else ChoosePreviousTile();
            
            // Deactivate previous tile
            _selectedTile.IsActive = false;
            
            // Select new tile and activate it
            _selectedTile = _inputTiles[_selectedTileIndex];
            _selectedTile.IsActive = true;
        }

        private void ChooseNextTile()
        {
            if (_selectedTileIndex < _inputTiles.Count - 1) _selectedTileIndex++;
        }

        private void ChoosePreviousTile()
        {
            if (_selectedTileIndex > 0) _selectedTileIndex--;
        }

        private void SelectLetter(float direction)
        {
            if (direction == 0) return;
            
            if (direction > 0) _selectedTile.SelectPreviousLetter();
            else _selectedTile.SelectNextLetter();
        }
        
        private void Finish()
        {
            // Save highscore

            // Load highscore table scene
            StartCoroutine(LoadNextSceneAsync());
        }
        
        private IEnumerator LoadNextSceneAsync()
        {
            // Async
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);

            while(!asyncLoad.isDone)
            {
                yield return null;
            }
        }
    }
}