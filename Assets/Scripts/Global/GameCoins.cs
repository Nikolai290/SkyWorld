using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Global {
    public class GameCoins : MonoBehaviour {

        [SerializeField] private Text _coinText;
        [SerializeField] private Text _coinStorageText;

        public int CoinStore { get; private set; }
        public int Coins { get; private set; }

        private void Start() {
            var coinStorage = PlayerPrefs.HasKey("Coin") ? PlayerPrefs.GetInt("Coin") : 0;
            SetCoinStore(coinStorage);
            SetCoins(0);
        }

        public void PutToStore(float multiple = 1) {
            CoinStore += (int)(Coins * multiple);
            SetCoinStore(CoinStore);
            SetCoins(0);
            PlayerPrefs.SetInt("Coin", CoinStore);
        }

        public void SetCoinStore(int value) {
            CoinStore = value;
            _coinStorageText.text = value.ToString();
        }

        public void SetCoins(int value) {
            Coins = value;
            _coinText.text = value.ToString();
        }
    }
}
