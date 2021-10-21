using System;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Common.EventSystem {
    public class GameEventListener : MonoBehaviour {
        public GameEvent Event;

        public virtual void OnEventRaise<T>(T obj) {
            throw new NotImplementedException();
        }

        private void OnEnable() {
            Event.AddListener(this);
        }

        public void OnDisable() {
            Event.RemoveListener(this);
        }
    }
}
