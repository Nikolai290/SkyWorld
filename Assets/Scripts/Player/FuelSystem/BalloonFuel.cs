using Assets.Scripts.Player.FuelSystem;
using Assets.Scripts.Player.Parameters;
using System;
using UnityEngine;

namespace Assets.Scripts.Player {
    public class BalloonFuel : MonoBehaviour {

        [SerializeField] private FuelParametres _fuelParametres;
        [SerializeField] private FuelIndicator _fuelIndicator;

        private float _fuelValue;

        public Action<float> OnFuelValueChanged;

        public void Start() {
            FillTank();
        }

        public void HeatUp(float yInput) {
            if (yInput > 0) {
                SetFuelValue(_fuelValue - yInput * _fuelParametres.fuelExpenseRate * Time.deltaTime);
            }
        }

        public void SetFuelValue(float value) {
            _fuelValue = value;
            _fuelIndicator.OnChangeFuelValue(value/_fuelParametres.fuelCapacity);
        }

        public float GetFuelValue() {
            return _fuelValue;
        }

        public void FillTank() {
            SetFuelValue(_fuelParametres.fuelCapacity);
        }
    }
}