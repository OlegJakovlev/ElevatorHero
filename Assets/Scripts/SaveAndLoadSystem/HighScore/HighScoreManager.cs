using Components.Score;
using UnityEngine;

namespace SaveAndLoadSystem.HighScore
{
    [RequireComponent(typeof(ScoreSetup))]
    public class HighScoreManager : MonoBehaviour
    {
        public static HighScoreManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = FindObjectOfType(typeof(HighScoreManager)) as HighScoreManager;
 
                return _instance;
            }
            
            private set => _instance = _instance == null ? value : null;
        }
        private static HighScoreManager _instance;
    
        [Header("Score")]
        private ScoreSetup _score;
        private HighScoreEntry[] _highScoreTable;

        public int NewHighScore { get; private set; }

        private void Awake()
        {
            Instance = this;
            _score = GetComponent<ScoreSetup>();
        }

        private void Start()
        {
            _highScoreTable = Serializer.SaveLoadManager.GetModel()._highScoreTable;
        }
        
        public void ResetHighScore()
        {
            NewHighScore = 0;
        }

        public void CheckForHighScore()
        {
            int currentScore = _score.GetModel().Score;

            // If player score is same or higher than last place, player should enter his name
            if (_highScoreTable == null || currentScore >= _highScoreTable[_highScoreTable.Length - 1]._score)
            {
                NewHighScore = currentScore;
                CustomSceneManager.Instance.LoadSceneByName("HighscoreEntry");
            }
            else
            {
                CustomSceneManager.Instance.LoadSceneByName("HighscoreTable");
            }
            
            // Reset score
            _score.GetModel().ResetScore();
        }
    }
}
