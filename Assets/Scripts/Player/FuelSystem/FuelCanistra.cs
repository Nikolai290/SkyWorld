using UnityEngine;

namespace Assets.Scripts.Player.FuelSystem {
    public class FuelCanistra : MonoBehaviour {
        private readonly string PlayerTag = "Player";

        public void OnTriggerEnter2D(Collider2D collision) {
            if(collision.gameObject.tag == PlayerTag) {
                try {
                    collision.gameObject.GetComponentInChildren<BalloonFuel>().FillTank();
                    Destroy(gameObject);
                } catch {
                    Debug.Log("Player's children hasn't 'BalloonFuel' scritp");
                }
            }
        }
    }
}
