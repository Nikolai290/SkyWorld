using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Player.FuelSystem {
    public class FuelIndicator : MonoBehaviour{

        private Image _image;
        public void Awake() {
            _image = GetComponent<Image>();
        }

        public void OnChangeFuelValue(float value) {
            _image.fillAmount = value;
        }
    }
}
