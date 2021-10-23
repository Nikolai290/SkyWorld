using Assets.Scripts.Environment.Parameters;
using SkyWorld.Environment.Parameters;
using SkyWorld.Player;
using SkyWorld.Player.Parameters;
using UnityEngine;

namespace SkyWorld.Environment {
    public class CameraMovementV2 : MonoBehaviour {
        [Header("Links")]
        [SerializeField] private GameObject _player;
        [SerializeField] private PlayerParameters _playerParameters;
        [SerializeField] private CameraParameters _cameraParameters;
        [SerializeField] private WorldBorders _worldBorders;

        private Camera _thisCamera;
        private PlayerMovement _playerMovement;
        private float _maxPositionDifPerFrame;

        private float LeftCameraPostionBorder 
            => _worldBorders.LeftBorder.position.x + _cameraParameters.xBorderOffset;
        private float RightCameraPostionBorder 
            => _worldBorders.RightBorder.position.x - _cameraParameters.xBorderOffset;
        private float TopCameraPostionBorder 
            => _worldBorders.TopBorder.position.y - _cameraParameters.yBorderOffset;
        private float BottomCameraPostionBorder 
            => _worldBorders.BottomBorder.position.y + _cameraParameters.yBorderOffset;

        private float _speed;
        private bool _isGame;

        private void Start() {
            _playerMovement = _player.GetComponent<PlayerMovement>();
            _thisCamera = GetComponent<Camera>();
            _speed = _playerParameters.speed;
            _isGame = true;
        }

        private void LateUpdate() {
            if (!_isGame) return;
            var x = _player.transform.position.x > RightCameraPostionBorder
                ? RightCameraPostionBorder
                : _player.transform.position.x < LeftCameraPostionBorder
                ? LeftCameraPostionBorder
                : _player.transform.position.x + _cameraParameters.xBorderOffset * 0.7f;

            var y = _player.transform.position.y > TopCameraPostionBorder
                ? TopCameraPostionBorder
                : _player.transform.position.y < BottomCameraPostionBorder
                ? BottomCameraPostionBorder
                : _player.transform.position.y;

            var nextPosition = new Vector3(x, y);
            nextPosition.z = transform.position.z;
            var speed = _speed * Time.deltaTime;
            var difX = nextPosition.x - transform.position.x;
            var difY = Mathf.Abs((nextPosition.y - transform.position.y) * 2.5f);

            var difFrame = difX > difY ? difX : difY;
            if (difFrame > _maxPositionDifPerFrame) {
                _maxPositionDifPerFrame = difFrame;
            }
            _thisCamera.orthographicSize = _cameraParameters.minSize + (difFrame / _maxPositionDifPerFrame * (_cameraParameters.maxSize - _cameraParameters.minSize));

            transform.position = Vector3.Lerp(transform.position, nextPosition, speed * _cameraParameters.speedMultiple);
        }
    }
}