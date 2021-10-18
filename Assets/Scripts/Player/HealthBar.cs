using UnityEngine;
using UnityEngine.UI;

namespace SkyWorld.Player {
    public class HealthBar : MonoBehaviour {
        private Color _active = Color.white;
        private Color _unActive = Color.black;

        private Transform _thisTransform;
        private Image[] _health;

        private void Awake() {
            _thisTransform = transform;
            _health = new Image[_thisTransform.childCount];
            for (int healthId = 0; healthId < _health.Length; healthId++) _health[healthId] = _thisTransform.GetChild(healthId).GetComponent<Image>();
        }

        public void DisplayHealth(int health) {
            if (health >= _health.Length) return;

            for (int healthId = 0; healthId < health; healthId++) {
                _health[healthId].color = _active;
            }

            for (int healthId = health; healthId < _health.Length; healthId++) {
                _health[healthId].color = _unActive;
            }
        }
    }
}