using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Environment.Enemies.BranchScripts {
    [CreateAssetMenu(fileName = "SpawnerParametres", menuName = "SkyWorld/SpawnerParametres", order = 0)]
    public class SpawnerParametres : ScriptableObject {
        public int damage;
        [Tooltip("Скорость полёта заспавненных объектов. Если объект летит в спину игроку, ставь скорость на 5-10 больше, чем если в морду")]
        public float speed;
        [Tooltip("Шанс срабатывания спанера после активации триггера 1 = 100%")]
        public float activationChance;
        [Tooltip("Скорость вращения заспавненного объекта в градусах в секунду")]
        public float rotationSpeed;
        [Tooltip("Вкл - Случайная скорость вращения заспавленного объекта от 60 до 360 градусов в секунду в любом направлении")]
        public bool randomRotation;
        [Tooltip("Несколько префабов случайный из которых будет заспавнен")]
        public List<GameObject> spawnedPrefabs;
    }
}