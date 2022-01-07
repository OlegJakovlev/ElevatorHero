using System;
using Score.MVP;
using UnityEngine;

namespace SaveAndLoadSystem
{
    [Serializable]
    public class GameData
    {
        public int _highScore;

        public void CollectDataToSave(ScoreModel scoreModel)
        {
            _highScore = scoreModel.Score;
        }

        public void LoadDataToGame()
        {
            Debug.Log(_highScore);
        }
    }
}