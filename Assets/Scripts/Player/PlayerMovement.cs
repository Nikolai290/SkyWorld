using Assets.Scripts.Environment.Parameters;
using Assets.Scripts.Player;
using Assets.Scripts.Player.HealthSystem;
using SkyWorld.Environment.Parameters;
using SkyWorld.InputSystem;
using SkyWorld.Player.Parameters;
using UnityEngine;

namespace SkyWorld.Player {
    public class PlayerMovement : MonoBehaviour {
        [SerializeField] private PlayerParameters _parameters;
        [SerializeField] private GamePad _gamePad;
        [SerializeField] private BalloonFuel _fuelSystem;
        [SerializeField] private WorldParameters _worldParameters;
        [SerializeField] private WorldBorders _worldBorders;
        private PlayerHealth playerHealth;

        private float _playerHeight = 4f;

        private bool _isEndGame;
        public float TotalSpeed => _parameters.speed * _gamePad.getSpeedMultiple;

        private void Awake() {
            playerHealth = GetComponent<PlayerHealth>();
            playerHealth.Init(_parameters.health);
        }

        private void Update() {
            if (_isEndGame) return;

            var movementVector = _fuelSystem.HeatUp(_gamePad.getInput)
                ? new Vector3(_gamePad.getInput.x, _gamePad.getInput.y)
                : new Vector3(0, 0);

            Vector3 nextPosition = transform.position + movementVector * (TotalSpeed * Time.deltaTime);
            nextPosition.Set(nextPosition.x + _worldParameters.worldSpeed * Time.deltaTime,
                Mathf.Clamp(nextPosition.y - _parameters.fallRate, _worldBorders.BottomBorder.position.y, _worldBorders.TopBorder.position.y - _playerHeight), 
                nextPosition.z);
            transform.position = nextPosition;
        }

        public void StopGameHandler() {
            _isEndGame = true;
        }
    }
}