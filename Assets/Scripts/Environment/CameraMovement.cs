using Assets.Scripts.Global;
using SkyWorld.Environment.Parameters;
using SkyWorld.Global;
using SkyWorld.Player.Parameters;
using UnityEngine;

namespace SkyWorld.Environment {
    public class CameraMovement : MonoBehaviour {
        [Header("Links")]
        [SerializeField] private Transform _playerTransform;
        [SerializeField] private GameScore _gameScore;
        [SerializeField] private PlayerParameters _playerParameters;
        [SerializeField] private CameraParameters _cameraParameters;
        [SerializeField] private WorldParameters _worldParameters;
        [SerializeField] private EndGameScript _endGameScript;

        private Vector3 _startCameraPos;
        private float _speed;
        private bool _isGame;

        private void Awake() {
            _startCameraPos = transform.position;
        }

        private void Start() {
            _speed = _playerParameters.speed;
            _isGame = true;
        }

        private void LateUpdate() {
            if (!_isGame) return;
            SetScore();
            
            Vector3 currentPosition = transform.position;
            transform.position = new Vector3(currentPosition.x + (_worldParameters.worldSpeed * Time.deltaTime), currentPosition.y, currentPosition.z);
            
            Vector3 nextCameraPos = _playerTransform.position;
            nextCameraPos.Set(nextCameraPos.x, _startCameraPos.y, _startCameraPos.z);

            if (transform.position.x - nextCameraPos.x > _worldParameters.endGameOffset) EndGame();
            var offset = 10f;
            if (nextCameraPos.x - transform.position.x < offset) {
                _speed = _playerParameters.speed;
                return;
            }
            transform.position = Vector3.MoveTowards(transform.position,nextCameraPos, _speed * Time.deltaTime);
            _speed += _cameraParameters.speedMultiple;
        }

        private void EndGame() {
            _isGame = false;
            _endGameScript.EndGame();
        }

        private void SetScore() {
            _gameScore.SetScore((int)Vector3.Distance(_startCameraPos, transform.position));
        }
    }
}