using UnityEngine;
using UnityEngine.UI;

namespace Components.Score.MVP
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] private Text _scoreText;
        public void SetScore(int newScore)
        {
            _scoreText.text = "Score: " + newScore;
        }
    }
}