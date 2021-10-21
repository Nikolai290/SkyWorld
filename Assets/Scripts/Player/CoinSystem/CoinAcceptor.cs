using Assets.Scripts.Global;
using UnityEngine;

namespace Assets.Scripts.Player.CoinSystem {
    public class CoinAcceptor : MonoBehaviour {
        [SerializeField] private GameCoins _gameCoins;

        private void OnTriggerEnter2D(Collider2D collision) {
            if (collision.gameObject.tag == "Coin") {
                _gameCoins.SetCoins(_gameCoins.Coins + 1);
                Destroy(collision.gameObject);
            }
        }
    }
}
