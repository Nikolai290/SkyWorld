using UnityEngine;

namespace SkyWorld.Environment.Parameters {
    [CreateAssetMenu(fileName = "WorldParameters", menuName = "SkyWorld/WorldParameters")]
    public class WorldParameters : ScriptableObject {
        public float endGameOffset;
        public float worldSpeed;
    }
}