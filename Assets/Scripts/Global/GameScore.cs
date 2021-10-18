using UnityEngine;
using UnityEngine.UI;

namespace SkyWorld.Global {
    public class GameScore : MonoBehaviour {
        [SerializeField] private Canvas _endGameCanvas;
        [SerializeField] private Text _inGameScoreText;
        [SerializeField] private Text _endScoreText;

        private int _score;
        
        private const string _scoreParam = "SCORE: ";

        public void SetScore(int score) {
            _score = score;
            _inGameScoreText.text = score.ToString();
        }
        
        public void EndGame() {
            _endGameCanvas.enabled = true;
            _endScoreText.text = $"{_scoreParam}{_score}";
        }
    }
}