using Assets.Scripts.Environment.Parameters;
using Assets.Scripts.Player;
using Assets.Scripts.Player.HealthSystem;
using SkyWorld.Environment.Parameters;
using SkyWorld.InputSystem;
using SkyWorld.Player.Parameters;
using System.Collections;
using UnityEngine;
using Zenject;

namespace SkyWorld.Player {
    public class PlayerMovement : MonoBehaviour, IPlayerMovement {
        [Inject] private PlayerParameters _parameters;
        [Inject] private WorldParameters _worldParameters;

        [Inject] private WorldBorders _worldBorders;
        [Inject] private GamePad _gamePad;

        private PlayerHealth playerHealth;
        private BalloonFuel _fuelSystem;
        private float _playerHeight = 4f;
        private bool _isEndGame;

        private bool _influence;
        private Vector3 _externalInfluence;

        public float TotalSpeed => _parameters.speed * _gamePad.getSpeedMultiple;

        private void Awake() {
            playerHealth = GetComponent<PlayerHealth>();
            playerHealth.Init(_parameters.health);
        }

        private void Start() {
            _fuelSystem = GetComponentInChildren<BalloonFuel>();
        }

        private void Update() {
            if (_isEndGame) return;

            var movementVector = _fuelSystem.HeatUp(_gamePad.getInput)
                ? new Vector3(_gamePad.getInput.x, _gamePad.getInput.y)
                : new Vector3(0, 0);
            if (_influence) {
                movementVector += _externalInfluence;
                Debug.Log("WingInfluence power: " + _externalInfluence);

            }

            Vector3 nextPosition = transform.position + movementVector * (TotalSpeed * Time.deltaTime);
            nextPosition.Set(nextPosition.x + _worldParameters.worldSpeed * Time.deltaTime + _externalInfluence.x,
                Mathf.Clamp(nextPosition.y +_externalInfluence.y - _parameters.fallRate, _worldBorders.BottomBorder.position.y, _worldBorders.TopBorder.position.y - _playerHeight), 
                nextPosition.z);
            transform.position = nextPosition;
        }

        public void StopGameHandler() {
            _isEndGame = true;
        }

        public void WingInfluenceStart(float power) {
            _influence = true;
            StartCoroutine(WingInfluence(power));
            Debug.Log("WingInfluenceStart");

        }

        private IEnumerator WingInfluence(float power) {
            while (_influence) {
                _externalInfluence = new Vector3(Random.Range(-power, power), Random.Range(-power, power));
                yield return new WaitForSeconds(Random.Range(0.1f, 0.3f));
            }
        }

        public void WingInfluenceEnd() {
            Debug.Log("WingInfluenceEnd");
            _influence = false;
            _externalInfluence = new Vector3();
        }
    }
}