using Assets.Scripts.Player;
using Assets.Scripts.Player.HealthSystem;
using SkyWorld.Global;
using SkyWorld.Player;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.Global {
    public class EndGameScript : MonoBehaviour {
        private Canvas _endGameCanvas;
        [SerializeField] private Text _endScoreText;
        [SerializeField] private Text _endCoinsText;

        [Inject] private GameScore _gameScore;
        [Inject] private GameCoins _gameCoins;
        [Inject] private IPlayerMovement _playerMovement;

        private PlayerHealth _playerHealth;

        private bool _isEndGame = false;

        public bool IsEndGame => _isEndGame;

        private void Start() {
            _endGameCanvas = GetComponent<Canvas>();
            _playerHealth = _playerMovement.gameObject.GetComponent<PlayerHealth>();
            _playerHealth.OnPlayerDie += EndGame;
        }

        private const string _scoreParam = "SCORE: ";
        private const string _scoreRecordParam = "NEW RECORD!!! SCORE: ";
        private const string _coinsParam = "COINS: ";

        public void EndGame() {
            Time.timeScale = 0;
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
