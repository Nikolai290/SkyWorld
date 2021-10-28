using Assets.Scripts.Common.Consts;
using Assets.Scripts.Player.HealthSystem;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Environment.Enemies {
    public class PermanentDamage : MonoBehaviour {
        [SerializeField] private int _damage;
        [SerializeField] private float _timeInterval;

        private PlayerHealth _playerHealth;
        private bool _playerOnTrigger;

        private void OnTriggerEnter2D(Collider2D collision) {
            if(collision.gameObject.tag == Tags.PLAYER) {
                try {
                    _playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
                    _playerOnTrigger = true;
                    StartCoroutine(DamagePlayer());
                } catch {
                    Debug.Log("Player hasn't 'PlayerHealth' script");
                }
            }
        }

        private void OnTriggerExit2D(Collider2D collision) {
            if(collision.gameObject.tag == Tags.PLAYER) {
                _playerOnTrigger = false;
            }
        }

        private IEnumerator DamagePlayer() {
            while (_playerOnTrigger) {
                yield return new WaitForSeconds(_timeInterval);
                if (!_playerOnTrigger) break;
                _playerHealth.TakeDamage(_damage);
            }
        }
    }
}