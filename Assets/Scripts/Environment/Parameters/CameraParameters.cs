using UnityEngine;

namespace SkyWorld.Environment.Parameters {
    [CreateAssetMenu(fileName = "CameraParameters", menuName = "SkyWorld/CameraParameters")]
    public class CameraParameters : ScriptableObject {
        public float speedMultiple;
        public float offset;
    }
}