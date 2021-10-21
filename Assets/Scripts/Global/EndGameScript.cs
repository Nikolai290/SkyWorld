using SkyWorld.Global;
using SkyWorld.Player;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Global {
    public class EndGameScript : MonoBehaviour {
        private Canvas _endGameCanvas;
        [SerializeField] private Text _endScoreText;
        [SerializeField] private Text _endCoinsText;
        [SerializeField] private GameScore _gameScore;
        [SerializeField] private GameCoins _gameCoins;
        [SerializeField] private GameObject _player;

        private PlayerMovement _playerMovement;

        private bool _isEndGame = false;

        public bool IsEndGame => _isEndGame;

        private void Start() {
            _endGameCanvas = GetComponent<Canvas>();
            _playerMovement = _player.GetComponent<PlayerMovement>();
        }

        private const string _scoreParam = "SCORE: ";
        private const string _scoreRecordParam = "NEW RECORD!!! SCORE: ";
        private const string _coinsParam = "COINS: ";

        public void EndGame() {
            _playerMovement.StopGameHandler();
            _isEndGame = true;
            _endGameCanvas.enabled = true;

            _endScoreText.text = _gameScore.CheckRecord
                ? $"{_scoreRecordParam}{_gameScore.GetScrore}" 
                : $"{_scoreParam}{_gameScore.GetScrore}";
            _endCoinsText.text = $"{_coinsParam}{_gameCoins.Coins}";

            _gameCoins.PutToStore();
            _gameScore.FixRecord();
        }
    }
}
