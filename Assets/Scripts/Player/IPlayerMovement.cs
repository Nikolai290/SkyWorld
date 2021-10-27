using Assets.Scripts.Common.Interfaces;

namespace Assets.Scripts.Player {
    public interface IPlayerMovement  : IGameObject {
        float TotalSpeed { get; }
        void StopGameHandler();
    }
}
