using Assets.Scripts.Player;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace SkyWorld.Global {
    public class GameScore : MonoBehaviour {
        [SerializeField] private Text _inGameScoreText;
        [Inject] private IPlayerMovement _playerMovement;

        private int _recordScore;
        private int _score;
        private string RECORD_SCORE = "RecordScore";
        private Vector3 _startCameraPos;

        public int GetScrore => _score;

        public bool CheckRecord => _score > _recordScore;

        private void Awake() {
            _startCameraPos = _playerMovement.transform.position;
        }

        public void Start() {
            _recordScore = PlayerPrefs.HasKey(RECORD_SCORE) 
                ? PlayerPrefs.GetInt(RECORD_SCORE) 
                : 0;
        }
        private void Update() {
            SetScore((int)Vector3.Distance(_startCameraPos, _playerMovement.transform.position));
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