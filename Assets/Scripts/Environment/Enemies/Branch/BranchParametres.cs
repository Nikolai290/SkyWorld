using Assets.Scripts.Environment.Enemies.Spawner;
using UnityEngine;

namespace Assets.Scripts.Environment.Enemies.Branch {
    [CreateAssetMenu(fileName = "BranchParametres", menuName = "BranchParametres", order = 0)]
    public class BranchParametres : ScriptableObject, ISpawnedObjectParametres {
        [Tooltip("Урон")]
        public int damage;
    }
}