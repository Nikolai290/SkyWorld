using Assets.Scripts.Environment.Enemies.Spawner;
using Assets.Scripts.Player.HealthSystem;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Environment.Enemies {
    public class Spike : MonoBehaviour, ISpawnedObjectBehaviour {

        private float _speed;
        private float _lifetime;
        private int _damage;
        private Vector3 _direction;

        public bool isInit;

        private string PLAYER = "Player";

        public void Init(float speed, float lifetime, int damage, Vector3 direction) {
            if (isInit) return;
            _speed = speed;
            _lifetime = lifetime;
            _damage = damage;
            _direction = direction;
            isInit = true;
            StartCoroutine(nameof(LifetimeCountDown));
        }

        private IEnumerator LifetimeCountDown() {
            yield return new WaitForSeconds(_lifetime);
            Destroy(gameObject);
        }

        private void Update() {
            if (!isInit) return;
            var nextPosition = transform.localPosition + _direction * _speed*Time.deltaTime;
            transform.localPosition = nextPosition;
        }

        private void OnTriggerEnter2D(Collider2D collision) {
            if(collision.gameObject.tag == PLAYER) {
                try {
                    collision.gameObject.GetComponent<PlayerHealth>().TakeDamage();
                    Destroy(gameObject);
                } catch {
                    Debug.LogError("Player hasn't 'PlayerHealth' script!");
                }
                // TODO: add animation and sound effect
            }
        }

        public void Init(ISpawnedObjectParametres parametres) {
            throw new System.NotImplementedException();
        }
    }
}