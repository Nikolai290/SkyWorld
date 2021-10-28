using Assets.Scripts.Environment.Enemies.Spawner;
using UnityEngine;

namespace Assets.Scripts.Environment.Enemies {
    [CreateAssetMenu(fileName = "BranchParametres", menuName = "SkyWorld/BranchParametres", order = 0)]
    public class BranchParametres : SpawnedObjectAdditionalParametres, ISpawnedObjectParametres {
        [Tooltip("Урон")]
        public int damage;
    }
}