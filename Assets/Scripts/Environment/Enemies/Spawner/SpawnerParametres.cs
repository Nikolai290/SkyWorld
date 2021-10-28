using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Environment.Enemies.BranchScripts {
    [CreateAssetMenu(fileName = "SpawnerParametres", menuName = "SkyWorld/SpawnerParametres", order = 0)]
    public class SpawnerParametres : ScriptableObject {
        [Tooltip("Шанс срабатывания спанера после активации триггера 1 = 100%")]
        public float activationChance;
        [Tooltip("Несколько префабов случайный из которых будет заспавнен")]
        public List<GameObject> spawnedPrefabs;
    }
}