using Assets.Scripts.Player.FuelSystem;
using Assets.Scripts.Player.Parameters;
using System;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Player {
    public class BalloonFuel : MonoBehaviour {

        [SerializeField] private FuelParametres _fuelParametres;
        [Inject] private FuelIndicator _fuelIndicator;

        private float _fuelValue;

        public Action<float> OnFuelValueChanged;

        public void Start() {
            FillTank();
        }

        public bool HeatUp(Vector2 input) {
            SetFuelValue(_fuelValue
                - (input.y > 0 ? input.y : 0) * _fuelParametres.fuelExpenseRate * Time.deltaTime
                - Mathf.Abs(input.x) / 2 * _fuelParametres.fuelExpenseRate * Time.deltaTime
            );
            return _fuelValue > 0;
        }

        public void SetFuelValue(float value) {
            _fuelValue = value;
            _fuelIndicator.OnChangeFuelValue(value / _fuelParametres.fuelCapacity);
        }

        public float GetFuelValue() {
            return _fuelValue;
        }

        public void FillTank() {
            SetFuelValue(_fuelParametres.fuelCapacity);
        }
    }
}