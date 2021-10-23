using Assets.Scripts.Common.Consts;
using Assets.Scripts.Common.Directions;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Environment.Enemies {
    public class Cactus : MonoBehaviour {
        [SerializeField] private Transform _shootSpawnPoint;
        [SerializeField] private CactusParametres _cactusParametres;

        private bool _isShootingLoop;

        private void OnTriggerEnter2D(Collider2D collision) {
            if(collision.gameObject.tag == Tags.PLAYER) {
                _isShootingLoop = true;
                StartCoroutine(CactusShootingLoop());
            }
        }

        private void OnTriggerExit2D(Collider2D collision) {
            if(collision.gameObject.tag == Tags.PLAYER) {
                _isShootingLoop = false;
            }
        }

        private IEnumerator CactusShootingLoop() {
            while (_isShootingLoop) {
                for (int i = 0; i < _cactusParametres.shootCount; i++) {
                    if (_cactusParametres.UpShoot) {
                        Shoot(Direction.Up());
                    }
                    if (_cactusParametres.LeftShoot) {
                        Shoot(Direction.Left());
                    }
                    if (_cactusParametres.RightShoot) {
                        Shoot(Direction.Right());
                    }
                    yield return new WaitForSeconds(_cactusParametres.shootIntervalInRound);
                }
                yield return new WaitForSeconds(_cactusParametres.shootInterval);
            }
        }

        

        private void Shoot(Direction direction) {
            var spike = Instantiate(GetRandomSpike(), _shootSpawnPoint.transform.position, direction.quaternion);
            try {
                spike.GetComponent<Spike>().Init(
                        _cactusParametres.spikeSpeed,
                        _cactusParametres.spikeLifetime,
                        _cactusParametres.spikeDamage,
                        direction.vector
                    );
            } catch {
                Debug.LogError("Spike prefab hasn't 'Spike' script!");
            }
        }

        private GameObject GetRandomSpike() {
            return _cactusParametres.Spikes[Random.Range(0, _cactusParametres.Spikes.Count)];
        }
    }
}