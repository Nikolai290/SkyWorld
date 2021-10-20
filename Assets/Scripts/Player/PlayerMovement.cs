using Assets.Scripts.Player;
using SkyWorld.Environment.Parameters;
using SkyWorld.InputSystem;
using SkyWorld.Player.Parameters;
using UnityEngine;

namespace SkyWorld.Player {
    public class PlayerMovement : MonoBehaviour {
        [SerializeField] private PlayerParameters _parameters;
        [SerializeField] private HealthBar _healthBar;
        [SerializeField] private GamePad _gamePad;
        [SerializeField] private BalloonFuel _fuelSystem;
        [SerializeField] private WorldParameters _worldParameters;

        private Transform _thisTransform;
        private Animation _thisAnimation;

        private const float _Y_MAX_LIMIT = 3.5f;
        private const float _Y_MIN_LIMIT = -4.5f;

        private void Awake() {
            _thisTransform = transform;
            _thisAnimation = GetComponent<Animation>();
        }

        private void Start() {
            _healthBar.DisplayHealth(_parameters.health);
        }

        private void Update() {

            var movementVector = _fuelSystem.HeatUp(_gamePad.getInput)
                ? new Vector3(_gamePad.getInput.x, _gamePad.getInput.y)
                : new Vector3(0, 0);


            Vector3 nextPosition = _thisTransform.position + movementVector * (_parameters.speed * _gamePad.getSpeedMultiple * Time.deltaTime);
            nextPosition.Set(nextPosition.x + _worldParameters.worldSpeed * Time.deltaTime / 2,
                Mathf.Clamp(nextPosition.y - _parameters.fallRate, _Y_MIN_LIMIT, _Y_MAX_LIMIT), 
                nextPosition.z);
            _thisTransform.position = nextPosition;
        }
    }
}