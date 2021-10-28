using UnityEngine;

namespace Assets.Scripts.Environment.Enemies.BranchScripts {
    [CreateAssetMenu(fileName = "FlyObjectParametres", menuName = "SkyWorld/FlyObjectParametres", order = 0)]
    public class FlyObjectParametres : ScriptableObject {
        [Tooltip("Скорость полёта заспавненных объектов. Если объект летит в спину игроку, ставь скорость на 5-10 больше, чем если в морду")]
        public float speed;
        [Tooltip("Скорость вращения заспавненного объекта в градусах в секунду")]
        public float rotationSpeed;
        [Tooltip("Вкл - Случайная скорость вращения заспавленного объекта от 60 до 360 градусов в секунду в любом направлении")]
        public bool randomRotation;
    }
}