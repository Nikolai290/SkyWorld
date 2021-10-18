using UnityEngine;

namespace Assets.Scripts.Player.Parameters {

    [CreateAssetMenu(fileName = "FuelParameters", menuName = "SkyWorld/FuelParameters")]
    public class FuelParametres : ScriptableObject {
        public float fuelCapacity;
        public float fuelExpenseRate;
    }
}