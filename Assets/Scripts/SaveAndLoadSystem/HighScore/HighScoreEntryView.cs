using UnityEngine;
using UnityEngine.UI;

namespace SaveAndLoadSystem.HighScore
{
    public class HighScoreEntryView : MonoBehaviour
    {
        public string Nickname
        {
            set => _nickname.text = value;
        }

        [SerializeField] private Text _nickname;
        
        public string Score
        {
            set => _scoreResult.text = value;
        }

        [SerializeField] private Text _scoreResult;
    }
}