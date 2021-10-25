using Assets.Scripts.Common.Consts;
using Assets.Scripts.Player.HealthSystem;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Environment.Enemies.BranchScripts {
    public class Branch : MonoBehaviour {
        private float _speed;
        private Transform _target;
        private bool _randomRotation;
        private float _rotationSpeed;
        private bool _isInit;

        public void Init(float speed, float rotationSpeed, Transform target) {
            _speed = speed;
            _target = target;
            _rotationSpeed = rotationSpeed;
            _isInit = true;
        }

        public void Init(float speed, bool randomRotation, Transform target) {
            _speed = speed;
            _target = target;
            _randomRotation = randomRotation;
            _isInit = true;
        }

        private void Start() {
            if (_randomRotation) {
                var rot = Random.Range(60, 360);
                var pos = Random.Range(0f, 1f) > 0.5f;
                _rotationSpeed = pos ? rot : -rot;
            }
        }

        private void OnTriggerEnter2D(Collider2D collision) {
            if (collision.gameObject.tag == Tags.PLAYER) {
                try {
                    collision.gameObject.GetComponent<PlayerHealth>().TakeDamage();
                    Destroy(gameObject);
                } catch {
                    Debug.LogError("Player hasn't 'PlayerHealth' script!");
                }
                // TODO: add animation and sound effect
            }
        }

        private void Update() {
            if (!_isInit) return;
            transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
            Rotate();

            if (transform.position == _target.position) {
                Destroy(gameObject);
            }
        }

        private void Rotate() {

            transform.Rotate(0, 0, _rotationSpeed * Time.deltaTime);
        }
    }
}