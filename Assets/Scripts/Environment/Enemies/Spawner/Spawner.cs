using Assets.Scripts.Common.Consts;
using Assets.Scripts.Common.GameScritps;
using Assets.Scripts.Environment.Enemies.Spawner;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Environment.Enemies.BranchScripts {
    public class Spawner : MonoBehaviour {
        [Tooltip("Направление полёта заспавленного объекта")]
        [SerializeField] private List<Transform> _targets;
        [Tooltip("Триггер, активирующий спавнер")]
        [SerializeField] private Trigger _trigger;
        [Tooltip("Параметры спавнера")]
        [SerializeField] private SpawnerParametres _spawnerParametres;
        [SerializeField] private FlyObjectParametres _flyObjectParametres;
        [SerializeField] private SpawnedObjectAdditionalParametres _spawnedObjectAdditionalParametres;


        private GameObject _spawnedObject;
        private void Awake() {
            _trigger.Init(Tags.PLAYER, OnPlayerEnterTrigger, null, OnPlayerExitTrigger);
            GetComponent<SpriteRenderer>().enabled = false;
        }

        public void OnPlayerEnterTrigger(GameObject player) {
            if (Random.Range(0f, 1f) > _spawnerParametres.activationChance) {
                return;
            }

            var branchPrefab = _spawnerParametres.spawnedPrefabs[Random.Range(0, _spawnerParametres.spawnedPrefabs.Count)];

            _spawnedObject = Instantiate(branchPrefab, transform.position, Quaternion.identity);

            if (_spawnedObject.TryGetComponent(out FlyObject flyObject)) {
                flyObject.Init(_flyObjectParametres, _targets);
            }
            if(_spawnedObject.TryGetComponent(out ISpawnedObjectBehaviour obj)) {
                obj.Init(_spawnedObjectAdditionalParametres);
            }
        }

        public void OnPlayerExitTrigger(GameObject player) {
            Destroy(_spawnedObject);
        }
        
    }
}