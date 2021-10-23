using Assets.Scripts.Environment.Parameters;
using SkyWorld.Environment.Parameters;
using SkyWorld.Player.Parameters;
using UnityEngine;

namespace SkyWorld.Environment {
    public class CameraMovementV2 : MonoBehaviour {
        [Header("Links")]
        [SerializeField] private Transform _playerTransform;
        [SerializeField] private PlayerParameters _playerParameters;
        [SerializeField] private CameraParameters _cameraParameters;
        [SerializeField] private WorldBorders _worldBorders;

        private float LeftCameraPostionBorder => _worldBorders.LeftBorder.position.x + _cameraParameters.xBorderOffset;
        private float RightCameraPostionBorder => _worldBorders.RightBorder.position.x - _cameraParameters.xBorderOffset;
        private float TopCameraPostionBorder => _worldBorders.TopBorder.position.y - _cameraParameters.yBorderOffset;
        private float BottomCameraPostionBorder => _worldBorders.BottomBorder.position.y + _cameraParameters.yBorderOffset;

        private float _speed;
        private bool _isGame;

        private void Start() {
            _speed = _playerParameters.speed;
            _isGame = true;
        }

        private void LateUpdate() {
            if (!_isGame) return;
            var x = _playerTransform.position.x > RightCameraPostionBorder
                ? RightCameraPostionBorder
                : _playerTransform.position.x < LeftCameraPostionBorder
                ? LeftCameraPostionBorder
                : _playerTransform.position.x + _cameraParameters.xBorderOffset / 2;

            var y = _playerTransform.position.y > TopCameraPostionBorder
                ? TopCameraPostionBorder
                : _playerTransform.position.y < BottomCameraPostionBorder
                ? BottomCameraPostionBorder
                : _playerTransform.position.y;

            var nextPosition = new Vector3(x, y);
            nextPosition.z = transform.position.z;

            transform.position = Vector3.Lerp(transform.position, nextPosition, _speed * _cameraParameters.speedMultiple * Time.deltaTime);
        }
    }
}