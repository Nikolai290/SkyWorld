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
        private PlayerHealth playerHealth;


        private const float _Y_MAX_LIMIT = 3.5f;
        private const float _Y_MIN_LIMIT = -4.5f;

        private bool _isEndGame;

        private void Awake() {
            playerHealth = GetComponent<PlayerHealth>();
            playerHealth.Init(_parameters.health);
        }

        private void Start() {
        }

        private void Update() {
            if (_isEndGame) return;

            var movementVector = _fuelSystem.HeatUp(_gamePad.getInput)
                ? new Vector3(_gamePad.getInput.x, _gamePad.getInput.y)
                : new Vector3(0, 0);

            Vector3 nextPosition = transform.position + movementVector * (_parameters.speed * _gamePad.getSpeedMultiple * Time.deltaTime);
            nextPosition.Set(nextPosition.x + _worldParameters.worldSpeed * Time.deltaTime / 2,
                Mathf.Clamp(nextPosition.y - _parameters.fallRate, _Y_MIN_LIMIT, _Y_MAX_LIMIT), 
                nextPosition.z);
            transform.position = nextPosition;
        }

        public void StopGameHandler() {
            _isEndGame = true;
        }
    }
}