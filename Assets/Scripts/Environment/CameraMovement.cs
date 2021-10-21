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

        private Transform _thisTransform;
        private Vector3 _startCameraPos;
        private float _speed;
        private bool _isGame;

        private void Awake() {
            _thisTransform = transform;
            _startCameraPos = _thisTransform.position;
        }

        private void Start() {
            _speed = _playerParameters.speed;
            _isGame = true;
        }

        private void LateUpdate() {
            if (!_isGame) return;
            SetScore();
            
            Vector3 currentPosition = _thisTransform.position;
            _thisTransform.position = new Vector3(currentPosition.x + (_worldParameters.worldSpeed * Time.deltaTime), currentPosition.y, currentPosition.z);
            
            Vector3 nextCameraPos = _playerTransform.position;
            nextCameraPos.Set(nextCameraPos.x, _startCameraPos.y, _startCameraPos.z);

            if (_thisTransform.position.x - nextCameraPos.x > _worldParameters.endGameOffset) EndGame();
            
            if (nextCameraPos.x - _thisTransform.position.x < _cameraParameters.offset) {
                _speed = _playerParameters.speed;
                return;
            }
            _thisTransform.position = Vector3.MoveTowards(_thisTransform.position,nextCameraPos, _speed * Time.deltaTime);
            _speed += _cameraParameters.speedMultiple;
        }

        private void EndGame() {
            _isGame = false;
            _endGameScript.EndGame();
        }

        private void SetScore() {
            _gameScore.SetScore((int)Vector3.Distance(_startCameraPos, _thisTransform.position));
        }
    }
}