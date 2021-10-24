using UnityEngine;

namespace Assets.Scripts.Common.Interfaces {
    public interface IGameObject {
        GameObject gameObject { get; }
        Transform transform { get; }
    }
}
