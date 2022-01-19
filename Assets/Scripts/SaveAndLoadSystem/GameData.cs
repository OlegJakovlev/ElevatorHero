using System;
using SaveAndLoadSystem.HighScore;
using Score.MVP;

namespace SaveAndLoadSystem
{
    [Serializable]
    public class GameData
    {
        public HighScoreEntry[] _highScoreTable = new HighScoreEntry[10];

        public void CollectDataToSave(string playerName, ScoreModel scoreModel)
        {
            TryUpdateHighScore(playerName, scoreModel.Score);
        }

        public void LoadDataToGame(GameData dataToLoad)
        {
            _highScoreTable = dataToLoad._highScoreTable;
        }
        
        private void TryUpdateHighScore(string newName, int scoreModelScore)
        {
            // As high score table consists of 10 element, no need for binary search
            for (int index = 0; index < _highScoreTable.Length - 1; index++)
            {
                if (scoreModelScore >= _highScoreTable[index]._score)
                {
                    // Shift operation from end till index
                    for (int shiftIndex = _highScoreTable.Length - 1; shiftIndex > index; shiftIndex--)
                    {
                        _highScoreTable[shiftIndex] = _highScoreTable[shiftIndex - 1];
                    }

                    // Create new entry and save in table
                    _highScoreTable[index] = new HighScoreEntry(newName, scoreModelScore);
                    return;
                }
            }
        }
    }
}