using System;
using Score.MVP;

namespace SaveAndLoadSystem
{
    [Serializable]
    public class GameData
    {
        public int[] _highScoreTable = new int[10];

        public void CollectDataToSave(ScoreModel scoreModel)
        {
            TryUpdateHighScore(scoreModel.Score);
        }

        public void LoadDataToGame(GameData dataToLoad)
        {
            _highScoreTable = dataToLoad._highScoreTable;
        }
        
        private void TryUpdateHighScore(int scoreModelScore)
        {
            // As high score table consists of 10 element, no need for binary search
            for (int index = 0; index < _highScoreTable.Length - 1; index++)
            {
                if (scoreModelScore > _highScoreTable[index])
                {
                    // Shift operation from end till index
                    for (int shiftIndex = _highScoreTable.Length - 1; shiftIndex > index; shiftIndex--)
                    {
                        _highScoreTable[shiftIndex] = _highScoreTable[shiftIndex - 1];
                    }

                    _highScoreTable[index] = scoreModelScore;

                    return;
                }
            }
        }
    }
}