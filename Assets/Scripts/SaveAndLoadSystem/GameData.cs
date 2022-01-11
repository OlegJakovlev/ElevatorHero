using System;
using System.Collections.Generic;
using SaveAndLoadSystem.HighScore;
using Score.MVP;

namespace SaveAndLoadSystem
{
    [Serializable]
    public class GameData
    {
        public List<HighScoreEntry> _highScoreTable;

        public void CollectDataToSave(ScoreModel scoreModel)
        {
            //TryUpdateHighScore(scoreModel.Score);
        }

        public void LoadDataToGame(GameData dataToLoad)
        {
            _highScoreTable = dataToLoad._highScoreTable;
        }
        
        private void TryUpdateHighScore(string newName, int scoreModelScore)
        {
            // As high score table consists of 10 element, no need for binary search
            for (int index = 0; index < _highScoreTable.Count - 1; index++)
            {
                if (scoreModelScore > _highScoreTable[index].Score)
                {
                    // Shift operation from end till index
                    for (int shiftIndex = _highScoreTable.Count - 1; shiftIndex > index; shiftIndex--)
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