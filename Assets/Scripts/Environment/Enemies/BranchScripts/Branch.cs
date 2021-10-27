using Assets.Scripts.Common.Consts;
using Assets.Scripts.Player.HealthSystem;
using UnityEngine;

namespace Assets.Scripts.Environment.Enemies.BranchScripts {
    public class Branch : MonoBehaviour {

        private int _damage = 1;

        public void Init(int damage) {
            _damage = damage > 0? damage : -damage;
        }

        private void OnTriggerEnter2D(Collider2D collision) {
            if (collision.gameObject.tag == Tags.PLAYER) {
                try {
                    collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(_damage);
                    Destroy(gameObject);
                } catch {
                    Debug.LogError("Player hasn't 'PlayerHealth' script!");
                }
                // TODO: add animation and sound effect
            }
        }
    }
}