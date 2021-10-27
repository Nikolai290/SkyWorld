using Assets.Scripts.Environment.Parameters;
using Assets.Scripts.Player;
using SkyWorld.Environment.Parameters;
using SkyWorld.Player;
using SkyWorld.Player.Parameters;
using UnityEngine;
using Zenject;

namespace SkyWorld.Environment {
    public class CameraMovementV2 : MonoBehaviour {
        [Header("Links")]
        [Inject] private PlayerParameters _playerParameters;
        [Inject] private CameraParameters _cameraParameters;

        [Inject] private WorldBorders _worldBorders;
        [Inject] private IPlayerMovement _playerMovement;
        private Camera _thisCamera;
        private float _maxPositionDifPerFrame;

        private float _bottomOffset = 6;

        private float LeftCameraPostionBorder 
            => _worldBorders.LeftBorder.position.x + _cameraParameters.xBorderOffset;
        private float RightCameraPostionBorder 
            => _worldBorders.RightBorder.position.x - _cameraParameters.xBorderOffset;
        private float TopCameraPostionBorder 
            => _worldBorders.TopBorder.position.y - _cameraParameters.yBorderOffset;
        private float BottomCameraPostionBorder 
            => _worldBorders.BottomBorder.position.y + _bottomOffset;

        private float _speed;
        private bool _isGame;
        private Vector3 nextPosition;
        public CameraMovementV2(IPlayerMovement playerMovement) {
            this._playerMovement = playerMovement;
        }


        private void Start() {
            _thisCamera = GetComponent<Camera>();
            _speed = _playerParameters.speed;
            _isGame = true;
        }

        private void LateUpdate() {
            if (!_isGame) return;
            //
            var difX = nextPosition.x - transform.position.x;
            var difY = Mathf.Abs((nextPosition.y - transform.position.y) * 2.5f);
            var difFrame = difX > difY ? difX : difY;

            if (difFrame > _maxPositionDifPerFrame) {
                _maxPositionDifPerFrame = difFrame;
            }

            var orthographicSize = _cameraParameters.minSize + (difFrame / _maxPositionDifPerFrame * (_cameraParameters.maxSize - _cameraParameters.minSize));
            _bottomOffset = orthographicSize;
            _thisCamera.orthographicSize = orthographicSize;
            //
            var x = _playerMovement.transform.position.x > RightCameraPostionBorder
                ? RightCameraPostionBorder
                : _playerMovement.transform.position.x < LeftCameraPostionBorder
                ? LeftCameraPostionBorder
                : _playerMovement.transform.position.x + _cameraParameters.xBorderOffset * 0.7f;

            var y = _playerMovement.transform.position.y > TopCameraPostionBorder
                ? TopCameraPostionBorder
                : _playerMovement.transform.position.y < BottomCameraPostionBorder
                ? BottomCameraPostionBorder
                : _playerMovement.transform.position.y;

            nextPosition = new Vector3(x, y);
            nextPosition.z = transform.position.z;
            var speed = _speed * Time.deltaTime;
            //
            transform.position = Vector3.Lerp(transform.position, nextPosition, speed * _cameraParameters.speedMultiple);
        }
    }
}