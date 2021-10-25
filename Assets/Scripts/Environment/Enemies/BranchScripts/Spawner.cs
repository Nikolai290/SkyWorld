using Assets.Scripts.Common.Consts;
using Assets.Scripts.Common.GameScritps;
using UnityEngine;

namespace Assets.Scripts.Environment.Enemies.BranchScripts {
    public class Spawner : MonoBehaviour {
        [Tooltip("Направление полёта заспавленного объекта")]
        [SerializeField] private Transform _target;
        [Tooltip("Триггер, активирующий спавнер")]
        [SerializeField] private Trigger _trigger;
        [Tooltip("Параметры спавнера")]
        [SerializeField] private SpawnerParametres _branchParametres;

        private void Awake() {
            _trigger.Init(Tags.PLAYER, OnPlayerEnterTrigger, null, null);
            GetComponent<SpriteRenderer>().enabled = false;
        }

        public void OnPlayerEnterTrigger(GameObject player) {
            _trigger.gameObject.SetActive(false);

            if(Random.Range(0f, 1f) > _branchParametres.activationChance) {
                return;
            }

            var branchPrefab = _branchParametres.spawnedPrefabs[Random.Range(0, _branchParametres.spawnedPrefabs.Count)];

            var branch = Instantiate(branchPrefab, transform.position, Quaternion.identity);

            var branchScript = branch.GetComponent<Branch>();
            if (_branchParametres.randomRotation) {
                branchScript.Init(_branchParametres.speed, _branchParametres.randomRotation, _target);
            } else {
                branchScript.Init(_branchParametres.speed, _branchParametres.rotationSpeed, _target);
            }
        }
    }
}