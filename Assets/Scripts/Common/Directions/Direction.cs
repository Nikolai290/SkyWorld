using UnityEngine;

namespace Assets.Scripts.Common.Directions {
    public class Direction {
        public Quaternion quaternion;
        public Vector3 vector;

        public static Direction Up() {
            return new Direction() {
                quaternion = Quaternion.Euler(0, 0, 0),
                vector = Vector3.up
            };
        }
        public static Direction Down() {
            return new Direction() {
                quaternion = Quaternion.Euler(0, 0, 180),
                vector = Vector3.down
            };
        }
        public static Direction Left() {
            return new Direction() {
                quaternion = Quaternion.Euler(0, 0, 90),
                vector = Vector3.left
            };
        }
        public static Direction Right() {
            return new Direction() {
                quaternion = Quaternion.Euler(0, 0, -90),
                vector = Vector3.right
            };
        }
    }
}
