using System.Collections.Generic;
using UnityEngine;

namespace SaveAndLoadSystem.HighScore
{
    public class HighScoreView : MonoBehaviour
    {
        [SerializeField] private List<HighScoreEntryView> _highScoreVisualEntries;
        private HighScoreEntry[] _highScoreEntries;
            
        private void Awake()
        {
            _highScoreEntries = Serializer.SaveLoadManager.GetModel()._highScoreTable;
        }

        private void Start()
        {
            for (int entryIndex = 0; entryIndex < _highScoreEntries.Length; entryIndex++)
            {
                var currentEntry = _highScoreVisualEntries[entryIndex];
                
                currentEntry.Nickname = (_highScoreEntries[entryIndex]._name == "") ? "Jimmy" : _highScoreEntries[entryIndex]._name;
                currentEntry.Score = _highScoreEntries[entryIndex]._score.ToString();
            }
        }
    }
}