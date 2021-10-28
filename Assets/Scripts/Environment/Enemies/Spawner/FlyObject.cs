using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Environment.Enemies.BranchScripts {
    public class FlyObject : MonoBehaviour {
        private float _speed;
        private Transform _target;
        private Queue<Transform> _targets;
        private bool _randomRotation;
        private float _rotationSpeed;
        private bool _isInit;

        public void Init(FlyObjectParametres parametres, List<Transform> targets) {
            _randomRotation = parametres.randomRotation;
            _speed = parametres.speed;
            _targets = new Queue<Transform>(targets);
            _rotationSpeed = parametres.rotationSpeed;
            _target = _targets.Dequeue();
            _isInit = true;
        }

        private void Start() {
            if (_randomRotation) {
                var rot = Random.Range(60, 360);
                var pos = Random.Range(0f, 1f) > 0.5f;
                _rotationSpeed = pos ? rot : -rot;
            }
        }

        private void Update() {
            if (!_isInit) return;
            if (transform.position == _target.position) {
                if (_targets.Count() > 0) {
                    _target = _targets.Dequeue();
                } else {
                   Destroy(gameObject);
                }
            }

            transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
            Rotate();
        }

        private void Rotate() {
            transform.Rotate(0, 0, _rotationSpeed * Time.deltaTime);
        }
    }
}