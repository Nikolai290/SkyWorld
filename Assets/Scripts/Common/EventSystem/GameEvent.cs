using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Common.EventSystem {
    [CreateAssetMenu(fileName = "GameEvent", menuName = "Additional/GameEvent", order = 0)]
    public class GameEvent : ScriptableObject {
        private List<GameEventListener> listeners = new List<GameEventListener>();

        public void Raise<T>(T obj) {
            for (int i = 0; i < listeners.Count; i++) {
                listeners[i].OnEventRaise(obj);
            }
        }

        public void AddListener(GameEventListener listener) {
            listeners.Add(listener);
        }

        public void RemoveListener(GameEventListener listener) {
            listeners.Remove(listener);
        }
    }
}