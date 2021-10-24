using Assets.Scripts.Common.Consts;
using UnityEngine;

namespace Assets.Scripts.Environment.Parameters {
    public class WorldBorders : MonoBehaviour {
        private GameObject LeftWorldBorder;
        private GameObject RightWorldBorder;
        private GameObject TopWorldBorder;
        private GameObject BottomWorldBorder;

        public Transform LeftBorder => LeftWorldBorder.GetComponentInChildren<Transform>();
        public Transform RightBorder => RightWorldBorder.GetComponentInChildren<Transform>();
        public Transform TopBorder => TopWorldBorder.GetComponentInChildren<Transform>();
        public Transform BottomBorder => BottomWorldBorder.GetComponentInChildren<Transform>();

        private void Awake() {
            LeftWorldBorder = GameObject.Find(Names.LEFT_WORLD_BORDER);
            RightWorldBorder = GameObject.Find(Names.RIGHT_WORLD_BORDER);
            TopWorldBorder = GameObject.Find(Names.TOP_WORLD_BORDER);
            BottomWorldBorder = GameObject.Find(Names.BOTTOM_WORLD_BORDER);
        }
    }
}