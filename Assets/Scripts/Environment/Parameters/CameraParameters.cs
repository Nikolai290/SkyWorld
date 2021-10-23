using UnityEngine;

namespace SkyWorld.Environment.Parameters {
    [CreateAssetMenu(fileName = "CameraParameters", menuName = "SkyWorld/CameraParameters")]
    public class CameraParameters : ScriptableObject {
        public float speedMultiple;
        public float yBorderOffset;
        public float xBorderOffset;
        public float minSize;
        public float maxSize;
    }
}