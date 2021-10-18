using UnityEngine;
using UnityEngine.EventSystems;

namespace SkyWorld.InputSystem {
    public class GamePad : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler {
        public float getSpeedMultiple => _currentDistance / _maxDistance;
        public Vector3 getInput => (_gamepadInput - _startPosition).normalized;
        
        [Header("Links")]
        [SerializeField] private RectTransform _gamePad;
        [SerializeField] private RectTransform _center;

        private Vector2 _disablePosition;
        private Vector2 _disablePositionCenter;
        private Vector2 _startPosition;
        private Vector2 _gamepadInput;
        private float _currentDistance;
        private float _maxDistance;
        
        private void Awake() {
            _disablePosition = _gamePad.position;
            _disablePositionCenter = _center.position;
            _maxDistance = _gamePad.rect.height * 0.5f * (Screen.height / 1080f);
        }

        public void OnPointerDown(PointerEventData eventData) {
            _startPosition = eventData.position;
            _gamePad.position = _startPosition;
        }
        
        public void OnDrag(PointerEventData eventData) {
            _gamepadInput = Vector2.MoveTowards(_startPosition, eventData.position, _maxDistance);
            _currentDistance = Vector2.Distance(_startPosition, _gamepadInput);
            _center.position = _gamepadInput;
        }
        
        public void OnPointerUp(PointerEventData eventData) {
            _gamepadInput = _startPosition;
            _gamePad.position = _disablePosition;
            _center.position = _disablePositionCenter;
        }
    }
}