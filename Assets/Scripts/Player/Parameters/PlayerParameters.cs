using UnityEngine;

namespace SkyWorld.Player.Parameters {
    [CreateAssetMenu(fileName = "PlayerParameters", menuName = "SkyWorld/PlayerParameters")]
    public class PlayerParameters : ScriptableObject {
        public int health;
        public float speed;
        public float fallRate;
    }
}