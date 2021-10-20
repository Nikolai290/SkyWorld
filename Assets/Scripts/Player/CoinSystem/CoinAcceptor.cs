using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Player.CoinSystem {
    public class CoinAcceptor : MonoBehaviour {

        public Text CoinText;
        public Text CoinStorageText;

        public int CoinStore { get; private set; }
        public int Coins { get; private set; }

        public Action<int> OnCoinValueChanged;
        public Action<int> OnCoinStorageValueChanged;

        private void Start() {
            OnCoinValueChanged += CoinValueChangeHandler;
            OnCoinStorageValueChanged += CoinStorageValueChangeHandler;
            var coinStorage = PlayerPrefs.HasKey("Coin") ? PlayerPrefs.GetInt("Coin") : 0;
            SetCoinStore(coinStorage);
            SetCoins(0);
        }

        private void OnTriggerEnter2D(Collider2D collision) {
            if (collision.gameObject.tag == "Coin") {
                SetCoins(Coins+1);
                Destroy(collision.gameObject);
            }
        }

        public void PutToStore(float multiple = 1) {
            CoinStore += (int)(Coins * multiple);
            SetCoinStore(CoinStore);
            SetCoins(0);
            PlayerPrefs.SetInt("Coin", CoinStore);
        }

        private void SetCoinStore(int value) {
            CoinStore = value;
            OnCoinStorageValueChanged.Invoke(CoinStore);
        }

        private void SetCoins(int value) {
            Coins = value;
            OnCoinValueChanged.Invoke(Coins);
        }

        private void CoinValueChangeHandler(int value) {
            CoinText.text = value.ToString();
        }
        private void CoinStorageValueChangeHandler(int value) {
            CoinStorageText.text = value.ToString();
        }

    }
}
