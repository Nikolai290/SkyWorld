using Assets.Scripts.Environment.Enemies.Spawner;
using UnityEngine;

namespace Assets.Scripts.Environment.Enemies {
    [CreateAssetMenu(fileName = "WingParametres", menuName = "SkyWorld/WingParametres", order = 0)]
    public class WingParametres : ScriptableObject, ISpawnedObjectParametres {
        public int damage;
        public float damageInterval;
    }
}