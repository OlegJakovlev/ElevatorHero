using Score;
using UnityEngine;

namespace SaveAndLoadSystem.HighScore
{
    [RequireComponent(typeof(ScoreSetup))]
    public class HighScoreManager : MonoBehaviour
    {
        public static HighScoreManager Instance;
    
        [Header("Score")]
        private ScoreSetup _score;
        private HighScoreEntry[] _highScoreTable;

        private int _newHighScore;

        private void Awake()
        {
            if (!Instance) Instance = this;
            else Destroy(gameObject);
        
            _score = GetComponent<ScoreSetup>();
        }

        private void Start()
        {
            _highScoreTable = Serializer.SaveLoadManager.GetModel()._highScoreTable;
        }

        public void CheckForHighScore()
        {
            int currentScore = _score.GetModel().Score;

            // If player score is same or higher than last place, player should be teleported to enter his name
            if (_highScoreTable == null || currentScore >= _highScoreTable[_highScoreTable.Length - 1]._score)
            {
                CustomSceneManager.Instance.LoadSceneByName("HighscoreEntry");
                _newHighScore = currentScore;
            }
            else
            {
                CustomSceneManager.Instance.LoadSceneByName("HighscoreTable");
            }
        }
    }
}
