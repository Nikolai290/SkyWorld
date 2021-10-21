using UnityEngine;
using UnityEngine.UI;

namespace SkyWorld.Global {
    public class GameScore : MonoBehaviour {
        [SerializeField] private Text _inGameScoreText;

        private int _recordScore;
        private int _score;
        private string RECORD_SCORE = "RecordScore";

        public int GetScrore => _score;

        public bool CheckRecord => _score > _recordScore;


        public void Start() {
            _recordScore = PlayerPrefs.HasKey(RECORD_SCORE) 
                ? PlayerPrefs.GetInt(RECORD_SCORE) 
                : 0;
        }

        public void SetScore(int score) {
            _score = score;
            _inGameScoreText.text = score.ToString();
        }

        internal void FixRecord() {
            if(CheckRecord) {
                PlayerPrefs.SetInt(RECORD_SCORE, _score);
            }
        }
    }
}